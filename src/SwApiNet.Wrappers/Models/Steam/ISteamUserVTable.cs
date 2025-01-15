using SwApiNet.Codegen;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Steam;

[StaticVTableProxy]
public unsafe interface ISteamUserVTable
{
    HSteamUser SW_CCSys_GetU(SteamUser* thisPtr);
    /// <summary>
    /// Returns bogus value as bool - probably false
    /// </summary>
    int BLoggedOn(SteamUser* thisPtr);
    /// <summary>
    /// Spams a lot, but returns the same value every time
    /// </summary>
    /// <returns>CSteamId* and sets value to __return ptr</returns>
    nint GetSteamID(SteamUser* thisPtr, CSteamID* __return);
    int InitiateGameConnection(SteamUser* thisPtr, void* pAuthBlob, int cbMaxAuthBlob, CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer, int bSecure);
    void TerminateGameConnection(SteamUser* thisPtr, uint unIPServer, ushort usPortServer);
    void TrackAppUsageEvent(SteamUser* thisPtr, CGameId gameID, int eAppUsageEvent, byte* pchExtraInfo);
    int GetUserDataFolder(SteamUser* thisPtr, byte* pchBuffer, int cubBuffer);
    void StartVoiceRecording(SteamUser* thisPtr);
    void StopVoiceRecording(SteamUser* thisPtr);
    VoiceResult GetAvailableVoice(SteamUser* thisPtr, uint* pcbCompressed, uint* pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated);
    VoiceResult GetVoice(SteamUser* thisPtr, int bWantCompressed, void* pDestBuffer, uint cbDestBufferSize, uint* nBytesWritten, int bWantUncompressed_Deprecated, void* pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, uint* nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated);
    VoiceResult DecompressVoice(SteamUser* thisPtr, void* pCompressed, uint cbCompressed, void* pDestBuffer, uint cbDestBufferSize, uint* nBytesWritten, uint nDesiredSampleRate);
    uint GetVoiceOptimalSampleRate(SteamUser* thisPtr);
    HAuthTicket GetAuthSessionTicket(SteamUser* thisPtr, void* pTicket, int cbMaxTicket, uint* pcbTicket);
    BeginAuthSessionResult BeginAuthSession(SteamUser* thisPtr, void* pAuthTicket, int cbAuthTicket, CSteamID steamID);
    void EndAuthSession(SteamUser* thisPtr, CSteamID steamID);
    void CancelAuthTicket(SteamUser* thisPtr, HAuthTicket hAuthTicket);
    UserHasLicenseForAppResult UserHasLicenseForApp(SteamUser* thisPtr, CSteamID steamID, AppId appId);
    int BIsBehindNAT(SteamUser* thisPtr);
    void AdvertiseGame(SteamUser* thisPtr, CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer);
    SteamAPICall RequestEncryptedAppTicket(SteamUser* thisPtr, void* pDataToInclude, int cbDataToInclude);
    int GetEncryptedAppTicket(SteamUser* thisPtr, void* pTicket, int cbMaxTicket, uint* pcbTicket);
    int GetGameBadgeLevel(SteamUser* thisPtr, int nSeries, int bFoil);
    int GetPlayerSteamLevel(SteamUser* thisPtr);
    SteamAPICall RequestStoreAuthURL(SteamUser* thisPtr, byte* pchRedirectURL);
    int BIsPhoneVerified(SteamUser* thisPtr);
    int BIsTwoFactorEnabled(SteamUser* thisPtr);
    int BIsPhoneIdentifying(SteamUser* thisPtr);
    int BIsPhoneRequiringVerification(SteamUser* thisPtr);
}
