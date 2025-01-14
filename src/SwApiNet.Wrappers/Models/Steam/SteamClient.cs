using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models.Steam;

public partial struct SteamClient
{
    public partial struct VTable
    {
        public partial class InterceptWrapper
        {
            private readonly CallCountGuard countGuard = new();

            public override unsafe IntPtr GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
            {
                countGuard.Check(1);
                var result = (SteamApps*) base.GetISteamApps(thisPtr, user, pipe, versionStr);
                SteamApps* fake = (SteamApps*) Marshal.AllocHGlobal(sizeof(SteamApps));
                fake->Table = (SteamApps.VTable*) Marshal.AllocHGlobal(sizeof(VTable));
                Marshal.StructureToPtr(new SteamApps.VTable(result->Table), (nint) fake->Table, true);
                return (nint) fake;
            }

            public override unsafe nint GetISteamUser(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
            {
                countGuard.Check(1);
                var result = (SteamUser*) base.GetISteamUser(thisPtr, user, pipe, versionStr);
                SteamUser* fake = (SteamUser*) Marshal.AllocHGlobal(sizeof(SteamUser));
                fake->Table = (SteamUser.VTable*) Marshal.AllocHGlobal(sizeof(SteamUser.VTable));
                Marshal.StructureToPtr(new SteamUser.VTable(result->Table), (nint) fake->Table, true);
                return (nint) fake;
            }

            public override unsafe IntPtr GetISteamNetworking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
            {
                countGuard.Check(1);
                var result = (SteamNetworking*) base.GetISteamNetworking(thisPtr, user, pipe, versionStr);
                SteamNetworking* fake = (SteamNetworking*) Marshal.AllocHGlobal(sizeof(SteamNetworking));
                fake->Table = (SteamNetworking.VTable*) Marshal.AllocHGlobal(sizeof(SteamNetworking.VTable));
                Marshal.StructureToPtr(new SteamNetworking.VTable(result->Table), (nint) fake->Table, true);
                return (nint) fake;
            }

            public override unsafe IntPtr GetISteamMatchmaking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
            {
                countGuard.Check(1);
                var result = (SteamMatchmaking*) base.GetISteamMatchmaking(thisPtr, user, pipe, versionStr);
                SteamMatchmaking* fake = (SteamMatchmaking*) Marshal.AllocHGlobal(sizeof(SteamMatchmaking));
                fake->Table = (SteamMatchmaking.VTable*) Marshal.AllocHGlobal(sizeof(SteamMatchmaking.VTable));
                Marshal.StructureToPtr(new SteamMatchmaking.VTable(result->Table), (nint) fake->Table, true);
                return (nint) fake;
            }
        }
    }
}
