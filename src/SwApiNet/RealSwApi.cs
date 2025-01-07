using System.Runtime.InteropServices;

namespace SwApiNet;

public static unsafe class RealSwApi
{
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int* SW_CCSys_CreateInternalModule(byte* x);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int* SW_CCSys_DynamicInit(int* x);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int* SW_CCSys_GetPInterface();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int* SW_CCSys_GetUInterface();

    /// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_CCSys_Init();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int* SW_CCSys_InitCallbackFunc(int* x, int y);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_CCSys_ProcessApiCb();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_RegisterCallResult(int* x, ulong y);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_RemoveCallbackFunc(int* x);

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_Shutdown();

    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SW_CCSys_UnregisterCallResult(int *x, int *y, int *z);

    /// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_HasAchievements();

    /// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_HasInvites();

    /// <returns>bool</returns>
    [DllImport("sw_api_original.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SW_HasLeaderboards();
}
