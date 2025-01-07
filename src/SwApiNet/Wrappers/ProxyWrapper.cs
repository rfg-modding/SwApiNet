namespace SwApiNet.Wrappers;

/// <summary>
/// Calls methods from sw_api_original.dll
/// </summary>
public class ProxyWrapper : IWrapper
{
    public nint CreateInternalModule(nint cStringPtr) => Imports.SW_CCSys_CreateInternalModule(cStringPtr);

    public nint DynamicInit(nint callbackCounterAndContextPtr) => Imports.SW_CCSys_DynamicInit(callbackCounterAndContextPtr);

    public nint GetPInterface() => Imports.SW_CCSys_GetPInterface();

    public nint GetUInterface() => Imports.SW_CCSys_GetUInterface();

    public int Init() => Imports.SW_CCSys_Init();

    public nint InitCallbackFunc(nint callbackFuncPtr, int callbackId) => Imports.SW_CCSys_InitCallbackFunc(callbackFuncPtr, callbackId);

    public void ProcessApiCb() => Imports.SW_CCSys_ProcessApiCb();

    public void RegisterCallResult(nint cCallResultPtr, ulong maybeId) => Imports.SW_CCSys_RegisterCallResult(cCallResultPtr, maybeId);

    public void RemoveCallbackFunc(nint callbackFuncPtr) => Imports.SW_CCSys_RemoveCallbackFunc(callbackFuncPtr);

    public void Shutdown() => Imports.SW_CCSys_Shutdown();

    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr) => Imports.SW_CCSys_UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);

    public int ReturnFalse() => 1;
}
