# CSApi class

This class is the C#-friendly invocation API for the instrumentation and coverage collection core of AltCover

```csharp
public static class CSApi
```

## Public Members

| name | description |
| --- | --- |
| static [Collect](CSApi/Collect-apidoc)(…) | Performs the collection/reporting phase of `altcover` |
| static [ImportModule](CSApi/ImportModule-apidoc)() | Get the PowerShell command needed to import `altcover` as a PowerShell module |
| static [Prepare](CSApi/Prepare-apidoc)(…) | Performs the instrumentation phase of `altcover` |
| static [ToTestArgumentList](CSApi/ToTestArgumentList-apidoc)(…) | Converts the input into the command line for `dotnet test` |
| static [ToTestArguments](CSApi/ToTestArguments-apidoc)(…) | Converts the input into the command line for `dotnet test` |
| static [Version](CSApi/Version-apidoc)() | Get the version of `altcover` being used |
| interface [ICLIOptions](CSApi.ICLIOptions-apidoc) | Represents other `altcover`-related command line arguments for the `dotnet test` operation |
| interface [ICollectOptions](CSApi.ICollectOptions-apidoc) | This type defines the Collect (runner) behaviour. The properties map on to the command line arguments for `altcover runner` |
| interface [ILoggingOptions](CSApi.ILoggingOptions-apidoc) | Defines how to log output from the `altcover` operation |
| interface [IPrepareOptions](CSApi.IPrepareOptions-apidoc) | This type defines the Prepare (instrumentation) behaviour. The properties map on to the command line arguments for `altcover` |
| static class [Primitive](CSApi.Primitive-apidoc) | `"Stringly-typed" implemenations of the above |

## See Also

* namespace [AltCover](../AltCover.CSApi-apidoc)

<!-- DO NOT EDIT: generated by xmldocmd for AltCover.CSApi.dll -->