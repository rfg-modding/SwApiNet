namespace SwApiNet.Wrappers.Models.Enums;

public enum CallbackType
{
    ValidateAuthTicketResponse = 143, // not initialized at InitCb
    GetAuthSessionTicketResponse = 163,
    GameLobbyJoinRequested = 333,
    LobbyEnter = 504, //RFG uses this with CCallResult and CCallback
    LobbyDataUpdate = 505,
    LobbyChatUpdate = 506,
    LobbyMatchList = 510, //RFG only uses this with CCallResult. not initialized at InitCb
    LobbyCreated = 513, //RFG only uses this with CCallResult. not initialized at InitCb
    SteamUserStatsReceived = 1101, // InitCb gets called twice for this
    SteamUserStatsStored = 1102, // InitCb gets called twice for this
    SteamUserAchievementStored = 1103,
    P2PSessionRequest = 1202,
}
