# Tyrannoport

[![Build Status](https://dev.azure.com/iwillspeak/GitHub/_apis/build/status/iwillspeak.Tyrannoport?branchName=main)](https://dev.azure.com/iwillspeak/GitHub/_build/latest?definitionId=8&branchName=main)
[![Tyrannoport on fuget.org](https://www.fuget.org/packages/Tyrannoport/badge.svg)](https://www.fuget.org/packages/Tyrannoport)

🦖 For processing TRX files into something more enjoyable 🦖

![Overview page](docs/OverviewPage.png)
![Class details](docs/ClassDetails.png)

## Installation

Tyrannoport is a `dotnet` tool. It can be installed either to a project's
local `dotnet-tools.json`, or globally.

```bash
$ dotnet tool install tyrannoport
```

Or to install globally

```bash
$ dotnet tool install --global tyrannoport
```

The tool can then be run as either `tyrannoport`, or
`dotnet tool run tyrannoport`.

## Usage

Tyrannoport takes one or more TRX file names and generates HTML reports next to
them.

```
$ tyrannoport [report.trx]+
```

### Cake Build

Tyrannoport can be called directly from Cake build scripts. You will need to
have both the `Tyrannoport` tool, and the `Cake.Tyrannoport` package installed:

```cake
#tool "dotnet:?package=Tyrannoport&version=0.3.21"
#addin "nuget:?package=Cake.Tyrannoport&version=0.3.21"
```

Then in your `build.cake` you can call Tyrannoport:

```c#
Task("Report")
    .IsDependentOn("Test")
    .Does(() =>
{
    Tyrannoport(trxPath);
});
```

For more details [see the example Cake project](https://gist.github.com/iwillspeak/85ecff08bfd587d2a98272f1dd1a2698).

### NUKE Build

Tyrannoport can be called from NUKE by referencing it as a custom tool:

```bash
$ nuke :add-package Tyrannoport --version 0.3.21
```

Then in your `Build.cs`:

```c#
[PackageExecutable("Tyrannoport", "Tyrannoport.dll")]
readonly Tool Tyrannoport;

// ... 

Tyrannoport(trxPath);
```

## License

Tyrannoport is [licensed under the MIT license](LICENSE.txt).
