using System.Runtime.InteropServices;
using SwApiNet.Wrappers.Dll;
using SwApiNet.Wrappers.Models;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Models.Steam;

namespace SwApiNet.Wrappers;

public static class Imports
{
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern unsafe SteamClient* SW_CCSys_CreateInternalModule(nint x);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern nint SW_CCSys_DynamicInit(nint x);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern nint SW_CCSys_GetPInterface();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern nint SW_CCSys_GetUInterface();

    /// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_CCSys_Init();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern nint SW_CCSys_InitCallbackFunc(nint x, CallbackType y);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_CCSys_ProcessApiCb();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_RegisterCallResult(nint x, ulong y);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_RemoveCallbackFunc(nint x);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_Shutdown();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_UnregisterCallResult(nint x, nint y, nint z);

    /*/// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_HasAchievements();

    /// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_HasInvites();

    /// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_HasLeaderboards();*/
}
