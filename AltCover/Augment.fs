#nowarn "25"
namespace AltCover

open System.Diagnostics.CodeAnalysis

[<SuppressMessage("Gendarme.Rules.Smells", "AvoidSpeculativeGeneralityRule",
  Justification = "AvoidCodeDuplicatedInSameClassRule")>]
[<AutoOpen>]
module internal Augment =

  type System.Object with
    member self.IsNotNull
      with get() =
        self |> isNull |> not

#if !WEAK_NAME
  type System.String with
    member self.X
      with get() =
        System.Xml.Linq.XName.Get self
#endif

#if !GUI
  type Microsoft.FSharp.Core.Option<'T> with
    [<SuppressMessage("Gendarme.Rules.Naming",
                      "UseCorrectCasingRule",
                      Justification = "Idiomatic F# style")>]
    // fsharplint:disable-next-line MemberNames
    static member getOrElse (fallback : 'T) (x : option<'T>) = defaultArg x fallback

    [<SuppressMessage("Gendarme.Rules.Naming",
                      "UseCorrectCasingRule",
                      Justification = "Idiomatic F# style")>]
    // fsharplint:disable-next-line MemberNames
    static member nullable (x : 'T) : option<'T> =
      if x.IsNotNull then Some x else None
#endif
  type internal Either<'a, 'b> = Choice<'b, 'a>

  [<SuppressMessage(
    "Gendarme.Rules.Design.Generic", "AvoidMethodWithUnusedGenericTypeRule",
    Justification = "Context in F# has to be sufficient")>]
  [<SuppressMessage("Gendarme.Rules.Naming",
                    "UseCorrectCasingRule",
                    Justification = "Idiomatic F# style")>]
  let Right x : Either<'a, 'b> = Choice1Of2 x
  [<System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Gendarme.Rules.Design.Generic", "AvoidMethodWithUnusedGenericTypeRule",
    Justification = "Context in F# has to be sufficient")>]
  [<SuppressMessage("Gendarme.Rules.Naming",
                    "UseCorrectCasingRule",
                    Justification = "Idiomatic F# style")>]
  let Left x : Either<'a, 'b> = Choice2Of2 x

  let internal (|Right|Left|) =
    function
    | Choice1Of2 x -> Right x
    | Choice2Of2 x -> Left x

#if !WEAK_NAME
#if !GUI
  let internal doWithStream (create : unit -> 'a) (action : 'a -> unit) =
    use stream = create()
    action stream
#endif
#endif

#if !GUI
  type System.Boolean with
    member self.ToInt32
      with get() =
        if self then 1 else 0
#if !WEAK_NAME
  type System.Int32 with
    member self.Increment (b : bool) =
      self + b.ToInt32
#endif

  type Microsoft.FSharp.Collections.List<'T> with
   member self.Split
     with get () =
      (self.Head, self.Tail) // since Gendarme thinks the concatenation operator is a hardcoded path!
#endif

[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#Left`2(!!0)", MessageId="a",
  Justification="Compiler Generated")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#Left`2(!!0)", MessageId="b",
  Justification="Compiler Generated")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#Left`2(!!0)", MessageId="x",
  Justification="Trivial usage")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#Object.get_IsNotNull(System.Object)",
  MessageId="param",
  Justification="Compiler Generated")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores",
  Scope="member", Target="AltCover.Augment.#Object.get_IsNotNull(System.Object)",
  Justification="Compiler Generated")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#Right`2(!!0)", MessageId="a",
  Justification="Compiler Generated")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#Right`2(!!0)", MessageId="b",
  Justification="Compiler Generated")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#Right`2(!!0)", MessageId="x",
  Justification="Trivial usage")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope="member", Target="AltCover.Augment.#String.get_X(System.String)", MessageId="param",
  Justification="Compiler generated")>]
[<assembly: SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores",
  Scope="member", Target="AltCover.Augment.#String.get_X(System.String)",
  Justification="Compiler generated")>]
()