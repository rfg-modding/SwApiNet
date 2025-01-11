using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

/// <inheritdoc />
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SteamClientVTableGeneratedExample : ISteamClientVTable
{
    /// <inheritdoc />
    public SteamClientVTableGeneratedExample(SteamClientVTable* real)
    {
        // can't store directly in the struct, it will affect size
        Interop.Target = new InterceptWrapper(new LogWrapper(new PassThroughWrapper()));

        // replace real pointers
        // fields will be equal to values of real struct
        // methods will point to fake exported delegates to call wrapper chain
        Interop.UnusedCreateSteamPipeReal = real->UnusedCreateSteamPipeVal;
        Interop.UnusedCreateSteamPipeFake = real->UnusedCreateSteamPipeVal;
        Interop.UnusedBReleaseSteamPipeReal = real->UnusedBReleaseSteamPipeVal;
        Interop.UnusedBReleaseSteamPipeFake = real->UnusedBReleaseSteamPipeVal;
        Interop.UnusedConnectToGlobalUserReal = real->UnusedConnectToGlobalUserVal;
        Interop.UnusedConnectToGlobalUserFake = real->UnusedConnectToGlobalUserVal;
        Interop.UnusedCreateLocalUserReal = real->UnusedCreateLocalUserVal;
        Interop.UnusedCreateLocalUserFake = real->UnusedCreateLocalUserVal;
        Interop.UnusedReleaseUserReal = real->UnusedReleaseUserVal;
        Interop.UnusedReleaseUserFake = real->UnusedReleaseUserVal;
        Interop.GetISteamUserReal = real->GetISteamUserVal;
        Interop.GetISteamUserFake = real->GetISteamUserVal;
        Interop.UnusedGetISteamGameServerReal = real->UnusedGetISteamGameServerVal;
        Interop.UnusedGetISteamGameServerFake = real->UnusedGetISteamGameServerVal;
        Interop.UnusedSetLocalIPBindingReal = real->UnusedSetLocalIPBindingVal;
        Interop.UnusedSetLocalIPBindingFake = real->UnusedSetLocalIPBindingVal;
        Interop.GetISteamFriendsReal = real->GetISteamFriendsVal;
        Interop.GetISteamFriendsFake = real->GetISteamFriendsVal;
        Interop.GetISteamUtilsReal = real->GetISteamUtilsVal;
        Interop.GetISteamUtilsFake = real->GetISteamUtilsVal;
        Interop.GetISteamMatchmakingReal = real->GetISteamMatchmakingVal;
        Interop.GetISteamMatchmakingFake = real->GetISteamMatchmakingVal;
        Interop.GetISteamMatchmakingServersReal = real->GetISteamMatchmakingServersVal;
        Interop.GetISteamMatchmakingServersFake = real->GetISteamMatchmakingServersVal;
        Interop.UnusedGetISteamGenericInterfaceReal = real->UnusedGetISteamGenericInterfaceVal;
        Interop.UnusedGetISteamGenericInterfaceFake = real->UnusedGetISteamGenericInterfaceVal;
        Interop.GetISteamUserStatsReal = real->GetISteamUserStatsVal;
        Interop.GetISteamUserStatsFake = real->GetISteamUserStatsVal;
        Interop.UnusedGetISteamGameServerStatsReal = real->UnusedGetISteamGameServerStatsVal;
        Interop.UnusedGetISteamGameServerStatsFake = real->UnusedGetISteamGameServerStatsVal;
        Interop.GetISteamAppsReal = real->GetISteamAppsPtr;
        Interop.GetISteamNetworkingReal = real->GetISteamNetworkingVal;
        Interop.GetISteamNetworkingFake = real->GetISteamNetworkingVal;
        Interop.GetISteamRemoteStorageReal = real->GetISteamRemoteStorageVal;
        Interop.GetISteamRemoteStorageFake = real->GetISteamRemoteStorageVal;
        Interop.GetISteamScreenshotsReal = real->GetISteamScreenshotsVal;
        Interop.GetISteamScreenshotsFake = real->GetISteamScreenshotsVal;
        Interop.UnusedRunFrameReal = real->UnusedRunFrameVal;
        Interop.UnusedRunFrameFake = real->UnusedRunFrameVal;
        Interop.UnusedGetIPCCallCountReal = real->UnusedGetIPCCallCountVal;
        Interop.UnusedGetIPCCallCountFake = real->UnusedGetIPCCallCountVal;
        Interop.UnusedSetWarningMessageHookReal = real->UnusedSetWarningMessageHookVal;
        Interop.UnusedSetWarningMessageHookFake = real->UnusedSetWarningMessageHookVal;
        Interop.UnusedBShutdownIfAllPipesClosedReal = real->UnusedBShutdownIfAllPipesClosedVal;
        Interop.UnusedBShutdownIfAllPipesClosedFake = real->UnusedBShutdownIfAllPipesClosedVal;
        Interop.GetISteamHTTPReal = real->GetISteamHTTPVal;
        Interop.GetISteamHTTPFake = real->GetISteamHTTPVal;
        Interop.UnusedDEPRECATED_GetISteamUnifiedMessagesReal = real->UnusedDEPRECATED_GetISteamUnifiedMessagesVal;
        Interop.UnusedDEPRECATED_GetISteamUnifiedMessagesFake = real->UnusedDEPRECATED_GetISteamUnifiedMessagesVal;
        Interop.GetISteamControllerReal = real->GetISteamControllerVal;
        Interop.GetISteamControllerFake = real->GetISteamControllerVal;
        Interop.GetISteamUGCReal = real->GetISteamUGCVal;
        Interop.GetISteamUGCFake = real->GetISteamUGCVal;
        Interop.GetISteamAppListReal = real->GetISteamAppListVal;
        Interop.GetISteamAppListFake = real->GetISteamAppListVal;
        Interop.GetISteamMusicReal = real->GetISteamMusicVal;
        Interop.GetISteamMusicFake = real->GetISteamMusicVal;
        Interop.GetISteamMusicRemoteReal = real->GetISteamMusicRemoteVal;
        Interop.GetISteamMusicRemoteFake = real->GetISteamMusicRemoteVal;
        Interop.GetISteamHTMLSurfaceReal = real->GetISteamHTMLSurfaceVal;
        Interop.GetISteamHTMLSurfaceFake = real->GetISteamHTMLSurfaceVal;
        Interop.UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessReal = real->UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessVal;
        Interop.UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessFake = real->UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessVal;
        Interop.UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessReal = real->UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessVal;
        Interop.UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessFake = real->UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessVal;
        Interop.UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessReal = real->UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessVal;
        Interop.UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessFake = real->UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessVal;
        Interop.GetISteamInventoryReal = real->GetISteamInventoryVal;
        Interop.GetISteamInventoryFake = real->GetISteamInventoryVal;
        Interop.GetISteamVideoReal = real->GetISteamVideoVal;
        Interop.GetISteamVideoFake = real->GetISteamVideoVal;
        Interop.GetISteamParentalSettingsReal = real->GetISteamParentalSettingsVal;
        Interop.GetISteamParentalSettingsFake = real->GetISteamParentalSettingsVal;

        // wire fake pointers and values
        this.UnusedCreateSteamPipeVal = real->UnusedCreateSteamPipe;
        this.UnusedBReleaseSteamPipeVal = real->UnusedBReleaseSteamPipe;
        this.UnusedConnectToGlobalUserVal = real->UnusedConnectToGlobalUser;
        this.UnusedCreateLocalUserVal = real->UnusedCreateLocalUser;
        this.UnusedReleaseUserVal = real->UnusedReleaseUser;
        this.GetISteamUserVal = real->GetISteamUser;
        this.UnusedGetISteamGameServerVal = real->UnusedGetISteamGameServer;
        this.UnusedSetLocalIPBindingVal = real->UnusedSetLocalIPBinding;
        this.GetISteamFriendsVal = real->GetISteamFriends;
        this.GetISteamUtilsVal = real->GetISteamUtils;
        this.GetISteamMatchmakingVal = real->GetISteamMatchmaking;
        this.GetISteamMatchmakingServersVal = real->GetISteamMatchmakingServers;
        this.UnusedGetISteamGenericInterfaceVal = real->UnusedGetISteamGenericInterface;
        this.GetISteamUserStatsVal = real->GetISteamUserStats;
        this.UnusedGetISteamGameServerStatsVal = real->UnusedGetISteamGameServerStats;
        this.GetISteamAppsPtr = Interop.GetISteamAppsFake;
        this.GetISteamNetworkingVal = real->GetISteamNetworking;
        this.GetISteamRemoteStorageVal = real->GetISteamRemoteStorage;
        this.GetISteamScreenshotsVal = real->GetISteamScreenshots;
        this.UnusedRunFrameVal = real->UnusedRunFrame;
        this.UnusedGetIPCCallCountVal = real->UnusedGetIPCCallCount;
        this.UnusedSetWarningMessageHookVal = real->UnusedSetWarningMessageHook;
        this.UnusedBShutdownIfAllPipesClosedVal = real->UnusedBShutdownIfAllPipesClosed;
        this.GetISteamHTTPVal = real->GetISteamHTTP;
        this.UnusedDEPRECATED_GetISteamUnifiedMessagesVal = real->UnusedDEPRECATED_GetISteamUnifiedMessages;
        this.GetISteamControllerVal = real->GetISteamController;
        this.GetISteamUGCVal = real->GetISteamUGC;
        this.GetISteamAppListVal = real->GetISteamAppList;
        this.GetISteamMusicVal = real->GetISteamMusic;
        this.GetISteamMusicRemoteVal = real->GetISteamMusicRemote;
        this.GetISteamHTMLSurfaceVal = real->GetISteamHTMLSurface;
        this.UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessVal = real->UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess;
        this.UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessVal = real->UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess;
        this.UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessVal = real->UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess;
        this.GetISteamInventoryVal = real->GetISteamInventory;
        this.GetISteamVideoVal = real->GetISteamVideo;
        this.GetISteamParentalSettingsVal = real->GetISteamParentalSettings;

    }

    // actual fields
    public nint UnusedCreateSteamPipeVal;
    public nint UnusedBReleaseSteamPipeVal;
    public nint UnusedConnectToGlobalUserVal;
    public nint UnusedCreateLocalUserVal;
    public nint UnusedReleaseUserVal;
    public nint GetISteamUserVal;
    public nint UnusedGetISteamGameServerVal;
    public nint UnusedSetLocalIPBindingVal;
    public nint GetISteamFriendsVal;
    public nint GetISteamUtilsVal;
    public nint GetISteamMatchmakingVal;
    public nint GetISteamMatchmakingServersVal;
    public nint UnusedGetISteamGenericInterfaceVal;
    public nint GetISteamUserStatsVal;
    public nint UnusedGetISteamGameServerStatsVal;
    public delegate* unmanaged[Thiscall]<SwApiNet.Wrappers.Models.SteamClient*, SwApiNet.Wrappers.Models.HSteamUser, SwApiNet.Wrappers.Models.HSteamPipe, byte*, nint> GetISteamAppsPtr;
    public nint GetISteamNetworkingVal;
    public nint GetISteamRemoteStorageVal;
    public nint GetISteamScreenshotsVal;
    public nint UnusedRunFrameVal;
    public nint UnusedGetIPCCallCountVal;
    public nint UnusedSetWarningMessageHookVal;
    public nint UnusedBShutdownIfAllPipesClosedVal;
    public nint GetISteamHTTPVal;
    public nint UnusedDEPRECATED_GetISteamUnifiedMessagesVal;
    public nint GetISteamControllerVal;
    public nint GetISteamUGCVal;
    public nint GetISteamAppListVal;
    public nint GetISteamMusicVal;
    public nint GetISteamMusicRemoteVal;
    public nint GetISteamHTMLSurfaceVal;
    public nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessVal;
    public nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessVal;
    public nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessVal;
    public nint GetISteamInventoryVal;
    public nint GetISteamVideoVal;
    public nint GetISteamParentalSettingsVal;

    // internally callable methods
    public nint UnusedCreateSteamPipe => this.UnusedCreateSteamPipeVal;
    public nint UnusedBReleaseSteamPipe => this.UnusedBReleaseSteamPipeVal;
    public nint UnusedConnectToGlobalUser => this.UnusedConnectToGlobalUserVal;
    public nint UnusedCreateLocalUser => this.UnusedCreateLocalUserVal;
    public nint UnusedReleaseUser => this.UnusedReleaseUserVal;
    public nint GetISteamUser => this.GetISteamUserVal;
    public nint UnusedGetISteamGameServer => this.UnusedGetISteamGameServerVal;
    public nint UnusedSetLocalIPBinding => this.UnusedSetLocalIPBindingVal;
    public nint GetISteamFriends => this.GetISteamFriendsVal;
    public nint GetISteamUtils => this.GetISteamUtilsVal;
    public nint GetISteamMatchmaking => this.GetISteamMatchmakingVal;
    public nint GetISteamMatchmakingServers => this.GetISteamMatchmakingServersVal;
    public nint UnusedGetISteamGenericInterface => this.UnusedGetISteamGenericInterfaceVal;
    public nint GetISteamUserStats => this.GetISteamUserStatsVal;
    public nint UnusedGetISteamGameServerStats => this.UnusedGetISteamGameServerStatsVal;
    public nint GetISteamApps(SwApiNet.Wrappers.Models.SteamClient* thisPtr, SwApiNet.Wrappers.Models.HSteamUser user, SwApiNet.Wrappers.Models.HSteamPipe pipe, byte* versionStr) => Interop.Target.GetISteamApps(thisPtr, user, pipe, versionStr);
    public nint GetISteamNetworking => this.GetISteamNetworkingVal;
    public nint GetISteamRemoteStorage => this.GetISteamRemoteStorageVal;
    public nint GetISteamScreenshots => this.GetISteamScreenshotsVal;
    public nint UnusedRunFrame => this.UnusedRunFrameVal;
    public nint UnusedGetIPCCallCount => this.UnusedGetIPCCallCountVal;
    public nint UnusedSetWarningMessageHook => this.UnusedSetWarningMessageHookVal;
    public nint UnusedBShutdownIfAllPipesClosed => this.UnusedBShutdownIfAllPipesClosedVal;
    public nint GetISteamHTTP => this.GetISteamHTTPVal;
    public nint UnusedDEPRECATED_GetISteamUnifiedMessages => this.UnusedDEPRECATED_GetISteamUnifiedMessagesVal;
    public nint GetISteamController => this.GetISteamControllerVal;
    public nint GetISteamUGC => this.GetISteamUGCVal;
    public nint GetISteamAppList => this.GetISteamAppListVal;
    public nint GetISteamMusic => this.GetISteamMusicVal;
    public nint GetISteamMusicRemote => this.GetISteamMusicRemoteVal;
    public nint GetISteamHTMLSurface => this.GetISteamHTMLSurfaceVal;
    public nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess => this.UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessVal;
    public nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess => this.UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessVal;
    public nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess => this.UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessVal;
    public nint GetISteamInventory => this.GetISteamInventoryVal;
    public nint GetISteamVideo => this.GetISteamVideoVal;
    public nint GetISteamParentalSettings => this.GetISteamParentalSettingsVal;


    /// <inheritdoc />
    public partial class LogWrapper(ISteamClientVTable target) : ISteamClientVTable
    {
        public nint UnusedCreateSteamPipe => Tools.LogMethod(() => target.UnusedCreateSteamPipe, ArgsBag.Empty);
        public nint UnusedBReleaseSteamPipe => Tools.LogMethod(() => target.UnusedBReleaseSteamPipe, ArgsBag.Empty);
        public nint UnusedConnectToGlobalUser => Tools.LogMethod(() => target.UnusedConnectToGlobalUser, ArgsBag.Empty);
        public nint UnusedCreateLocalUser => Tools.LogMethod(() => target.UnusedCreateLocalUser, ArgsBag.Empty);
        public nint UnusedReleaseUser => Tools.LogMethod(() => target.UnusedReleaseUser, ArgsBag.Empty);
        public nint GetISteamUser => Tools.LogMethod(() => target.GetISteamUser, ArgsBag.Empty);
        public nint UnusedGetISteamGameServer => Tools.LogMethod(() => target.UnusedGetISteamGameServer, ArgsBag.Empty);
        public nint UnusedSetLocalIPBinding => Tools.LogMethod(() => target.UnusedSetLocalIPBinding, ArgsBag.Empty);
        public nint GetISteamFriends => Tools.LogMethod(() => target.GetISteamFriends, ArgsBag.Empty);
        public nint GetISteamUtils => Tools.LogMethod(() => target.GetISteamUtils, ArgsBag.Empty);
        public nint GetISteamMatchmaking => Tools.LogMethod(() => target.GetISteamMatchmaking, ArgsBag.Empty);
        public nint GetISteamMatchmakingServers => Tools.LogMethod(() => target.GetISteamMatchmakingServers, ArgsBag.Empty);
        public nint UnusedGetISteamGenericInterface => Tools.LogMethod(() => target.UnusedGetISteamGenericInterface, ArgsBag.Empty);
        public nint GetISteamUserStats => Tools.LogMethod(() => target.GetISteamUserStats, ArgsBag.Empty);
        public nint UnusedGetISteamGameServerStats => Tools.LogMethod(() => target.UnusedGetISteamGameServerStats, ArgsBag.Empty);
        public nint GetISteamApps(SwApiNet.Wrappers.Models.SteamClient* thisPtr, SwApiNet.Wrappers.Models.HSteamUser user, SwApiNet.Wrappers.Models.HSteamPipe pipe, byte* versionStr) => Tools.LogMethod(() => target.GetISteamApps(thisPtr, user, pipe, versionStr), ArgsBag.Init().Add(thisPtr).Add(user).Add(pipe).Add(versionStr));
        public nint GetISteamNetworking => Tools.LogMethod(() => target.GetISteamNetworking, ArgsBag.Empty);
        public nint GetISteamRemoteStorage => Tools.LogMethod(() => target.GetISteamRemoteStorage, ArgsBag.Empty);
        public nint GetISteamScreenshots => Tools.LogMethod(() => target.GetISteamScreenshots, ArgsBag.Empty);
        public nint UnusedRunFrame => Tools.LogMethod(() => target.UnusedRunFrame, ArgsBag.Empty);
        public nint UnusedGetIPCCallCount => Tools.LogMethod(() => target.UnusedGetIPCCallCount, ArgsBag.Empty);
        public nint UnusedSetWarningMessageHook => Tools.LogMethod(() => target.UnusedSetWarningMessageHook, ArgsBag.Empty);
        public nint UnusedBShutdownIfAllPipesClosed => Tools.LogMethod(() => target.UnusedBShutdownIfAllPipesClosed, ArgsBag.Empty);
        public nint GetISteamHTTP => Tools.LogMethod(() => target.GetISteamHTTP, ArgsBag.Empty);
        public nint UnusedDEPRECATED_GetISteamUnifiedMessages => Tools.LogMethod(() => target.UnusedDEPRECATED_GetISteamUnifiedMessages, ArgsBag.Empty);
        public nint GetISteamController => Tools.LogMethod(() => target.GetISteamController, ArgsBag.Empty);
        public nint GetISteamUGC => Tools.LogMethod(() => target.GetISteamUGC, ArgsBag.Empty);
        public nint GetISteamAppList => Tools.LogMethod(() => target.GetISteamAppList, ArgsBag.Empty);
        public nint GetISteamMusic => Tools.LogMethod(() => target.GetISteamMusic, ArgsBag.Empty);
        public nint GetISteamMusicRemote => Tools.LogMethod(() => target.GetISteamMusicRemote, ArgsBag.Empty);
        public nint GetISteamHTMLSurface => Tools.LogMethod(() => target.GetISteamHTMLSurface, ArgsBag.Empty);
        public nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess => Tools.LogMethod(() => target.UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess, ArgsBag.Empty);
        public nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess => Tools.LogMethod(() => target.UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess, ArgsBag.Empty);
        public nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess => Tools.LogMethod(() => target.UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess, ArgsBag.Empty);
        public nint GetISteamInventory => Tools.LogMethod(() => target.GetISteamInventory, ArgsBag.Empty);
        public nint GetISteamVideo => Tools.LogMethod(() => target.GetISteamVideo, ArgsBag.Empty);
        public nint GetISteamParentalSettings => Tools.LogMethod(() => target.GetISteamParentalSettings, ArgsBag.Empty);

    }

    /// <inheritdoc />
    public partial class PassThroughWrapper() : ISteamClientVTable
    {
        public nint UnusedCreateSteamPipe => Interop.UnusedCreateSteamPipeReal;
        public nint UnusedBReleaseSteamPipe => Interop.UnusedBReleaseSteamPipeReal;
        public nint UnusedConnectToGlobalUser => Interop.UnusedConnectToGlobalUserReal;
        public nint UnusedCreateLocalUser => Interop.UnusedCreateLocalUserReal;
        public nint UnusedReleaseUser => Interop.UnusedReleaseUserReal;
        public nint GetISteamUser => Interop.GetISteamUserReal;
        public nint UnusedGetISteamGameServer => Interop.UnusedGetISteamGameServerReal;
        public nint UnusedSetLocalIPBinding => Interop.UnusedSetLocalIPBindingReal;
        public nint GetISteamFriends => Interop.GetISteamFriendsReal;
        public nint GetISteamUtils => Interop.GetISteamUtilsReal;
        public nint GetISteamMatchmaking => Interop.GetISteamMatchmakingReal;
        public nint GetISteamMatchmakingServers => Interop.GetISteamMatchmakingServersReal;
        public nint UnusedGetISteamGenericInterface => Interop.UnusedGetISteamGenericInterfaceReal;
        public nint GetISteamUserStats => Interop.GetISteamUserStatsReal;
        public nint UnusedGetISteamGameServerStats => Interop.UnusedGetISteamGameServerStatsReal;
        public nint GetISteamApps(SwApiNet.Wrappers.Models.SteamClient* thisPtr, SwApiNet.Wrappers.Models.HSteamUser user, SwApiNet.Wrappers.Models.HSteamPipe pipe, byte* versionStr) => Interop.GetISteamAppsReal(thisPtr, user, pipe, versionStr);
        public nint GetISteamNetworking => Interop.GetISteamNetworkingReal;
        public nint GetISteamRemoteStorage => Interop.GetISteamRemoteStorageReal;
        public nint GetISteamScreenshots => Interop.GetISteamScreenshotsReal;
        public nint UnusedRunFrame => Interop.UnusedRunFrameReal;
        public nint UnusedGetIPCCallCount => Interop.UnusedGetIPCCallCountReal;
        public nint UnusedSetWarningMessageHook => Interop.UnusedSetWarningMessageHookReal;
        public nint UnusedBShutdownIfAllPipesClosed => Interop.UnusedBShutdownIfAllPipesClosedReal;
        public nint GetISteamHTTP => Interop.GetISteamHTTPReal;
        public nint UnusedDEPRECATED_GetISteamUnifiedMessages => Interop.UnusedDEPRECATED_GetISteamUnifiedMessagesReal;
        public nint GetISteamController => Interop.GetISteamControllerReal;
        public nint GetISteamUGC => Interop.GetISteamUGCReal;
        public nint GetISteamAppList => Interop.GetISteamAppListReal;
        public nint GetISteamMusic => Interop.GetISteamMusicReal;
        public nint GetISteamMusicRemote => Interop.GetISteamMusicRemoteReal;
        public nint GetISteamHTMLSurface => Interop.GetISteamHTMLSurfaceReal;
        public nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess => Interop.UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessReal;
        public nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess => Interop.UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessReal;
        public nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess => Interop.UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessReal;
        public nint GetISteamInventory => Interop.GetISteamInventoryReal;
        public nint GetISteamVideo => Interop.GetISteamVideoReal;
        public nint GetISteamParentalSettings => Interop.GetISteamParentalSettingsReal;

    }

    /// <inheritdoc />
    public partial class InterceptWrapperBase(ISteamClientVTable target) : ISteamClientVTable
    {
        public virtual nint UnusedCreateSteamPipe => target.UnusedCreateSteamPipe;
        public virtual nint UnusedBReleaseSteamPipe => target.UnusedBReleaseSteamPipe;
        public virtual nint UnusedConnectToGlobalUser => target.UnusedConnectToGlobalUser;
        public virtual nint UnusedCreateLocalUser => target.UnusedCreateLocalUser;
        public virtual nint UnusedReleaseUser => target.UnusedReleaseUser;
        public virtual nint GetISteamUser => target.GetISteamUser;
        public virtual nint UnusedGetISteamGameServer => target.UnusedGetISteamGameServer;
        public virtual nint UnusedSetLocalIPBinding => target.UnusedSetLocalIPBinding;
        public virtual nint GetISteamFriends => target.GetISteamFriends;
        public virtual nint GetISteamUtils => target.GetISteamUtils;
        public virtual nint GetISteamMatchmaking => target.GetISteamMatchmaking;
        public virtual nint GetISteamMatchmakingServers => target.GetISteamMatchmakingServers;
        public virtual nint UnusedGetISteamGenericInterface => target.UnusedGetISteamGenericInterface;
        public virtual nint GetISteamUserStats => target.GetISteamUserStats;
        public virtual nint UnusedGetISteamGameServerStats => target.UnusedGetISteamGameServerStats;
        public virtual nint GetISteamApps(SwApiNet.Wrappers.Models.SteamClient* thisPtr, SwApiNet.Wrappers.Models.HSteamUser user, SwApiNet.Wrappers.Models.HSteamPipe pipe, byte* versionStr) => target.GetISteamApps(thisPtr, user, pipe, versionStr);
        public virtual nint GetISteamNetworking => target.GetISteamNetworking;
        public virtual nint GetISteamRemoteStorage => target.GetISteamRemoteStorage;
        public virtual nint GetISteamScreenshots => target.GetISteamScreenshots;
        public virtual nint UnusedRunFrame => target.UnusedRunFrame;
        public virtual nint UnusedGetIPCCallCount => target.UnusedGetIPCCallCount;
        public virtual nint UnusedSetWarningMessageHook => target.UnusedSetWarningMessageHook;
        public virtual nint UnusedBShutdownIfAllPipesClosed => target.UnusedBShutdownIfAllPipesClosed;
        public virtual nint GetISteamHTTP => target.GetISteamHTTP;
        public virtual nint UnusedDEPRECATED_GetISteamUnifiedMessages => target.UnusedDEPRECATED_GetISteamUnifiedMessages;
        public virtual nint GetISteamController => target.GetISteamController;
        public virtual nint GetISteamUGC => target.GetISteamUGC;
        public virtual nint GetISteamAppList => target.GetISteamAppList;
        public virtual nint GetISteamMusic => target.GetISteamMusic;
        public virtual nint GetISteamMusicRemote => target.GetISteamMusicRemote;
        public virtual nint GetISteamHTMLSurface => target.GetISteamHTMLSurface;
        public virtual nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess => target.UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess;
        public virtual nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess => target.UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess;
        public virtual nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess => target.UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess;
        public virtual nint GetISteamInventory => target.GetISteamInventory;
        public virtual nint GetISteamVideo => target.GetISteamVideo;
        public virtual nint GetISteamParentalSettings => target.GetISteamParentalSettings;

    }

    /// <inheritdoc />
    public partial class InterceptWrapper(ISteamClientVTable target) : InterceptWrapperBase(target)
    {
        // write overrides manually here when needed
    }

    /// <summary>
    /// Generated from <see cref="ISteamClientVTable"/>
    /// </summary>
    public static partial class Interop
    {
        public static ISteamClientVTable Target { get; set; } = null!;

        public static nint UnusedCreateSteamPipeReal { get; set; }
        public static nint UnusedBReleaseSteamPipeReal { get; set; }
        public static nint UnusedConnectToGlobalUserReal { get; set; }
        public static nint UnusedCreateLocalUserReal { get; set; }
        public static nint UnusedReleaseUserReal { get; set; }
        public static nint GetISteamUserReal { get; set; }
        public static nint UnusedGetISteamGameServerReal { get; set; }
        public static nint UnusedSetLocalIPBindingReal { get; set; }
        public static nint GetISteamFriendsReal { get; set; }
        public static nint GetISteamUtilsReal { get; set; }
        public static nint GetISteamMatchmakingReal { get; set; }
        public static nint GetISteamMatchmakingServersReal { get; set; }
        public static nint UnusedGetISteamGenericInterfaceReal { get; set; }
        public static nint GetISteamUserStatsReal { get; set; }
        public static nint UnusedGetISteamGameServerStatsReal { get; set; }
        public static delegate* unmanaged[Thiscall]<SwApiNet.Wrappers.Models.SteamClient*, SwApiNet.Wrappers.Models.HSteamUser, SwApiNet.Wrappers.Models.HSteamPipe, byte*, nint> GetISteamAppsReal { get; set; }
        public static nint GetISteamNetworkingReal { get; set; }
        public static nint GetISteamRemoteStorageReal { get; set; }
        public static nint GetISteamScreenshotsReal { get; set; }
        public static nint UnusedRunFrameReal { get; set; }
        public static nint UnusedGetIPCCallCountReal { get; set; }
        public static nint UnusedSetWarningMessageHookReal { get; set; }
        public static nint UnusedBShutdownIfAllPipesClosedReal { get; set; }
        public static nint GetISteamHTTPReal { get; set; }
        public static nint UnusedDEPRECATED_GetISteamUnifiedMessagesReal { get; set; }
        public static nint GetISteamControllerReal { get; set; }
        public static nint GetISteamUGCReal { get; set; }
        public static nint GetISteamAppListReal { get; set; }
        public static nint GetISteamMusicReal { get; set; }
        public static nint GetISteamMusicRemoteReal { get; set; }
        public static nint GetISteamHTMLSurfaceReal { get; set; }
        public static nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessReal { get; set; }
        public static nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessReal { get; set; }
        public static nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessReal { get; set; }
        public static nint GetISteamInventoryReal { get; set; }
        public static nint GetISteamVideoReal { get; set; }
        public static nint GetISteamParentalSettingsReal { get; set; }
        public static nint UnusedCreateSteamPipeFake { get; set; }
        public static nint UnusedBReleaseSteamPipeFake { get; set; }
        public static nint UnusedConnectToGlobalUserFake { get; set; }
        public static nint UnusedCreateLocalUserFake { get; set; }
        public static nint UnusedReleaseUserFake { get; set; }
        public static nint GetISteamUserFake { get; set; }
        public static nint UnusedGetISteamGameServerFake { get; set; }
        public static nint UnusedSetLocalIPBindingFake { get; set; }
        public static nint GetISteamFriendsFake { get; set; }
        public static nint GetISteamUtilsFake { get; set; }
        public static nint GetISteamMatchmakingFake { get; set; }
        public static nint GetISteamMatchmakingServersFake { get; set; }
        public static nint UnusedGetISteamGenericInterfaceFake { get; set; }
        public static nint GetISteamUserStatsFake { get; set; }
        public static nint UnusedGetISteamGameServerStatsFake { get; set; }
        public static nint GetISteamNetworkingFake { get; set; }
        public static nint GetISteamRemoteStorageFake { get; set; }
        public static nint GetISteamScreenshotsFake { get; set; }
        public static nint UnusedRunFrameFake { get; set; }
        public static nint UnusedGetIPCCallCountFake { get; set; }
        public static nint UnusedSetWarningMessageHookFake { get; set; }
        public static nint UnusedBShutdownIfAllPipesClosedFake { get; set; }
        public static nint GetISteamHTTPFake { get; set; }
        public static nint UnusedDEPRECATED_GetISteamUnifiedMessagesFake { get; set; }
        public static nint GetISteamControllerFake { get; set; }
        public static nint GetISteamUGCFake { get; set; }
        public static nint GetISteamAppListFake { get; set; }
        public static nint GetISteamMusicFake { get; set; }
        public static nint GetISteamMusicRemoteFake { get; set; }
        public static nint GetISteamHTMLSurfaceFake { get; set; }
        public static nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcessFake { get; set; }
        public static nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcessFake { get; set; }
        public static nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcessFake { get; set; }
        public static nint GetISteamInventoryFake { get; set; }
        public static nint GetISteamVideoFake { get; set; }
        public static nint GetISteamParentalSettingsFake { get; set; }

        public static delegate* unmanaged[Thiscall]<SwApiNet.Wrappers.Models.SteamClient*, SwApiNet.Wrappers.Models.HSteamUser, SwApiNet.Wrappers.Models.HSteamPipe, byte*, nint> GetISteamAppsFake { get; set; } = &GetISteamAppsExport;

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])] public static nint GetISteamAppsExport(SwApiNet.Wrappers.Models.SteamClient* thisPtr, SwApiNet.Wrappers.Models.HSteamUser user, SwApiNet.Wrappers.Models.HSteamPipe pipe, byte* versionStr) => Target.GetISteamApps(thisPtr, user, pipe, versionStr);

    }
}
