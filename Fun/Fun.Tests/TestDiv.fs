namespace Fun.Tests

open NUnit.Framework
open Fun

[<TestFixture>]
type TestDivClass() =

    [<Test>]
    member this.``1 / 1 = 1``() =
        let result =
            match div (Integer 1) (Integer 1) with
            | Ok i -> i
            | Error e ->
                Assert.Fail (sprintf "Unexpected error: %A" e)
                Integer 0

        Assert.That (result, Is.EqualTo (Integer 1))

    [<Test>]
    member this.``1.0 / 1 = 1.0``() =
        let result =
            match div (Float 1.0) (Integer 1) with
            | Ok f -> f
            | Error e ->
                Assert.Fail (sprintf "Unexpected error: %A" e)
                Float 0

        Assert.That (result, Is.EqualTo (Float 1.0))

    [<Test>]
    member this.``1.0 / 0 = ZeroDivisionError``() =
        match div (Float 1.0) (Integer 0) with
        | Ok _ -> Assert.Fail ("Expected ZeroDivisionError but got Ok")
        | Error (ZeroDivisionError err) -> Assert.That (err.Name, Is.EqualTo ("ZeroDivisionError"))
        | Error other -> Assert.Fail (sprintf "Unexpected error: %A" other)

    [<Test>]
    member this.``1.0 / 0.0 = ZeroDivisionError``() =
        match div (Float 1.0) (Float 0.0) with
        | Ok _ -> Assert.Fail ("Expected ZeroDivisionError but got Ok")
        | Error (ZeroDivisionError err) -> Assert.That (err.Name, Is.EqualTo ("ZeroDivisionError"))
        | Error other -> Assert.Fail (sprintf "Unexpected error: %A" other)
