using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SwApiNet;

public static unsafe class Exports
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_CreateInternalModule(byte* cStringPtr)
    {
        Utils.LogMethod();
        return RealSwApi.SW_CCSys_CreateInternalModule(cStringPtr);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_DynamicInit(int* callbackCounterAndContextPtr)
    {
        Utils.LogMethod();
        return RealSwApi.SW_CCSys_DynamicInit(callbackCounterAndContextPtr);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_GetPInterface()
    {
        Utils.LogMethod();
        return RealSwApi.SW_CCSys_GetPInterface();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_GetUInterface()
    {
        Utils.LogMethod();
        return RealSwApi.SW_CCSys_GetUInterface();
    }

    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_CCSys_Init()
    {
        Utils.LogMethod();
        return RealSwApi.SW_CCSys_Init();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_InitCallbackFunc(int* callbackFuncPtr, int callbackId)
    {
        Utils.LogMethod();
        return RealSwApi.SW_CCSys_InitCallbackFunc(callbackFuncPtr, callbackId);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_ProcessApiCb()
    {
        Utils.LogMethod();
        RealSwApi.SW_CCSys_ProcessApiCb();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_RegisterCallResult(int* cCallResultPtr, ulong maybeId)
    {
        Utils.LogMethod();
        RealSwApi.SW_CCSys_RegisterCallResult(cCallResultPtr, maybeId);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_RemoveCallbackFunc(int* callbackFuncPtr)
    {
        Utils.LogMethod();
        RealSwApi.SW_CCSys_RemoveCallbackFunc(callbackFuncPtr);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_Shutdown()
    {
        Utils.LogMethod();
        RealSwApi.SW_CCSys_Shutdown();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_UnregisterCallResult(int* cCallResultPtr, int* field1Ptr, int* field2Ptr)
    {
        Utils.LogMethod();
        RealSwApi.SW_CCSys_UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);
    }

    /// <summary>
    /// Can ignore proxying, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasAchievements()
    {
        return 1;
    }

    /// <summary>
    /// Can ignore proxying, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasInvites()
    {
        return 1;
    }

    /// <summary>
    /// Can ignore proxying, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasLeaderboards()
    {
        return 1;
    }
}
