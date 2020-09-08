# GearEight Games Performance Booster Library

The GearEight Games Performance boost library is a .NET library designed to be used in software where performance is key (like games).

## Requires

The library is written in C# and should be built for .NET Standard 2.0, to be compatible with both the .NET Framwork and .NET Core, as well as other systems like [Unity](https://unity.com/).

## Usage

This library should be built and then added to the project as a reference. See [Manage references in a project](https://docs.microsoft.com/en-us/visualstudio/ide/managing-references-in-a-project) for more info about that.

In Unity, you can add this by dragging the built library into the project. It will automatically added and referenced.

It is available on [NuGet](https://www.nuget.org/packages/G8G.PerformanceBooster/1.0.0).

## Documentation

See the wiki for documentation.

## Building

This is solution is usually build using MSBuild in Visual Studio 2019 or later, but could also be built with Roslyn.

## Credits

* EA for the Idea with their [EASTL](https://github.com/electronicarts/EASTL)
* Epic Games for their Swap-methods in TArray in the UnrealEngine