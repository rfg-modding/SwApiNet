using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

[StructLayout(LayoutKind.Sequential)]
public struct SteamUser
{
    public unsafe SteamUserVTable* Table;
}
