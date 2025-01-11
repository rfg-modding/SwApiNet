using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

[StructLayout(LayoutKind.Sequential)]
public struct SteamClient
{
    public unsafe ManualSteamClientVTable* Table;
}
