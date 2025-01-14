using SwApiNet.Codegen;

namespace SwApiNet.Wrappers.Models.Steam;

[VTableProxy]
public unsafe interface ISteamMatchmakingVTable
{
    int GetFavoriteGameCount(SteamMatchmaking* thisPtr);
    int GetFavoriteGame(SteamMatchmaking* thisPtr, int iGame, AppId* pnAppID, uint* pnIP, ushort* pnConnPort, ushort* pnQueryPort, uint* punFlags, uint* pRTimeLastPlayedOnServer);
    int AddFavoriteGame(SteamMatchmaking* thisPtr, AppId nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTimeLastPlayedOnServer);
    int RemoveFavoriteGame(SteamMatchmaking* thisPtr, AppId nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags);
    SteamAPICall RequestLobbyList(SteamMatchmaking* thisPtr);
    void AddRequestLobbyListStringFilter(SteamMatchmaking* thisPtr, byte* pchKeyToMatch, byte* pchValueToMatch, LobbyComparison eComparisonType);
    void AddRequestLobbyListNumericalFilter(SteamMatchmaking* thisPtr, byte* pchKeyToMatch, int nValueToMatch, LobbyComparison eComparisonType);
    void AddRequestLobbyListNearValueFilter(SteamMatchmaking* thisPtr, byte* pchKeyToMatch, int nValueToBeCloseTo);
    void AddRequestLobbyListFilterSlotsAvailable(SteamMatchmaking* thisPtr, int nSlotsAvailable);
    void AddRequestLobbyListDistanceFilter(SteamMatchmaking* thisPtr, LobbyDistanceFilter eLobbyDistanceFilter);
    void AddRequestLobbyListResultCountFilter(SteamMatchmaking* thisPtr, int cMaxResults);
    void AddRequestLobbyListCompatibleMembersFilter(SteamMatchmaking* thisPtr, CSteamID steamIDLobby);
    nint GetLobbyByIndex(SteamMatchmaking* thisPtr, CSteamID* __return, int nLobby);
    SteamAPICall CreateLobby(SteamMatchmaking* thisPtr, LobbyType eLobbyType, int cMaxMembers);
    SteamAPICall JoinLobby(SteamMatchmaking* thisPtr, CSteamID steamIDLobby);
    void LeaveLobby(SteamMatchmaking* thisPtr, CSteamID steamIDLobby);
    int InviteUserToLobby(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, CSteamID steamIDInvitee);
    int GetNumLobbyMembers(SteamMatchmaking* thisPtr, CSteamID steamIDLobby);
    CSteamID GetLobbyMemberByIndex(SteamMatchmaking* thisPtr, CSteamID* __return, CSteamID steamIDLobby, int iMember);
    /// <returns>byte*</returns>
    nint GetLobbyData(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, byte* pchKey);
    int SetLobbyData(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, byte* pchKey, byte* pchValue);
    int GetLobbyDataCount(SteamMatchmaking* thisPtr, CSteamID steamIDLobby);
    int GetLobbyDataByIndex(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, int iLobbyData, byte* pchKey, int cchKeyBufferSize, byte* pchValue, int cchValueBufferSize);
    int DeleteLobbyData(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, byte* pchKey);
    /// <returns>byte*</returns>
    nint GetLobbyMemberData(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, CSteamID steamIDUser, byte* pchKey);
    void SetLobbyMemberData(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, byte* pchKey, byte* pchValue);
    int SendLobbyChatMsg(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, void* pvMsgBody, int cubMsgBody);
    int GetLobbyChatEntry(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, int iChatID, CSteamID* pSteamIDUser, void* pvData, int cubData, ChatEntryType* peChatEntryType);
    int RequestLobbyData(SteamMatchmaking* thisPtr, CSteamID steamIDLobby);
    void SetLobbyGameServer(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, uint unGameServerIP, ushort unGameServerPort, CSteamID steamIDGameServer);
    int GetLobbyGameServer(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, uint* punGameServerIP, ushort* punGameServerPort, CSteamID* psteamIDGameServer);
    int SetLobbyMemberLimit(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, int cMaxMembers);
    int GetLobbyMemberLimit(SteamMatchmaking* thisPtr, CSteamID steamIDLobby);
    int SetLobbyType(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, LobbyType eLobbyType);
    int SetLobbyJoinable(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, int bLobbyJoinable);
    CSteamID GetLobbyOwner(SteamMatchmaking* thisPtr, CSteamID* __return, CSteamID steamIDLobby);
    int SetLobbyOwner(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, CSteamID steamIDNewOwner);
    int SetLinkedLobby(SteamMatchmaking* thisPtr, CSteamID steamIDLobby, CSteamID steamIDLobbyDependent);
}
