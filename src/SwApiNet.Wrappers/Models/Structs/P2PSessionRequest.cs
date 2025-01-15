using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct P2PSessionRequest
{
    public CSteamID SteamIDRemote{ get; set; }
}