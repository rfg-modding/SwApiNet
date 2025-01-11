using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers.Models;

/// <summary>
/// See <see cref="ISteamClientVTable"/>
/// </summary>
///
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ManualSteamClientVTable //: ISteamClientVTable
{
    public ManualSteamClientVTable(ManualSteamClientVTable* real)
    {
        // can't store directly in the struct, it will affect size
        //Interop.Target = new InterceptWrapper(new LogWrapper(new PassThroughWrapper()));

        // replace fake and real pointers, generate
        Interop.GetISteamAppsReal = real->GetISteamAppsPtr;
        GetISteamAppsPtr = Interop.GetISteamAppsFake;
    }

    // actual fields, generate with Ptr suffix
    public nint UnusedCreateSteamPipe; //UnusedCreateSteamPipe
    public nint UnusedBReleaseSteamPipe;
    public nint UnusedConnectToGlobalUser;
    public nint UnusedCreateLocalUser;
    public nint UnusedReleaseUser;
    public nint GetISteamUser;
    public nint UnusedGetISteamGameServer;
    public nint UnusedSetLocalIPBinding;
    public nint GetISteamFriends;
    public nint GetISteamUtils;
    public nint GetISteamMatchmaking;
    public nint GetISteamMatchmakingServers;
    public nint UnusedGetISteamGenericInterface;
    public nint GetISteamUserStats;
    public nint UnusedGetISteamGameServerStats;
    public delegate* unmanaged[Thiscall]<SteamClient*, HSteamUser, HSteamPipe, byte*, nint> GetISteamAppsPtr;
    public nint GetISteamNetworking;
    public nint GetISteamRemoteStorage;
    public nint GetISteamScreenshots;
    public nint UnusedRunFrame;
    public nint UnusedGetIPCCallCount;
    public nint UnusedSetWarningMessageHook;
    public nint UnusedBShutdownIfAllPipesClosed;
    public nint GetISteamHTTP;
    public nint UnusedDEPRECATED_GetISteamUnifiedMessages;
    public nint GetISteamController;
    public nint GetISteamUGC;
    public nint GetISteamAppList;
    public nint GetISteamMusic;
    public nint GetISteamMusicRemote;
    public nint GetISteamHTMLSurface;
    public nint UnusedDEPRECATED_Set_SteamAPI_CPostAPIResultInProcess;
    public nint UnusedDEPRECATED_Remove_SteamAPI_CPostAPIResultInProcess;
    public nint UnusedSet_SteamAPI_CCheckCallbackRegisteredInProcess;
    public nint GetISteamInventory;
    public nint GetISteamVideo;
    public nint GetISteamParentalSettings;

    // methods to call internally, generate
    public nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr) => Interop.Target.GetISteamApps(thisPtr, user, pipe, versionStr);
    public nint Hello => this.UnusedCreateSteamPipe;


    public class LogWrapper(ISteamClientVTable target) //: ISteamClientVTable
    {
        // log params, generate
        public nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr) => Tools.LogMethod(() => target.GetISteamApps(thisPtr, user, pipe, versionStr), ArgsBag.Init().Add(thisPtr).Add(user).Add(pipe).Add(versionStr));
    }

    public class PassThroughWrapper() //: ISteamClientVTable
    {
        // call real function, generate
        public nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr) => Interop.GetISteamAppsReal(thisPtr, user, pipe, versionStr);
    }

    public class InterceptWrapperBase(ISteamClientVTable target) //: ISteamClientVTable
    {
        // stub method, just passing through, generate
        public virtual nint GetISteamApps(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr) => target.GetISteamApps(thisPtr, user, pipe, versionStr);
    }

    public class InterceptWrapper(ISteamClientVTable target) : InterceptWrapperBase(target)
    {
        // write overrides manually here when needed
    }

    /// <summary>
    /// Pointers passed to rfg.exe to be called externally, all must be static
    /// </summary>
    public static class Interop
    {
        public static ISteamClientVTable Target { get; set; } = null!;

        // pointers, generate
        public static delegate* unmanaged[Thiscall]<SteamClient*, HSteamUser, HSteamPipe, byte*, nint> GetISteamAppsReal { get; set; }
        public static delegate* unmanaged[Thiscall]<SteamClient*, HSteamUser, HSteamPipe, byte*, nint> GetISteamAppsFake { get; set; } = &GetISteamAppsExport;

        // imports, generate
        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])]
        public static nint GetISteamAppsExport(SteamClient* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr) => Target.GetISteamApps(thisPtr, user, pipe, versionStr);
    }
}
