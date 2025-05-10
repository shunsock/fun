module Fun

type Number =
    | Integer of int
    | Float of float

type RError = { Name: string; Message: string }

type CalculationError = | ZeroDivisionError of RError

let toInteger (number: Number) : Number =
    match number with
    | Integer i -> Integer (i)
    | Float f -> Integer (int f)

let toFloat (number: Number) : Number =
    match number with
    | Integer i -> Float (float i)
    | Float f -> Float (f)

let fromInteger (i: int) : Number = Integer (i)

let fromFloat (f: float) : Number = Float (f)

let add (x: Number) (y: Number) : Number =
    match (x, y) with
    | (Integer x, Integer y) -> fromInteger (x + y)
    | (Float x, Integer y) -> fromFloat (x + float y)
    | (Integer x, Float y) -> fromFloat (float x + y)
    | (Float x, Float y) -> fromFloat (x + y)

let sub (x: Number) (y: Number) : Number =
    match (x, y) with
    | (Integer x, Integer y) -> fromInteger (x - y)
    | (Float x, Integer y) -> fromFloat (x - float y)
    | (Integer x, Float y) -> fromFloat (float x - y)
    | (Float x, Float y) -> fromFloat (x - y)

let mul (x: Number) (y: Number) : Number =
    match (x, y) with
    | (Integer x, Integer y) -> fromInteger (x * y)
    | (Float x, Integer y) -> fromFloat (x * float y)
    | (Integer x, Float y) -> fromFloat (float x * y)
    | (Float x, Float y) -> fromFloat (x * y)

let div (x: Number) (y: Number) : Result<Number, CalculationError> =
    match (x, y) with
    | (_, Integer 0)
    | (_, Float 0.0) ->
        Error (
            ZeroDivisionError
                { Name = "ZeroDivisionError"
                  Message = "Can not divide by zero" }
        )
    | (Integer x, Integer y) -> Ok (fromInteger (x / y))
    | (Float x, Integer y) -> Ok (fromFloat (x / float y))
    | (Integer x, Float y) -> Ok (fromFloat (float x / y))
    | (Float x, Float y) -> Ok (fromFloat (x / y))
