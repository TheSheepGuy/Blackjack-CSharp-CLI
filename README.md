# Blackjack-CSharp-CLI

A blackjack clone written in C# using the open source .NET Core. A portable build is available from the releases, these don't require the .NET Core runtime.

## Building

Use .NET Core 3.1 to build this application, it goes without saying that you need the .NET Core SDK, the runtime won't suffice. [More information available here from the Microsoft docs](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish), an abridged version below.

### Windows

Run `dotnet publish -r winX-x64` where X is your version (`win7-x64`, `win10-x64`, etc.). If you want a portable version, run `win-x64`.

### Linux

Run `dotnet publish -r distro-x64` where distro is your distro. If your distro is unsupported, use `linux-x64`. To see a list of supported distros, [see this JSON file](https://github.com/dotnet/runtime/blob/master/src/libraries/pkg/Microsoft.NETCore.Platforms/runtime.json).

Red Hat and Tizen can build a non-portable version, see [this documentation](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog).
