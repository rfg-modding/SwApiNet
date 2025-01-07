using System;
using System.Runtime.InteropServices;

namespace SwApiNet.Wrappers;

/// <summary>
/// Calls methods from sw_api_original.dll with additional logic
/// </summary>
public class TestWrapper : IWrapper
{
    public nint CreateInternalModule(nint cStringPtr)
    {
        var ptr = new nint(cStringPtr);
        var str = Marshal.PtrToStringAnsi(ptr);
        Utils.Log(str);
        return Imports.SW_CCSys_CreateInternalModule(cStringPtr);
    }

    public nint DynamicInit(nint callbackCounterAndContextPtr)
    {
        return Imports.SW_CCSys_DynamicInit(callbackCounterAndContextPtr);
    }

    public nint GetPInterface()
    {
        return Imports.SW_CCSys_GetPInterface();
    }

    public nint GetUInterface()
    {
        return Imports.SW_CCSys_GetUInterface();
    }

    public int Init()
    {
        return Imports.SW_CCSys_Init();
    }

    public nint InitCallbackFunc(nint callbackFuncPtr, int callbackId)
    {
        return Imports.SW_CCSys_InitCallbackFunc(callbackFuncPtr, callbackId);
    }

    public void ProcessApiCb()
    {
        Imports.SW_CCSys_ProcessApiCb();
    }

    public void RegisterCallResult(nint cCallResultPtr, ulong maybeId)
    {
        Imports.SW_CCSys_RegisterCallResult(cCallResultPtr, maybeId);
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public void RemoveCallbackFunc(nint callbackFuncPtr)
    {
        throw new InvalidOperationException("How did you get here?");
    }

    public void Shutdown()
    {
        Imports.SW_CCSys_Shutdown();
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr)
    {
        throw new InvalidOperationException("How did you get here?");
    }

    public int ReturnFalse()
    {
        return 1;
    }
}
