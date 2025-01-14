namespace SwApiNet.Wrappers.Models;

public enum CallbackType
{
    ValidateAuthTicketResponse = 143,
    GetAuthSessionTicketResponse = 163,
    GameLobbyJoinRequested = 333,
    LobbyEnter = 504, //RFG uses this with CCallResult and CCallback
    LobbyDataUpdate = 505,
    LobbyChatUpdate = 506,
    LobbyMatchList = 510, //RFG only uses this with CCallResult
    LobbyCreated = 513, //RFG only uses this with CCallResult
    SteamUserStatsReceived = 1101,
    SteamUserStatsStored = 1102,
    SteamUserAchievementStored = 1103,
    P2PSessionRequest = 1202,
}
