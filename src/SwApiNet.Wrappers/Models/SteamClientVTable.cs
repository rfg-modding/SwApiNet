using Microsoft.Extensions.Logging;

namespace SwApiNet.Wrappers.Models;

public partial struct SteamClientVTable
{
    partial class InterceptWrapper{
        private readonly CallCountGuard countGuard = new();

        public override unsafe IntPtr GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            return base.GetISteamApps(thisPtr, user, pipe, versionStr);
        }
    }
}
