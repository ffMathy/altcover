#r "paket:
nuget FSharpLint.Fake >= 0.9.0
nuget Fake.Core.Target prerelease //"
open System
open System.IO

let here = Directory.GetCurrentDirectory()
let globalNuget = Path.Combine(Environment.GetEnvironmentVariable "USERPROFILE", ".nuget/packages")

let lintlib = Directory.GetFiles(globalNuget, "*SharpLint.Fake.dll", SearchOption.AllDirectories)
              |> Seq.head
              |> Path.GetDirectoryName

let mdlib = Directory.GetFiles(here, "*Sharp.Markdown.dll", SearchOption.AllDirectories)
            |> Seq.filter (fun n -> n.Contains("net40"))
            |> Seq.head
            |> Path.GetDirectoryName

let ylib = Directory.GetFiles(here, "*amlDotNet.dll", SearchOption.AllDirectories)
            |> Seq.filter (fun n -> n.Contains("net35"))
            |> Seq.head
            |> Path.GetDirectoryName

let nlib = Directory.GetFiles(here, "*framework.dll", SearchOption.AllDirectories)
            |> Seq.filter (fun n -> n.Contains("net45"))
            |> Seq.head
            |> Path.GetDirectoryName

let build = """#r "paket:
nuget FAKE prerelease
nuget Fake.Core.Target prerelease
nuget Fake.Core.Environment prerelease
nuget Fake.Core.Globbing prerelease
nuget Fake.Core.Process prerelease
nuget Fake.DotNet.AssemblyInfoFile prerelease
nuget Fake.DotNet.Cli prerelease
nuget Fake.DotNet.MsBuild prerelease
nuget Fake.DotNet.NuGet prerelease
nuget Fake.DotNet.Testing.NUnit prerelease
nuget Fake.DotNet.Testing.OpenCover prerelease
nuget Fake.IO.FileSystem prerelease
nuget FSharpLint.Fake >= 0.9.0
nuget YamlDotNet >= 4.3.0 //"
#I @"{0}"
#r "FSharpLint.Fake"
#I @"{1}"
#r "FSharp.Markdown.dll"
#I @"{3}"
#r "nunit.framework.dll"
#r "System.IO.Compression.FileSystem.dll"
#r "System.Xml"
#r "System.Xml.Linq"

#load "actions.fsx"
#load "targets.fsx"
"""

let formatted = String.Format(build, lintlib, mdlib, ylib, nlib)
File.WriteAllText("./Build/build.fsx", formatted)