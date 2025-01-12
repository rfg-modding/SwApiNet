namespace SwApiNet.Wrappers.Dll;

/// <summary>
/// Logs method call, return and CLR exceptions
/// </summary>
public class DllLogWrapper(IDllWrapper target) : IDllWrapper
{
    private readonly bool muteProcessApiCb = true;
    private readonly bool logDynamicInitOnce = true;
    private bool dynamicInitCalled;

    public nint CreateInternalModule(nint cStringPtr) => Tools.LogMethod(() => target.CreateInternalModule(cStringPtr), ArgsBag.Empty, "DLL");

    /// <summary>
    /// Log once and avoid spam because real method doesn't do anything after first call
    /// </summary>
    public nint DynamicInit(nint callbackCounterAndContextPtr)
    {
        var skip = logDynamicInitOnce && dynamicInitCalled;
        dynamicInitCalled = true;
        var args = ArgsBag.Init(callbackCounterAndContextPtr);
        return Tools.LogMethod(() => target.DynamicInit(callbackCounterAndContextPtr), args, "DLL", skip);
    }

    public nint GetPInterface() => Tools.LogMethod(target.GetPInterface, ArgsBag.Empty, "DLL");

    public nint GetUInterface() => Tools.LogMethod(target.GetUInterface, ArgsBag.Empty, "DLL");

    public int Init() => Tools.LogMethod(target.Init, ArgsBag.Empty, "DLL");

    public nint InitCallbackFunc(nint callbackFuncPtr, int callbackId) => Tools.LogMethod(() => target.InitCallbackFunc(callbackFuncPtr, callbackId), ArgsBag.Init(callbackFuncPtr, callbackId), "DLL");

    /// <summary>
    /// Do not log: called every frame
    /// </summary>
    public void ProcessApiCb() => Tools.LogMethod(target.ProcessApiCb, ArgsBag.Empty, "DLL", muteProcessApiCb);

    public void RegisterCallResult(nint cCallResultPtr, ulong maybeId) => Tools.LogMethod(() => target.RegisterCallResult(cCallResultPtr, maybeId), ArgsBag.Init(cCallResultPtr, maybeId), "DLL");

    public void RemoveCallbackFunc(nint callbackFuncPtr) => Tools.LogMethod(() => target.RemoveCallbackFunc(callbackFuncPtr), ArgsBag.Init(callbackFuncPtr), "DLL");

    public void Shutdown() => Tools.LogMethod(target.Shutdown, ArgsBag.Empty, "DLL");

    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr) => Tools.LogMethod(() => target.UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr), ArgsBag.Init(cCallResultPtr, field1Ptr, field2Ptr), "DLL");

    /// <summary>
    /// Do not log: trivial call
    /// </summary>
    public int CFalse() => target.CFalse();
}
