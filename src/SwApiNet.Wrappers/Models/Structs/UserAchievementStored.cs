using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct UserAchievementStored
{
    public ulong GameID { get; set; }
    public byte GroupAchievement { get; set; } // TODO was bool. byte or int?

    /*
    public char8[128] AchievementName;
    for a fixed size array in a struct, recommended way is marshaling attributes - they probably won't work
    because C# arrays have managed overhead, and we're not doing marshaling, we're casting raw pointers directly.
    so let's try a dumb thing instead and read a string out of it later if needed:
    */
    public ulong Filler0 { get; set; }
    public ulong Filler1 { get; set; }
    public ulong Filler2 { get; set; }
    public ulong Filler3 { get; set; }
    public ulong Filler4 { get; set; }
    public ulong Filler5 { get; set; }
    public ulong Filler6 { get; set; }
    public ulong Filler7 { get; set; }
    public ulong Filler8 { get; set; }
    public ulong Filler9 { get; set; }
    public ulong Filler10 { get; set; }
    public ulong Filler11 { get; set; }
    public ulong Filler12 { get; set; }
    public ulong Filler13 { get; set; }
    public ulong Filler14 { get; set; }
    public ulong Filler15 { get; set; }

    public uint CurProgress { get; set; }
    public uint MaxProgress { get; set; }
}