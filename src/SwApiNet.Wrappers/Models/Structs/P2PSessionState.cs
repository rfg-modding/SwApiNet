using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct P2PSessionState
{
    public byte m_bConnectionActive;
    public byte m_bConnecting;
    public byte m_eP2PSessionError;
    public byte m_bUsingRelay;
    public int m_nBytesQueuedForSend;
    public int m_nPacketsQueuedForSend;
    public uint m_nRemoteIP;
    public ushort m_nRemotePort;
}
