namespace Fun.Tests

open NUnit.Framework
open Fun

[<TestFixture>]
type TestAddClass() =

    [<Test>]
    member this.``1 + 1 = 2``() =
        let result = add (Integer (1)) (Integer (1))
        Assert.That (result, Is.EqualTo (Integer (2)))
