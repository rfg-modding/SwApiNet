using SwApiNet.Wrappers.Models;
using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Dll;

public interface IDllWrapper
{
    nint CreateInternalModule(nint cStringPtr);

    nint DynamicInit(nint contextPtr);

    nint GetPInterface();

    nint GetUInterface();

    /// <returns>bool is not blittable, have to return int</returns>
    int Init();

    nint InitCallbackFunc(nint callPtr, CallbackType type);

    void ProcessApiCb();


    void RegisterCallResult(nint callResultPtr, ulong maybeId);


    void RemoveCallbackFunc(nint callbackFuncPtr);


    void Shutdown();


    void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr);

    /// <summary>
    /// Ignore any logic, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    int CFalse();
}
