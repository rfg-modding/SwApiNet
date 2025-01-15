using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Models.Structs;

namespace SwApiNet.Wrappers.Models.Steam;

unsafe partial struct Callback
{
    /// <summary>
    /// Additional information about callback type, registered from InitCallbackFunc
    /// </summary>
    public record CallbackInfo(string RegisteredFrom, CallbackType CallbackType);

    partial struct Fields
    {
        public CallbackFlags CallbackFlags;
        public CallbackType CallbackType;

        /// <summary>
        /// eg. GameLinkInternet ?
        /// </summary>
        public nint Object;

        /// <summary>
        /// public function void(T* this, U* data) Func // data type is defined by CallbackType
        /// </summary>
        public delegate* unmanaged[Thiscall]<nint, nint> FuncPtr;
    }

    partial class Interop
    {
        public static readonly Dictionary<nint, CallbackInfo> DataByFakeVTable = new();
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
            var info = Interop.DataByFakeVTable[(nint) thisPtr->Table];
            var payload = ParsePayload(info.CallbackType, somePtr) ?? "(missing struct type)";
            Log.LogInformation($"{info} flags={thisPtr->OtherFields.CallbackFlags} type={thisPtr->OtherFields.CallbackType} {JsonSerializer.Serialize(payload)}");
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
                CallbackType.SteamUserStatsReceived => Marshal.PtrToStructure<UserStatsReceived>(x),
                CallbackType.SteamUserStatsStored => Marshal.PtrToStructure<UserStatsStored>(x),
                CallbackType.SteamUserAchievementStored => Marshal.PtrToStructure<UserAchievementStored>(x),
                CallbackType.P2PSessionRequest => Marshal.PtrToStructure<P2PSessionRequest>(x),
                _ => null
            };
    }
}
