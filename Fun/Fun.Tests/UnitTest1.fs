namespace Fun.Tests

open NUnit.Framework
open Fun

[<TestFixture>]
type TestClass () =

    [<Test>]
    member this.``2 + 3 は 5 になるはず！`` () =
        let result = 2 + 3
        Assert.That(result, Is.EqualTo(5))

