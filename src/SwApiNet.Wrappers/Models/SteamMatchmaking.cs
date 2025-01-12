using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

[StructLayout(LayoutKind.Sequential)]
public struct SteamMatchmaking
{
    public unsafe SteamMatchmakingVTable* Table;
}
