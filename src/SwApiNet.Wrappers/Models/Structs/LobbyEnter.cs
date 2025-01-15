using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct LobbyEnter
{
    public ulong SteamIDLobby { get; set; } //TODO: Should this be a CSteamID?
    public uint ChatPermissions { get; set; }
    public byte Blocked { get; set; } //TODO: Is this really a bool, or a u8? Naming scheme in rfg.exe indicates its a bool, but the debugger shows it being set to some strange values like 13 (would've expected 255 for true and 0 for false)
    public uint ChatRoomEnterResponse { get; set; } //Likely an enum
}
