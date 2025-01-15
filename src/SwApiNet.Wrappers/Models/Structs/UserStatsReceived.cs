using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct UserStatsReceived
{
    public ulong GameID;
    public BackendResult Result;
    public CSteamID SteamIDUser;
}