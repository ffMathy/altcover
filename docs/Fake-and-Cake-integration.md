# F# Fake and Cake integration v7.x

APIs for use with build scripting tools are provided in the `AltCover.Cake.dll` and `AltCover.Fake.dll` assemblies, which are present in the `AltCover.Api` nuget package

* [Fake integration](#fake-integration)
* [Cake integration](#cake-integration)

# Fake integration 
Found in `AltCover.Fake.dll`  
Detailed API documentation is [presented here](AltCover.Fake/Fake-fsapidoc).

### Example
Driving `dotnet test` in a Fake script (based on [the AltCover build script here](https://github.com/SteveGilham/altcover/blob/master/Build/targets.fsx#L3425-L3454))
```
#r "paket:
nuget Fake.DotNet.Cli >= 5.20.3
nuget AltCover.Api >= 7.0 //"

let ForceTrue = AltCover.DotNet.CLIOptions.Force true 

let p =
  { AltCover.Primitive.PrepareOptions.Create() with
      CallContext = [| "[Fact]"; "0" |]
      AssemblyFilter = [| "xunit" |] }

let prepare = AltCover.AltCover.PrepareOptions.Primitive p
let c = AltCover.Primitive.CollectOptions.Create()
let collect = AltCover.AltCover.CollectOptions.Primitive c

open AltCover.Fake.DotNet // extension method WithAltCoverOptions
Fake.DotNet.DotNet.test
  (fun to' -> to'.WithAltCoverOptions prepare collect ForceTrue)
  "dotnettest.fsproj"

```

# Cake integration 

Found in `AltCover.Cake.dll`  
Detailed API documentation is [presented here](AltCover.Cake/AltCover.Cake-apidoc).
