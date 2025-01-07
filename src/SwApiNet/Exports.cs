using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SwApiNet;

public static unsafe class Exports
{
    private static readonly ISwApi Target = new LogSwApi(new TestSwApi());

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_CreateInternalModule(byte* cStringPtr)
    {
        return Target.CreateInternalModule(cStringPtr);

    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_DynamicInit(int* callbackCounterAndContextPtr)
    {
        return Target.DynamicInit(callbackCounterAndContextPtr);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_GetPInterface()
    {
        return Target.GetPInterface();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_GetUInterface()
    {
        return Target.GetUInterface();


    }

    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_CCSys_Init()
    {
        return Target.Init();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int* SW_CCSys_InitCallbackFunc(int* callbackFuncPtr, int callbackId)
    {
        return Target.InitCallbackFunc(callbackFuncPtr, callbackId);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_ProcessApiCb()
    {
        Target.ProcessApiCb();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_RegisterCallResult(int* cCallResultPtr, ulong maybeId)
    {
        Target.RegisterCallResult(cCallResultPtr, maybeId);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_RemoveCallbackFunc(int* callbackFuncPtr)
    {
        Target.RemoveCallbackFunc(callbackFuncPtr);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_Shutdown()
    {
       Target.Shutdown();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void SW_CCSys_UnregisterCallResult(int* cCallResultPtr, int* field1Ptr, int* field2Ptr)
    {
        Target.UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);
    }

    /// <summary>
    /// Can ignore proxying, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasAchievements()
    {
        return Target.ReturnFalse();
    }

    /// <summary>
    /// Can ignore proxying, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasInvites()
    {
        return Target.ReturnFalse();
    }

    /// <summary>
    /// Ignore any logic, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static int SW_HasLeaderboards()
    {
        return Target.ReturnFalse();
    }
}
