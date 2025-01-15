using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using SwApiNet.Wrappers.Models;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Models.Steam;
using SwApiNet.Wrappers.Utils;

namespace SwApiNet.Wrappers.Dll ;

/// <summary>
/// Calls methods from sw_api_original.dll with additional logic
/// </summary>
public unsafe class DllInterceptWrapper : IDllWrapper
{
    private readonly CallCountGuard countGuard = new();

    public nint CreateInternalModule(nint cStringPtr)
    {
        countGuard.Check(1);
        var steamClientDll = Imports.SW_CCSys_CreateInternalModule(cStringPtr);
        return SteamClient.Hijack(steamClientDll);
    }

    /// <summary>
    /// Gets called a lot
    /// </summary>
    public nint DynamicInit(nint contextPtr)
    {
        // TODO cache result and return it
        return Imports.SW_CCSys_DynamicInit(contextPtr);
    }

    public nint GetPInterface()
    {
        countGuard.Check(2);
        return CFalse();
    }

    public nint GetUInterface()
    {
        countGuard.Check(1);
        return CFalse();
    }

    public int Init()
    {
        countGuard.Check(1);
        return Imports.SW_CCSys_Init();
    }

    public nint InitCallbackFunc(nint callPtr, CallbackType type)
    {
        countGuard.Check(12);
        var real = (Callback*) callPtr;
        var fake = (Callback*) Callback.Hijack(real);
        var info = new Callback.CallbackInfo(nameof(InitCallbackFunc), type);
        Log.LogDebug($"DLL registered: {info}");
        Callback.Interop.DataByFakeVTable[(nint) fake->Table] = info;
        // game crashes if object is replaced entirely because its signature is incomplete. hijacking only vtable
        real->Table = fake->Table;
        return Imports.SW_CCSys_InitCallbackFunc(callPtr, type);

        // looks like doesnt matter what we return?
        //return 0;
    }

    /// <summary>
    /// Gets called a lot
    /// </summary>
    public void ProcessApiCb()
    {
        Imports.SW_CCSys_ProcessApiCb();
    }

    /// <summary>
    /// Gets called when entering "custom match with party"
    /// </summary>
    public void RegisterCallResult(nint callResultPtr, ulong maybeId)
    {
        var real = (CallResult*) callResultPtr;
        var fake = (CallResult*) CallResult.Hijack(real);
        var info = new CallResult.CallResultInfo(nameof(RegisterCallResult), maybeId);
        Log.LogDebug($"DLL registered: {info}");
        CallResult.Interop.DataByFakeVTable[(nint) fake->Table] = info;
        // game crashes if object is replaced entirely because its signature is incomplete. hijacking only vtable
        real->Table = fake->Table;
        Imports.SW_CCSys_RegisterCallResult(callResultPtr, maybeId);
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
        countGuard.Check(1);
        Imports.SW_CCSys_Shutdown();
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr)
    {
        // got here once when closed game window mid-joining lobby
        throw new InvalidOperationException("How did you get here?");
    }

    public int CFalse()
    {
        return Tools.CFalse;
    }


}
