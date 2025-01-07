namespace SwApiNet;

/// <summary>
/// Calls methods from sw_api_original.dll
/// </summary>
public class ProxySwApi : ISwApi
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

    public unsafe void RemoveCallbackFunc(int* callbackFuncPtr)
    {
        RealSwApi.SW_CCSys_RemoveCallbackFunc(callbackFuncPtr);
    }

    public unsafe void Shutdown()
    {
        RealSwApi.SW_CCSys_Shutdown();
    }

    public unsafe void UnregisterCallResult(int* cCallResultPtr, int* field1Ptr, int* field2Ptr)
    {
        RealSwApi.SW_CCSys_UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);
    }

    public unsafe int ReturnFalse()
    {
        return 1;
    }
}
