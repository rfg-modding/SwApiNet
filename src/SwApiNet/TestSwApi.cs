using System;

namespace SwApiNet;

/// <summary>
/// Calls methods from sw_api_original.dll with additional logic
/// </summary>
public class TestSwApi : ISwApi
{
    public unsafe int* CreateInternalModule(byte* cStringPtr)
    {
        return RealSwApi.SW_CCSys_CreateInternalModule(cStringPtr);
    }

    public unsafe int* DynamicInit(int* callbackCounterAndContextPtr)
    {
        return RealSwApi.SW_CCSys_DynamicInit(callbackCounterAndContextPtr);
    }

    public unsafe int* GetPInterface()
    {
        return RealSwApi.SW_CCSys_GetPInterface();
    }

    public unsafe int* GetUInterface()
    {
        return RealSwApi.SW_CCSys_GetUInterface();
    }

    public unsafe int Init()
    {
        return RealSwApi.SW_CCSys_Init();
    }

    public unsafe int* InitCallbackFunc(int* callbackFuncPtr, int callbackId)
    {
        return RealSwApi.SW_CCSys_InitCallbackFunc(callbackFuncPtr, callbackId);
    }

    public unsafe void ProcessApiCb()
    {
        RealSwApi.SW_CCSys_ProcessApiCb();
    }

    public unsafe void RegisterCallResult(int* cCallResultPtr, ulong maybeId)
    {
        RealSwApi.SW_CCSys_RegisterCallResult(cCallResultPtr, maybeId);
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public unsafe void RemoveCallbackFunc(int* callbackFuncPtr)
    {
        throw new InvalidOperationException("How did you get here?");
    }

    public unsafe void Shutdown()
    {
        RealSwApi.SW_CCSys_Shutdown();
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public unsafe void UnregisterCallResult(int* cCallResultPtr, int* field1Ptr, int* field2Ptr)
    {
        throw new InvalidOperationException("How did you get here?");
    }

    public unsafe int ReturnFalse()
    {
        return 1;
    }
}
