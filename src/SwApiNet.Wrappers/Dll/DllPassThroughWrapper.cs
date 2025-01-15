using SwApiNet.Wrappers.Models;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Dll;

/// <summary>
/// Calls methods from sw_api_original.dll
/// </summary>
public unsafe class DllPassThroughWrapper : IDllWrapper
{
    public nint CreateInternalModule(nint cStringPtr) => (nint)Imports.SW_CCSys_CreateInternalModule(cStringPtr);

    public nint DynamicInit(nint contextPtr) => Imports.SW_CCSys_DynamicInit(contextPtr);

    public nint GetPInterface() => Imports.SW_CCSys_GetPInterface();

    public nint GetUInterface() => Imports.SW_CCSys_GetUInterface();

    public int Init() => Imports.SW_CCSys_Init();

    public nint InitCallbackFunc(nint callPtr, CallbackType type) => Imports.SW_CCSys_InitCallbackFunc(callPtr, type);

    public void ProcessApiCb() => Imports.SW_CCSys_ProcessApiCb();

    public void RegisterCallResult(nint callResultPtr, ulong maybeId) => Imports.SW_CCSys_RegisterCallResult(callResultPtr, maybeId);

    public void RemoveCallbackFunc(nint callbackFuncPtr) => Imports.SW_CCSys_RemoveCallbackFunc(callbackFuncPtr);

    public void Shutdown() => Imports.SW_CCSys_Shutdown();

    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr) => Imports.SW_CCSys_UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);

    public int CFalse() => Tools.CFalse;
}
