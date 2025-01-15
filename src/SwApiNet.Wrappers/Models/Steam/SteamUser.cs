using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Utils;

namespace SwApiNet.Wrappers.Models.Steam;

public partial struct SteamUser
{
    public partial class InterceptWrapper
    {
        private readonly CallCountGuard countGuard = new();

        public override unsafe int BLoggedOn(SteamUser* thisPtr)
        {
            return CFalse;
        }

        public override unsafe nint GetSteamID(SteamUser* thisPtr, CSteamID* __return)
        {
            // cache value, reuse argument as return
            if (steamId != default)
            {
                *__return = steamId;
                return (nint) __return;
            }

            var result = base.GetSteamID(thisPtr, __return);
            steamId = *__return;
            Log.LogDebug("Cached CSteamId = {id}", steamId);
            return result;
        }

        private static CSteamID steamId;
    }
}
