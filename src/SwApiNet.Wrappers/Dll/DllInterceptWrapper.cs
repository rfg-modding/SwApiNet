using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Models;
using SwApiNet.Wrappers.Models.Steam;

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
        // allocate unmanaged memory. VTables are static and can be cached forever, no freeing required
        SteamClient* fake = (SteamClient*)Marshal.AllocHGlobal(sizeof(SteamClient));
        fake->Table = (SteamClient.VTable*) Marshal.AllocHGlobal(sizeof(SteamClient.VTable));
        // init proxy struct and related stuff
        Marshal.StructureToPtr(new SteamClient.VTable(steamClientDll->Table), (nint)fake->Table, true);
        return (nint)fake;
    }

    /// <summary>
    /// Gets called a lot
    /// </summary>
    public nint DynamicInit(nint callbackCounterAndContextPtr)
    {
        // TODO cache result and return it
        return Imports.SW_CCSys_DynamicInit(callbackCounterAndContextPtr);
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

    public nint InitCallbackFunc(nint callbackFuncPtr, CallbackType callbackId)
    {
        countGuard.Check(12);
        // TODO manage init callback + register result
        return Imports.SW_CCSys_InitCallbackFunc(callbackFuncPtr, callbackId);
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
        countGuard.Check(1);
        Imports.SW_CCSys_Shutdown();
    }

    /// <summary>
    /// Maybe it is unused, let's verify by hard-crashing if it ever gets called
    /// </summary>
    public void UnregisterCallResult(nint cCallResultPtr, nint field1Ptr, nint field2Ptr)
    {
        throw new InvalidOperationException("How did you get here?");
    }

    public int CFalse()
    {
        return Tools.CFalse;
    }


}
