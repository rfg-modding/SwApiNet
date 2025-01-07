namespace SwApiNet;

/// <summary>
/// Logs call details
/// </summary>
/// <param name="target"></param>
public class LogSwApi(ISwApi target) : ISwApi
{
    private readonly bool muteProcessApiCb = true;
    private readonly bool logDynamicInitOnce = true;
    private bool dynamicInitCalled;

    public unsafe int* CreateInternalModule(byte* cStringPtr)
    {
        Utils.LogMethodBuffered();
        return target.CreateInternalModule(cStringPtr);
    }

    /// <summary>
    /// Log once and avoid spam because real method doesn't do anything after first call
    /// </summary>
    public unsafe int* DynamicInit(int* callbackCounterAndContextPtr)
    {
        var skip = logDynamicInitOnce && dynamicInitCalled;
        if (!skip)
        {
            Utils.LogMethodBuffered();
        }

        dynamicInitCalled = true;
        return target.DynamicInit(callbackCounterAndContextPtr);
    }

    public unsafe int* GetPInterface()
    {
        Utils.LogMethodBuffered();
        return target.GetPInterface();
    }

    public unsafe int* GetUInterface()
    {
        Utils.LogMethodBuffered();
        return target.GetUInterface();
    }

    public unsafe int Init()
    {
        Utils.LogMethodBuffered();
        return target.Init();
    }

    public unsafe int* InitCallbackFunc(int* callbackFuncPtr, int callbackId)
    {
        Utils.LogMethodBuffered();
        return target.InitCallbackFunc(callbackFuncPtr, callbackId);
    }

    /// <summary>
    /// Do not log: called every frame
    /// </summary>
    public unsafe void ProcessApiCb()
    {
        if (!muteProcessApiCb)
        {
            Utils.LogMethodBuffered();
        }

        target.ProcessApiCb();
    }

    public unsafe void RegisterCallResult(int* cCallResultPtr, ulong maybeId)
    {
        Utils.LogMethodBuffered();
        target.RegisterCallResult(cCallResultPtr, maybeId);
    }

    public unsafe void RemoveCallbackFunc(int* callbackFuncPtr)
    {
        Utils.LogMethodBuffered();
        target.RemoveCallbackFunc(callbackFuncPtr);
    }

    public unsafe void Shutdown()
    {
        Utils.LogMethodBuffered();
        target.Shutdown();
    }

    public unsafe void UnregisterCallResult(int* cCallResultPtr, int* field1Ptr, int* field2Ptr)
    {
        Utils.LogMethodBuffered();
        target.UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);
    }

    /// <summary>
    /// Do not log: trivial call
    /// </summary>
    public unsafe int ReturnFalse()
    {
        return target.ReturnFalse();
    }
}
