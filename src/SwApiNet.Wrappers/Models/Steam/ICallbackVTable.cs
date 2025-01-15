using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using SwApiNet.Codegen;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Models.Structs;

namespace SwApiNet.Wrappers.Models.Steam;

[DynamicVTableProxy]
public unsafe interface ICallbackVTable
{
    void Run(Callback* thisPtr, nint somePtr, byte someByte, ulong someUlong);
    void Run2(Callback* thisPtr, nint somePtr);
    int GetCallbackSizeBytes(Callback* thisPtr);
    void Unknown(Callback* thisPtr); // callback vtables have 0x10 offset from each other for a reason? TODO this signature is not real!
}

unsafe partial struct Callback
{
    /// <summary>
    /// Additional information about callback type, registered from InitCallbackFunc
    /// </summary>
    public record CallbackInfo(string RegisteredFrom, CallbackType CallbackType);

    /// <summary>
    /// Additional information about call result type, registered from RegisterCallResult
    /// </summary>
    public record CallResultInfo(string RegisteredFrom, ulong MaybeId);

    partial class Interop
    {
        public static readonly Dictionary<nint, object> DataByFakeVTable = new();
    }

    partial class InterceptWrapper
    {
        public override unsafe void Run(Callback* thisPtr, nint somePtr, byte someByte, ulong someUlong)
        {
            LogPayload(thisPtr, somePtr);
            base.Run(thisPtr, somePtr, someByte, someUlong);
        }

        public override unsafe void Run2(Callback* thisPtr, nint somePtr)
        {
            LogPayload(thisPtr, somePtr);
            base.Run2(thisPtr, somePtr);
        }

        private void LogPayload(Callback* thisPtr, nint somePtr)
        {
            var obj = Interop.DataByFakeVTable[(nint) thisPtr->Table];
            switch (obj)
            {
                case CallbackInfo i:
                {
                    var payload = ParsePayload(i.CallbackType, somePtr) ?? "(missing struct type)";
                    Log.LogInformation($"{i} {JsonSerializer.Serialize(payload)}");
                    break;
                }
                case CallResultInfo r:
                    Log.LogInformation($"{r} (payload unavailable)");
                    break;
            }
        }

        private object? ParsePayload(CallbackType type, nint x) =>
            type switch
            {
                CallbackType.ValidateAuthTicketResponse => Marshal.PtrToStructure<ValidateAuthTicketResponse>(x),
                CallbackType.GetAuthSessionTicketResponse => Marshal.PtrToStructure<GetAuthSessionTicketResponse>(x),
                CallbackType.GameLobbyJoinRequested => Marshal.PtrToStructure<GameLobbyJoinRequested>(x),
                CallbackType.LobbyEnter => Marshal.PtrToStructure<LobbyEnter>(x),
                CallbackType.LobbyDataUpdate => Marshal.PtrToStructure<LobbyDataUpdate>(x),
                CallbackType.LobbyChatUpdate => Marshal.PtrToStructure<LobbyChatUpdate>(x),
                CallbackType.LobbyMatchList => Marshal.PtrToStructure<LobbyMatchList>(x),
                CallbackType.LobbyCreated => Marshal.PtrToStructure<LobbyCreated>(x),
                CallbackType.SteamUserStatsReceived => null,
                CallbackType.SteamUserStatsStored => null,
                CallbackType.SteamUserAchievementStored => null,
                CallbackType.P2PSessionRequest => Marshal.PtrToStructure<P2PSessionRequest>(x),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
    }
}
