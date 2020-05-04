﻿// # namespace `AltCover`
// ```
namespace AltCover

open System.Runtime.CompilerServices

// ```
// ## module `PrepareExtension` and module `CollectExtension`
// ```
[<Extension>]
module PrepareExtension = begin
  [<Extension>]
  val WhatIf : prepare:OptionApi.PrepareOptions -> OptionApi.ValidatedCommandLine
end
[<Extension>]
module CollectExtension = begin
  [<Extension>]
  val WhatIf :
    collect:OptionApi.CollectOptions ->
      afterPreparation:bool -> OptionApi.ValidatedCommandLine
end
// ```
// These provide C#-compatible extension methods to perform a `WhatIf` style command like validation
//
// `WhatIf` compiles the effective command-line and the result of `Validate`
//
// ## module `OptionApiExtension`
// ```
[<AutoOpen>]
module OptionApiExtension = begin
  type OptionApi.CollectOptions with
    member WhatIf : afterPreparation:bool -> AltCover.OptionApi.ValidatedCommandLine
  type OptionApi.PrepareOptions with
    member WhatIf : unit -> AltCover.OptionApi.ValidatedCommandLine
end
//```
// provides seamless F# style extensions