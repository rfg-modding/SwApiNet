using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

[StructLayout(LayoutKind.Sequential)]
public struct SteamApps
{
    public unsafe SteamAppsVTable* Table;
}
