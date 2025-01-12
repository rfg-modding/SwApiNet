using SwApiNet.Codegen;

namespace SwApiNet.Wrappers.Models;

[VTableProxy]
public unsafe interface ISteamAppsVTable
{
    int BIsSubscribed(SteamApps* thisPtr);
    int BIsLowViolence(SteamApps* thisPtr);
    int BIsCybercafe(SteamApps* thisPtr);
    int BIsVACBanned(SteamApps* thisPtr);
    /// <returns>char*</returns>
    nint GetCurrentGameLanguage(SteamApps* thisPtr);
    /// <returns>char*</returns>
    nint GetAvailableGameLanguages(SteamApps* thisPtr);
    int BIsSubscribedApp(SteamApps* thisPtr, AppId appID);
    int BIsDlcInstalled(SteamApps* thisPtr, AppId appID);
    uint GetEarliestPurchaseUnixTime(SteamApps* thisPtr, AppId appID);
    int BIsSubscribedFromFreeWeekend(SteamApps* thisPtr);
    int GetDLCCount(SteamApps* thisPtr);
    int BGetDLCDataByIndex(SteamApps* thisPtr, int iDLC, AppId* pAppID, int* pbAvailable, byte* pchName, int cchNameBufferSize);
    void InstallDLC(SteamApps* thisPtr, AppId nAppID);
    void UninstallDLC(SteamApps* thisPtr, AppId nAppID);
    void RequestAppProofOfPurchaseKey(SteamApps* thisPtr, AppId nAppID);
    int GetCurrentBetaName(SteamApps* thisPtr, byte* pchName, int cchNameBufferSize);
    int MarkContentCorrupt(SteamApps* thisPtr, int bMissingFilesOnly);
    uint GetInstalledDepots(SteamApps* thisPtr, AppId appID, DepotId* pvecDepots, uint cMaxDepots);
    uint GetAppInstallDir(SteamApps* thisPtr, AppId appID, byte* pchFolder, uint cchFolderBufferSize);
    int BIsAppInstalled(SteamApps* thisPtr, AppId appID);
    CSteamID GetAppOwner(SteamApps* thisPtr, CSteamID* __return);
    /// <returns>char*</returns>
    nint GetLaunchQueryParam(SteamApps* thisPtr, byte* pchKey);
    int GetDlcDownloadProgress(SteamApps* thisPtr, AppId nAppID, ulong* punBytesDownloaded, ulong* punBytesTotal);
    int GetAppBuildId(SteamApps* thisPtr);
    void RequestAllProofOfPurchaseKeys(SteamApps* thisPtr);
    SteamAPICall GetFileDetails(SteamApps* thisPtr, byte* pszFileName);
}
