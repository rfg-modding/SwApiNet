using SwApiNet.Codegen;
using SwApiNet.Wrappers.Models;

namespace SwApiNet.Wrappers;

[VTableProxy]
public unsafe interface ISteamClientVTable
{
    nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
}