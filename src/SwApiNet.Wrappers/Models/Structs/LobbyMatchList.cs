using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct LobbyMatchList
{
    public uint NumLobbiesMatching{ get; set; }
}