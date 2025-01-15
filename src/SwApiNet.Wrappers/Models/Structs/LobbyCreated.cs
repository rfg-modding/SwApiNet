using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct LobbyCreated
{
    public BackendResult Result{ get; set; }
    public ulong SteamIDLobby{ get; set; } //TODO: Should this be a CSteamID?
}