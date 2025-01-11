using SwApiNet.Codegen;

namespace SwApiNet.Wrappers.Models;

[VTableProxy]
public unsafe interface ISteamClientVTable
{
    //nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    // actual fields, generate with Ptr suffix
    public nint UnusedCreateSteamPipe { get; }
    public nint UnusedBReleaseSteamPipe { get; }
    public nint UnusedConnectToGlobalUser { get; }
    public nint UnusedCreateLocalUser { get; }
    public nint UnusedReleaseUser { get; }
    public nint GetISteamUser { get; }
    public nint UnusedGetISteamGameServer { get; }
    public nint UnusedSetLocalIPBinding { get; }
    public nint GetISteamFriends { get; }
    public nint GetISteamUtils { get; }
    public nint GetISteamMatchmaking { get; }
    public nint GetISteamMatchmakingServers { get; }
    public nint UnusedGetISteamGenericInterface { get; }
    public nint GetISteamUserStats { get; }
    public nint UnusedGetISteamGameServerStats { get; }
    nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    public nint GetISteamNetworking { get; }
    public nint GetISteamRemoteStorage { get; }
    public nint GetISteamScreenshots { get; }
    public nint UnusedRunFrame { get; }
    public nint UnusedGetIPCCallCount { get; }
    public nint UnusedSetWarningMessageHook { get; }
    public nint UnusedBShutdownIfAllPipesClosed { get; }
    public nint GetISteamHTTP { get; }
    public nint UnusedDEPRECATED_GetISteamUnifiedMessages { get; }
    public nint GetISteamController { get; }
    public nint GetISteamUGC { get; }
    public nint GetISteamAppList { get; }
    public nint GetISteamMusic { get; }
    public nint GetISteamMusicRemote { get; }
    public nint GetISteamHTMLSurface { get; }
    public nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess { get; }
    public nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess { get; }
    public nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess { get; }
    public nint GetISteamInventory { get; }
    public nint GetISteamVideo { get; }
    public nint GetISteamParentalSettings { get; }

}
