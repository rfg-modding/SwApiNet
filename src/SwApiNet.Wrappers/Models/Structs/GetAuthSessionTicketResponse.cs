using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct GetAuthSessionTicketResponse
{
    public uint AuthTicket{ get; set; }
    public BackendResult Result{ get; set; }
}