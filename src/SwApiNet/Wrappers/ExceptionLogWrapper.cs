namespace SwApiNet.Wrappers;

/// <summary>
/// Logs CLR exceptions
/// </summary>
public class ExceptionLogWrapper(IWrapper target) : IWrapper
{
    public nint CreateInternalModule(nint cStringPtr) => Utils.TryCatchLog(() => target.CreateInternalModule(cStringPtr));

    /// <summary>
    /// Log once and avoid spam because real method doesn't do anything after first call
    /// </summary>
    public nint DynamicInit(nint callbackCounterAndContextPtr) => Utils.TryCatchLog(() => target.DynamicInit(callbackCounterAndContextPtr));

    public nint GetPInterface() => Utils.TryCatchLog(target.GetPInterface);

    public nint GetUInterface() => Utils.TryCatchLog(target.GetUInterface);

    public int Init() => Utils.TryCatchLog(target.Init);

    public nint InitCallbackFunc(nint callbackFuncPtr, int callbackId) => Utils.TryCatchLog(() => target.InitCallbackFunc(callbackFuncPtr, callbackId));

    /// <summary>
    /// Do not log: called every frame
    /// </summary>
    public void ProcessApiCb() => Utils.TryCatchLog(target.ProcessApiCb);

    public void RegisterCallResult(nint cCallResultPtr, ulong maybeId) => Utils.TryCatchLog(() => target.RegisterCallResult(cCallResultPtr, maybeId));

    public void RemoveCallbackFunc(nint callbackFuncPtr) => Utils.TryCatchLog(() => target.RemoveCallbackFunc(callbackFuncPtr));

    public void Shutdown() => Utils.TryCatchLog(target.Shutdown);

    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr) => Utils.TryCatchLog(() => target.UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr));

    /// <summary>
    /// Do not log: trivial call
    /// </summary>
    public int ReturnFalse() => Utils.TryCatchLog(target.ReturnFalse);
}
