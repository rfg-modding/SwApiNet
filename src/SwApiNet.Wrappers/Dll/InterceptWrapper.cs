using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models;

namespace SwApiNet.Wrappers.Dll ;

/// <summary>
/// Calls methods from sw_api_original.dll with additional logic
/// </summary>
public unsafe class InterceptWrapper : IWrapper
{
    private readonly CallCountGuard countGuard = new();

    public nint CreateInternalModule(nint cStringPtr)
    {
        countGuard.Check(1);
        var steamClientDll = Imports.SW_CCSys_CreateInternalModule(cStringPtr);

        // allocate unmanaged memory. VTables are static and can be cached forever, no freeing required
        SteamClient* fake = (SteamClient*)Marshal.AllocHGlobal(sizeof(SteamClient));
        fake->Table = (SteamClientVTable*) Marshal.AllocHGlobal(sizeof(SteamClientVTable));

        Marshal.StructureToPtr(new SteamClientVTable(steamClientDll->Table), (nint)fake->Table, true);
        //return (nint)fake;

        //SteamClientVTable.Interop.Target = new SteamClientVTable.InterceptWrapper(new SteamClientVTable.LogWrapper(new SteamClientVTable.PassThroughWrapper()));
        //SteamClientVTable.Interop.GetISteamAppsReal = real->GetISteamApps;
        //SteamClientVTable.GetISteamAppsPtr = Interop.GetISteamAppsFake;

        // apparently some functions are not used and can be zeroed
        fake->Table->UnusedCreateSteamPipe = 0;
        fake->Table->UnusedBReleaseSteamPipe = 0;
        fake->Table->UnusedConnectToGlobalUser = 0;
        fake->Table->UnusedCreateLocalUser = 0;
        fake->Table->UnusedReleaseUser = 0;
        fake->Table->GetISteamUser = steamClientDll->Table->GetISteamUser;
        fake->Table->UnusedGetISteamGameServer = 0;
        fake->Table->UnusedSetLocalIPBinding = 0;
        fake->Table->GetISteamFriends = steamClientDll->Table->GetISteamFriends;
        fake->Table->GetISteamUtils = steamClientDll->Table->GetISteamUtils;
        fake->Table->GetISteamMatchmaking = steamClientDll->Table->GetISteamMatchmaking;
        fake->Table->GetISteamMatchmakingServers = steamClientDll->Table->GetISteamMatchmakingServers;
        fake->Table->UnusedGetISteamGenericInterface = 0;
        fake->Table->GetISteamUserStats = steamClientDll->Table->GetISteamUserStats;
        fake->Table->UnusedGetISteamGameServerStats = 0;
        //fake->Table->GetISteamAppsPtr = steamClientDll->Table->GetISteamAppsPtr;
        fake->Table->GetISteamNetworking = steamClientDll->Table->GetISteamNetworking;
        fake->Table->GetISteamRemoteStorage = steamClientDll->Table->GetISteamRemoteStorage;
        fake->Table->GetISteamScreenshots = steamClientDll->Table->GetISteamScreenshots;
        fake->Table->UnusedRunFrame = 0;
        fake->Table->UnusedGetIPCCallCount = 0;
        fake->Table->UnusedSetWarningMessageHook = 0;
        fake->Table->UnusedBShutdownIfAllPipesClosed = 0;
        fake->Table->GetISteamHTTP = steamClientDll->Table->GetISteamHTTP;
        fake->Table->UnusedDEPRECATED_GetISteamUnifiedMessages = 0;
        fake->Table->GetISteamController = steamClientDll->Table->GetISteamController;
        fake->Table->GetISteamUGC = steamClientDll->Table->GetISteamUGC;
        fake->Table->GetISteamAppList = steamClientDll->Table->GetISteamAppList;
        fake->Table->GetISteamMusic = steamClientDll->Table->GetISteamMusic;
        fake->Table->GetISteamMusicRemote = steamClientDll->Table->GetISteamMusicRemote;
        fake->Table->GetISteamHTMLSurface = steamClientDll->Table->GetISteamHTMLSurface;
        fake->Table->UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess = 0;
        fake->Table->UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess = 0;
        fake->Table->UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess = 0;
        fake->Table->GetISteamInventory = steamClientDll->Table->GetISteamInventory;
        fake->Table->GetISteamVideo = steamClientDll->Table->GetISteamVideo;
        fake->Table->GetISteamParentalSettings = steamClientDll->Table->GetISteamParentalSettings;

        // initialize proxy function
        //GetISteamAppsExport.Init(steamClientDll, fake);

        return (nint)fake;

    }

    /// <summary>
    /// Gets called a lot
    /// </summary>
    public nint DynamicInit(nint callbackCounterAndContextPtr)
    {
        // TODO cache result and return it
        return Imports.SW_CCSys_DynamicInit(callbackCounterAndContextPtr);
    }

    public nint GetPInterface()
    {
        countGuard.Check(2);
        return CFalse();
    }

    public nint GetUInterface()
    {
        countGuard.Check(1);
        return CFalse();
    }

    public int Init()
    {
        countGuard.Check(1);
        return Imports.SW_CCSys_Init();
    }

    public nint InitCallbackFunc(nint callbackFuncPtr, int callbackId)
    {
        countGuard.Check(12); // todo on restart match?
        return Imports.SW_CCSys_InitCallbackFunc(callbackFuncPtr, callbackId);
    }

    /// <summary>
    /// Gets called a lot
    /// </summary>
    public void ProcessApiCb()
    {
        Imports.SW_CCSys_ProcessApiCb();
    }

    /// <summary>
    /// Gets called when entering "custom match with party"
    /// </summary>
    public void RegisterCallResult(nint cCallResultPtr, ulong maybeId)
    {
        Imports.SW_CCSys_RegisterCallResult(cCallResultPtr, maybeId);
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public void RemoveCallbackFunc(nint callbackFuncPtr)
    {
        throw new InvalidOperationException("How did you get here?");
    }

    public void Shutdown()
    {
        countGuard.Check(1);
        Imports.SW_CCSys_Shutdown();
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr)
    {
        throw new InvalidOperationException("How did you get here?");
    }

    public int CFalse()
    {
        return 1;
    }
}
