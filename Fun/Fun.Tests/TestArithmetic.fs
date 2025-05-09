namespace Fun.Tests

open NUnit.Framework
open Fun

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.``1 + 1 = 2``() =
        let result = add 1 1
        Assert.That (result, Is.EqualTo (2))

