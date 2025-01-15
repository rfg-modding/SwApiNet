using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Models.Structs;

namespace SwApiNet.Wrappers.Models.Steam;

unsafe partial struct CallResult
{
    /// <summary>
    /// Additional information about call result type, registered from RegisterCallResult
    /// </summary>
    public record CallResultInfo(string RegisteredFrom, ulong MaybeId);

    partial struct Fields
    {
        public CallbackFlags CallbackFlags;
        public CallbackType CallbackType;

        public SteamAPICall SteamApiCall; //Unique handle for an API call. The vanilla DLL mimics the steamworks API so that's why we use the SteamAPICall type

        /// <summary>
        /// Have no idea what this might be
        /// </summary>
        public nint Object;

        /// <summary>
        /// public function void(T* this, U* data, bool bIOFailure) Func;
        /// </summary>
        public delegate* unmanaged[Thiscall]<nint, nint, int> FuncPtr;
    }

    partial class Interop
    {
        public static readonly Dictionary<nint, CallResultInfo> DataByFakeVTable = new();
    }

    partial class InterceptWrapper
    {
        public override unsafe void Run(CallResult* thisPtr, nint somePtr, byte someByte, ulong someUlong)
        {
            LogPayload(thisPtr, somePtr);
            base.Run(thisPtr, somePtr, someByte, someUlong);
        }

        public override unsafe void Run2(CallResult* thisPtr, nint somePtr)
        {
            LogPayload(thisPtr, somePtr);
            base.Run2(thisPtr, somePtr);
        }

        private void LogPayload(CallResult* thisPtr, nint somePtr)
        {
            var info = Interop.DataByFakeVTable[(nint) thisPtr->Table];
            Log.LogInformation($"{info} flags={thisPtr->OtherFields.CallbackFlags} type={thisPtr->OtherFields.CallbackType} steamApiCall={thisPtr->OtherFields.SteamApiCall}");
        }
    }
}
