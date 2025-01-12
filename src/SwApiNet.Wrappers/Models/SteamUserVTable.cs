using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace SwApiNet.Wrappers.Models;

partial struct SteamUserVTable
{
    partial class InterceptWrapper{
        private readonly CallCountGuard countGuard = new();

        public override unsafe int BLoggedOn(SteamUser* thisPtr)
        {
            return CFalse;
        }

        public override unsafe IntPtr GetSteamID(SteamUser* thisPtr, CSteamID* __return)
        {
            // cache value, reuse argument as return
            if (steamId != default)
            {
                *__return = steamId;
                return (nint)__return;
            }

            var result = base.GetSteamID(thisPtr, __return);
            steamId = *__return;
            Log.LogDebug("Cached CSteamId = {id}", steamId);
            return result;
        }

        private static CSteamID steamId;
    }
}
