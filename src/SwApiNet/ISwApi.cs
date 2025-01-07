namespace SwApiNet;

public interface ISwApi
{
    unsafe int* CreateInternalModule(byte* cStringPtr);

    unsafe int* DynamicInit(int* callbackCounterAndContextPtr);

    unsafe int* GetPInterface();

    unsafe int* GetUInterface();

    /// <returns>bool is not blittable, have to return int</returns>
    unsafe int Init();

    unsafe int* InitCallbackFunc(int* callbackFuncPtr, int callbackId);

    unsafe void ProcessApiCb();


    unsafe void RegisterCallResult(int* cCallResultPtr, ulong maybeId);


    unsafe void RemoveCallbackFunc(int* callbackFuncPtr);


    unsafe void Shutdown();


    unsafe void UnregisterCallResult(int* cCallResultPtr, int* field1Ptr, int* field2Ptr);

    /// <summary>
    /// Ignore any logic, just return false
    /// </summary>
    /// <returns>bool is not blittable, have to return int</returns>
    unsafe int ReturnFalse();
}
