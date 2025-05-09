namespace Fun.Tests

open NUnit.Framework
open Fun

[<TestFixture>]
type TestMulClass() =

    [<Test>]
    member this.``1.0 * 1.0 = 1``() =
        let result: Number = mul (Float (1.0)) (Float (1.0))
        Assert.That (result, Is.EqualTo (Float (1.0)))
