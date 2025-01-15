using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using SwApiNet.Codegen;

namespace SwApiNet.Wrappers.Models.Steam;

[DynamicVTableProxy]
public unsafe interface ICallbackVTable
{
    void Run(Callback* thisPtr, nint somePtr, byte someByte, ulong someUlong);
    void Run2(Callback* thisPtr, nint somePtr);
    int GetCallbackSizeBytes(Callback* thisPtr);
    void Unknown(Callback* thisPtr); // callback vtables have 0x10 offset from each other for a reason? TODO this signature is not real!
}
