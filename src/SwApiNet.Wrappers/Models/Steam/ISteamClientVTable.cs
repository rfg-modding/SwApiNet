using SwApiNet.Codegen;

namespace SwApiNet.Wrappers.Models.Steam;

[VTableProxy]
public unsafe interface ISteamClientVTable
{
    [Unused] nint CreateSteamPipe { get; }
    [Unused] nint BReleaseSteamPipe { get; }
    [Unused] nint ConnectToGlobalUser { get; }
    [Unused] nint CreateLocalUser { get; }
    [Unused] nint ReleaseUser { get; }
    /// <summary>
    /// </summary>
    /// <param name="thisPtr"></param>
    /// <param name="user">1</param>
    /// <param name="pipe">1</param>
    /// <param name="versionStr">SteamUser019</param>
    /// <returns></returns>
    nint GetISteamUser(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    [Unused] nint GetISteamGameServer { get; }
    [Unused] nint SetLocalIPBinding { get; }
    nint GetISteamFriends(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    nint GetISteamUtils(SteamClient* thisPtr, HSteamPipe pipe, byte* versionStr);
    nint GetISteamMatchmaking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamMatchmakingServers(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    [Unused] nint GetISteamGenericInterface { get; }
    nint GetISteamUserStats(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    [Unused] nint GetISteamGameServerStats { get; }
    nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <summary>
    /// https://partner.steamgames.com/doc/api/isteamnetworking
    /// </summary>
    /// <param name="thisPtr"></param>
    /// <param name="user">1</param>
    /// <param name="pipe">1</param>
    /// <param name="versionStr">SteamNetworking005</param>
    /// <returns></returns>
    nint GetISteamNetworking(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    nint GetISteamRemoteStorage(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamScreenshots(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    [Unused] nint RunFrame { get; }
    [Unused] nint GetIPCCallCount { get; }
    [Unused] nint SetWarningMessageHook { get; }
    [Unused] nint BShutdownIfAllPipesClosed { get; }
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamHTTP(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    [Unused] nint DEPRECATED_GetISteamUnifiedMessages { get; }
    nint GetISteamController(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamUGC(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamAppList(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamMusic(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamMusicRemote(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamHTMLSurface(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    [Unused] nint DEPRECATED_Set_SteamAPI_CPostAPIResultInProcess { get; }
    [Unused] nint DEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess { get; }
    [Unused] nint Set_SteamAPI_CCheckCallbackRegisteredInProcess { get; }
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamInventory(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamVideo(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    /// <returns>DEADBEEF</returns>
    [DeadBeef] nint GetISteamParentalSettings(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);

}
