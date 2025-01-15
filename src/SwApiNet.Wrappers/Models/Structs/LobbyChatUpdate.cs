using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct LobbyChatUpdate
{
    public ulong SteamIDLobby{ get; set; }
    public ulong SteamIDUserChanged{ get; set; }
    public ulong SteamIDMakingChange{ get; set; }
    public ulong ChatMemberStateChange{ get; set; }
}