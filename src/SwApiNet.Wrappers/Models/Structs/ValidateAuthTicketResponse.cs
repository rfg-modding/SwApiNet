using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ValidateAuthTicketResponse
{
    public CSteamID SteamID{ get; set; }
    public AuthSessionResponse AuthSessionResponse{ get; set; }
    public CSteamID OwnerSteamID{ get; set; }
}