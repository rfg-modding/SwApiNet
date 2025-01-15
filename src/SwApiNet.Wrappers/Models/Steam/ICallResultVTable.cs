using SwApiNet.Codegen;

namespace SwApiNet.Wrappers.Models.Steam;

[DynamicVTableProxy]
public unsafe interface ICallResultVTable
{
    void Run(CallResult* thisPtr, nint somePtr, byte someByte, ulong someUlong);
    void Run2(CallResult* thisPtr, nint somePtr);
    int GetCallbackSizeBytes(CallResult* thisPtr);
    void Unknown(CallResult* thisPtr); // callback vtables have 0x10 offset from each other for a reason? TODO this signature is not real!
}