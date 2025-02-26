using SwApiNet.Wrappers.Models;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Utils;

namespace SwApiNet.Wrappers.Dll;

/// <summary>
/// Logs method call, return and CLR exceptions
/// </summary>
public class DllLogWrapper(IDllWrapper target) : IDllWrapper
{
    private readonly bool muteProcessApiCb = true;
    private readonly bool logDynamicInitOnce = true;
    private bool dynamicInitCalled;

    public nint CreateInternalModule(nint cStringPtr) => LogMethod(() => target.CreateInternalModule(cStringPtr), ArgsBag.Empty, "DLL");

    /// <summary>
    /// Log once and avoid spam because real method doesn't do anything after first call
    /// </summary>
    public nint DynamicInit(nint contextPtr)
    {
        var skip = logDynamicInitOnce && dynamicInitCalled;
        dynamicInitCalled = true;
        var args = ArgsBag.Init(contextPtr);
        return LogMethod(() => target.DynamicInit(contextPtr), args, "DLL", skip);
    }

    public nint GetPInterface() => LogMethod(target.GetPInterface, ArgsBag.Empty, "DLL");

    public nint GetUInterface() => LogMethod(target.GetUInterface, ArgsBag.Empty, "DLL");

    public int Init() => LogMethod(target.Init, ArgsBag.Empty, "DLL");

    public nint InitCallbackFunc(nint callPtr, CallbackType type) => LogMethod(() => target.InitCallbackFunc(callPtr, type), ArgsBag.Init(callPtr, type), "DLL");

    /// <summary>
    /// Do not log: called every frame
    /// </summary>
    public void ProcessApiCb() => LogMethod(target.ProcessApiCb, ArgsBag.Empty, "DLL", muteProcessApiCb);

    public void RegisterCallResult(nint callResultPtr, ulong maybeId) => LogMethod(() => target.RegisterCallResult(callResultPtr, maybeId), ArgsBag.Init(callResultPtr, maybeId), "DLL");

    public void RemoveCallbackFunc(nint callbackFuncPtr) => LogMethod(() => target.RemoveCallbackFunc(callbackFuncPtr), ArgsBag.Init(callbackFuncPtr), "DLL");

    public void Shutdown() => LogMethod(target.Shutdown, ArgsBag.Empty, "DLL");

    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr) => LogMethod(() => target.UnregisterCallResult(cCallResultPtr, field1Ptr, field2Ptr), ArgsBag.Init(cCallResultPtr, field1Ptr, field2Ptr), "DLL");

    /// <summary>
    /// Do not log: trivial call
    /// </summary>
    public int CFalse() => target.CFalse();
}
