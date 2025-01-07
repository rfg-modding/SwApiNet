namespace SwApiNet.Wrappers;

/// <summary>
/// Logs call details
/// </summary>
/// <param name="target"></param>
public class MethodLogWrapper(IWrapper target) : IWrapper
{
    private readonly bool muteProcessApiCb = true;
    private readonly bool logDynamicInitOnce = true;
    private bool dynamicInitCalled;

    public nint CreateInternalModule(nint cStringPtr)
    {
        Utils.LogMethodBuffered();
        return target.CreateInternalModule(cStringPtr);
    }

    /// <summary>
    /// Log once and avoid spam because real method doesn't do anything after first call
    /// </summary>
    public nint DynamicInit(nint callbackCounterAndContextPtr)
    {
        var skip = logDynamicInitOnce && dynamicInitCalled;
        if (!skip) Utils.LogMethodBuffered();

        dynamicInitCalled = true;
        return target.DynamicInit(callbackCounterAndContextPtr);
    }

    public nint GetPInterface()
    {
        Utils.LogMethodBuffered();
        return target.GetPInterface();
    }

    public nint GetUInterface()
    {
        Utils.LogMethodBuffered();
        return target.GetUInterface();
    }

    public int Init()
    {
        Utils.LogMethodBuffered();
        return target.Init();
    }

    public nint InitCallbackFunc(nint callbackFuncPtr, int callbackId)
    {
        Utils.LogMethodBuffered();
        return target.InitCallbackFunc(callbackFuncPtr, callbackId);
    }

    /// <summary>
    /// Do not log: called every frame
    /// </summary>
    public void ProcessApiCb()
    {
        if (!muteProcessApiCb) Utils.LogMethodBuffered();

        target.ProcessApiCb();
    }

    public void RegisterCallResult(nint cCallResultPtr, ulong maybeId)
    {
        Utils.LogMethodBuffered();
        target.RegisterCallResult(cCallResultPtr, maybeId);
    }

    public void RemoveCallbackFunc(nint callbackFuncPtr)
    {
        Utils.LogMethodBuffered();
        target.RemoveCallbackFunc(callbackFuncPtr);
    }

    public void Shutdown()
    {
        Utils.LogMethodBuffered();
        target.Shutdown();
    }

    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr)
    {
        Utils.LogMethodBuffered();
        target.UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr);
    }

    /// <summary>
    /// Do not log: trivial call
    /// </summary>
    public int ReturnFalse()
    {
        return target.ReturnFalse();
    }
}
