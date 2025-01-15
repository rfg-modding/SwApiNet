using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Dll;
using SwApiNet.Wrappers.Models;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet;

public static class Exports
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static nint SW_CCSys_CreateInternalModule(nint cStringPtr) => Target.CreateInternalModule(cStringPtr);

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static nint SW_CCSys_DynamicInit(nint callbackCounterAndContextPtr) => Target.DynamicInit(callbackCounterAndContextPtr);

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static nint SW_CCSys_GetPInterface() => Target.GetPInterface();

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static nint SW_CCSys_GetUInterface() => Target.GetUInterface();

    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_CCSys_Init() => Target.Init();

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static nint SW_CCSys_InitCallbackFunc(nint callbackFuncPtr, int callbackId) => Target.InitCallbackFunc(callbackFuncPtr, (CallbackType)callbackId);

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_ProcessApiCb() => Target.ProcessApiCb();

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_RegisterCallResult(nint cCallResultPtr, ulong maybeId) => Target.RegisterCallResult(cCallResultPtr, maybeId);

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_RemoveCallbackFunc(nint callbackFuncPtr) => Target.RemoveCallbackFunc(callbackFuncPtr);

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_Shutdown() => Target.Shutdown();

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr) => Target.UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);

    /// <summary>
    /// Can ignore proxying, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasAchievements() => Target.CFalse();

    /// <summary>
    /// Can ignore proxying, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasInvites() => Target.CFalse();

    /// <summary>
    /// Ignore any logic, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasLeaderboards() => Target.CFalse();

    /// <summary>
    /// Chain of wrappers to call
    /// </summary>
    private static readonly IDllWrapper Target = new DllLogWrapper(new DllInterceptWrapper());
}
