using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

public partial struct SteamClientVTable
{
    partial class InterceptWrapper{
        private readonly CallCountGuard countGuard = new();

        public override unsafe IntPtr GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            var result = (SteamApps*)base.GetISteamApps(thisPtr, user, pipe, versionStr);
            SteamApps* fake = (SteamApps*)Marshal.AllocHGlobal(sizeof(SteamApps));
            fake->Table = (SteamAppsVTable*) Marshal.AllocHGlobal(sizeof(SteamAppsVTable));
            Marshal.StructureToPtr(new SteamAppsVTable(result->Table), (nint)fake->Table, true);
            return (nint)fake;
        }

        public override unsafe nint GetISteamUser(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            var result = (SteamUser*) base.GetISteamUser(thisPtr, user, pipe, versionStr);
            SteamUser* fake = (SteamUser*)Marshal.AllocHGlobal(sizeof(SteamUser));
            fake->Table = (SteamUserVTable*) Marshal.AllocHGlobal(sizeof(SteamUserVTable));
            Marshal.StructureToPtr(new SteamUserVTable(result->Table), (nint)fake->Table, true);
            return (nint)fake;
        }

        public override unsafe IntPtr GetISteamNetworking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            var result = (SteamNetworking*) base.GetISteamNetworking(thisPtr, user, pipe, versionStr);
            SteamNetworking* fake = (SteamNetworking*)Marshal.AllocHGlobal(sizeof(SteamNetworking));
            fake->Table = (SteamNetworkingVTable*) Marshal.AllocHGlobal(sizeof(SteamNetworkingVTable));
            Marshal.StructureToPtr(new SteamNetworkingVTable(result->Table), (nint)fake->Table, true);
            return (nint)fake;
        }

        public override unsafe IntPtr GetISteamMatchmaking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            var result = (SteamMatchmaking*) base.GetISteamMatchmaking(thisPtr, user, pipe, versionStr);
            SteamMatchmaking* fake = (SteamMatchmaking*)Marshal.AllocHGlobal(sizeof(SteamMatchmaking));
            fake->Table = (SteamMatchmakingVTable*) Marshal.AllocHGlobal(sizeof(SteamMatchmakingVTable));
            Marshal.StructureToPtr(new SteamMatchmakingVTable(result->Table), (nint)fake->Table, true);
            return (nint)fake;
        }
    }
}
