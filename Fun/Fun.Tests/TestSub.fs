namespace Fun.Tests

open NUnit.Framework
open Fun

[<TestFixture>]
type TestSubClass() =

    [<Test>]
    member this.``1 - 1 = 0``() =
        let result: Number = sub (Integer (1)) (Float (1.0))
        Assert.That (result, Is.EqualTo (Float (0.0)))
