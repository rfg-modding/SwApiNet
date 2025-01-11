namespace SwApiNet.Wrappers.Models;

public partial struct SteamClientVTable
{
    partial class InterceptWrapper{
        private readonly CallCountGuard countGuard = new();

        public override unsafe IntPtr GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr)
        {
            countGuard.Check(1);
            return base.GetISteamApps(thisPtr, user, pipe, versionStr);
        }

        // override any methods here. by default they are called in a chain: intercept -> log -> passthrough to real
        // properties are useful only for C#-to-C# calls. they can't be wired because they represent just a value in a struct field, not a function pointer

    }
}
