namespace SwApiNet.Wrappers.Dll;

public interface IDllWrapper
{
    nint CreateInternalModule(nint cStringPtr);

    nint DynamicInit(nint callbackCounterAndContextPtr);

    nint GetPInterface();

    nint GetUInterface();

    /// <returns>bool is not blittable, have to return int</returns>
    int Init();

    nint InitCallbackFunc(nint callbackFuncPtr, int callbackId);

    void ProcessApiCb();


    void RegisterCallResult(nint cCallResultPtr, ulong maybeId);


    void RemoveCallbackFunc(nint callbackFuncPtr);


    void Shutdown();


    void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr);

    /// <summary>
    /// Ignore any logic, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    int CFalse();
}
