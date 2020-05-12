# DotNet.CLIOptions class

Union type defining general command line arguments for `dotnet test` use.

The F# code is [documented here](../DotNet-apidoc)

C# methods without documentation are compiler generated. Most important for non-F# use are the `NewXxx` factory methods.

```csharp
public abstract class CLIOptions : IEquatable<CLIOptions>, IStructuralEquatable
```

## Public Members

| name | description |
| --- | --- |
| static [NewAbstract](DotNet.CLIOptions/NewAbstract-apidoc)(…) |  |
| static [NewFailFast](DotNet.CLIOptions/NewFailFast-apidoc)(…) |  |
| static [NewForce](DotNet.CLIOptions/NewForce-apidoc)(…) |  |
| static [NewMany](DotNet.CLIOptions/NewMany-apidoc)(…) |  |
| static [NewShowSummary](DotNet.CLIOptions/NewShowSummary-apidoc)(…) |  |
| static [Translate](DotNet.CLIOptions/Translate-apidoc)(…) | Map the C#-friendly interface to the F# type |
| [Fast](DotNet.CLIOptions/Fast-apidoc) { get; } | The `/AltCoverFailFast` value this represents |
| [ForceDelete](DotNet.CLIOptions/ForceDelete-apidoc) { get; } | The `/AltCoverForce` value this represents |
| [IsAbstract](DotNet.CLIOptions/IsAbstract-apidoc) { get; } |  |
| [IsFailFast](DotNet.CLIOptions/IsFailFast-apidoc) { get; } |  |
| [IsForce](DotNet.CLIOptions/IsForce-apidoc) { get; } |  |
| [IsMany](DotNet.CLIOptions/IsMany-apidoc) { get; } |  |
| [IsShowSummary](DotNet.CLIOptions/IsShowSummary-apidoc) { get; } |  |
| [Summary](DotNet.CLIOptions/Summary-apidoc) { get; } | The `/AltCoverShowSummary` value this represents |
| [Tag](DotNet.CLIOptions/Tag-apidoc) { get; } |  |
| [Equals](DotNet.CLIOptions/Equals-apidoc)(…) |  (3 methods) |
| [GetHashCode](DotNet.CLIOptions/GetHashCode-apidoc)() |  |
| [GetHashCode](DotNet.CLIOptions/GetHashCode-apidoc)(…) |  |
| [get_IsAbstract](DotNet.CLIOptions/get_IsAbstract-apidoc)() |  |
| [get_IsFailFast](DotNet.CLIOptions/get_IsFailFast-apidoc)() |  |
| [get_IsForce](DotNet.CLIOptions/get_IsForce-apidoc)() |  |
| [get_IsMany](DotNet.CLIOptions/get_IsMany-apidoc)() |  |
| [get_IsShowSummary](DotNet.CLIOptions/get_IsShowSummary-apidoc)() |  |
| [get_Tag](DotNet.CLIOptions/get_Tag-apidoc)() |  |
| override [ToString](DotNet.CLIOptions/ToString-apidoc)() |  |
| class [Abstract](DotNet.CLIOptions.Abstract-apidoc) |  |
| class [FailFast](DotNet.CLIOptions.FailFast-apidoc) |  |
| class [Force](DotNet.CLIOptions.Force-apidoc) |  |
| class [Many](DotNet.CLIOptions.Many-apidoc) |  |
| class [ShowSummary](DotNet.CLIOptions.ShowSummary-apidoc) |  |
| static class [Tags](DotNet.CLIOptions.Tags-apidoc) |  |

## See Also

* class [DotNet](DotNet-apidoc)
* namespace [AltCover](../AltCover.DotNet-apidoc)

<!-- DO NOT EDIT: generated by xmldocmd for AltCover.DotNet.dll -->