namespace SwApiNet.Wrappers.Models;

public enum BeginAuthSessionResult
{
    OK = 0,
    InvalidTicket = 1,
    DuplicateRequest = 2,
    InvalidVersion = 3,
    GameMismatch = 4,
    ExpiredTicket = 5
}