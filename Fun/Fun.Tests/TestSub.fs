namespace Fun.Tests

open NUnit.Framework
open Fun

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.``1 - 1 = 0``() =
        let result = sub 1 1
        Assert.That (result, Is.EqualTo (0))

