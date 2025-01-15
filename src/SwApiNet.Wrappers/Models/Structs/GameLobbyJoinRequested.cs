using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct GameLobbyJoinRequested
{
    public CSteamID SteamIDLobby{ get; set; }
    public CSteamID SteamIDFriend{ get; set; }
}