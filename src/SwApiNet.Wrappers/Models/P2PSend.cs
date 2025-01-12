namespace SwApiNet.Wrappers.Models;

public enum P2PSend
{
    Unreliable = 0,
    UnreliableNoDelay = 1,
    Reliable = 2,
    ReliableWithBuffering = 3
}