using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

[StructLayout(LayoutKind.Sequential)]
public struct SteamNetworking
{
    public unsafe SteamNetworkingVTable* Table;
}