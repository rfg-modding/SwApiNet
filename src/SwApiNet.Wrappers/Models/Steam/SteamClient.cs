using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Utils;

namespace SwApiNet.Wrappers.Models.Steam;

public partial struct SteamClient
{
    public partial class InterceptWrapper
    {
        private readonly CallCountGuard countGuard = new();

        public override unsafe nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            return SteamApps.Hijack(base.GetISteamApps(thisPtr, user, pipe, versionStr));
        }

        public override unsafe nint GetISteamUser(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            return SteamUser.Hijack(base.GetISteamUser(thisPtr, user, pipe, versionStr));
        }

        public override unsafe nint GetISteamNetworking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            return SteamNetworking.Hijack(base.GetISteamNetworking(thisPtr, user, pipe, versionStr));
        }

        public override unsafe nint GetISteamMatchmaking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            return SteamMatchmaking.Hijack(base.GetISteamMatchmaking(thisPtr, user, pipe, versionStr));
        }
    }
}
