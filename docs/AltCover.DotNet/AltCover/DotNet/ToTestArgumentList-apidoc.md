# DotNet.ToTestArgumentList method

Converts the input into the command line for `dotnet test`

```csharp
public static FSharpList<string> ToTestArgumentList(IPrepareOptions prepare, 
    ICollectOptions collect, ICLIOptions options)
```

| parameter | description |
| --- | --- |
| prepare | Description of the instrumentation operation to perform |
| collect | Description of the collection operation to perform |
| options | All other `altcover` related command line arguments |

## Return Value

The command line as a sequence of individual items

## See Also

* interface [ICLIOptions](../DotNet.ICLIOptions-apidoc)
* class [DotNet](../DotNet-apidoc)
* namespace [AltCover](../../AltCover.DotNet-apidoc)

<!-- DO NOT EDIT: generated by xmldocmd for AltCover.DotNet.dll -->
