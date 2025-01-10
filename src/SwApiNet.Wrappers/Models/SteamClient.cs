using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

public enum HSteamUser;
public enum HSteamPipe;

[StructLayout(LayoutKind.Sequential)]
public struct SteamClient
{
    public unsafe SteamClientVTable* Table;
}
