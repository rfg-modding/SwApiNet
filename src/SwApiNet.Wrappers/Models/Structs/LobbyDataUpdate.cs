using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct LobbyDataUpdate
{
    public ulong SteamIDLobby { get; set; }
    public ulong SteamIDMember { get; set; }
    public byte Success { get; set; } // TODO: 1 byte or 4 bytes?
}
