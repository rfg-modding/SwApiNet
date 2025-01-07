# SwApiNet

Wrapper for `sw_api.dll` in .NET - an attempt to reimplement networking for Red Faction Guerrilla Re-Mars-tered and untie multiplayer from unreliable master server

## Building

Requirements:

* .NET 8 SDK
* Visual Studio 2022 or later (installs stuff to compile C/C++, idk)
* C++ development workload in VS installer
* Any IDE (Rider, VS, VS Code)
* GOG version of the game (didn't bother to check Steam yet, might work though)

Run `bash publish.sh` or build solution in any IDE. C# build will trigger C build under the hood, so no need to struggle with make/cmake/VS if all dependencies are satisfied.

## Usage

* rename original `sw_api.dll` to `sw_api_original.dll`
* copy build results to RFG folder
  * `sw_api.dll` - proxy dll
  * `SwApiNet.dll` - .NET managed code dll
  * `SwApiNet.runtimeconfig.json` - required to run .net because it's not a standalone dll yet
  * other built files are optional
  * doublecheck that you have `sw_api_original.dll`
  * see STDOUT for method names being called

## TODO

* Port types from Beef-lang implementation
* Actually figure out how to hack netcode to avoid encryption and/or master server talk

## Notes

### DNNE

All the magic for unmanaged function exports is done with [DNNE](https://github.com/AaronRobinsonMSFT/DNNE).

### Blittability

Main limitation of .NET exports is that parameter and return types must be [blittable](https://learn.microsoft.com/en-us/dotnet/framework/interop/blittable-and-non-blittable-types): have same binary representation, managed and unmanaged. This means, for example, we have to return `int` instead of `bool`.

### exports.def

DNNE passes method names to linker which changes them according to call convention rules. We need clean names so have to supply `.def` file.

### x86

Native code must be compiled for 32 bits, and DNNE breaks if managed code is compiled with anything else than `Any CPU`, but this combination works anyway.

### Spartacus

Project includes `sw_api_spartacus_demo` - it's a C/CPP wrapper sample generated with [Spartacus](https://github.com/sadreck/Spartacus) and hand-modified Ghidra output. It exists only to debug how proxying works without extra stuff and managed code. Project only builds in Release mode for some reason.