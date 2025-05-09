module Fun

type Number =
    | Integer of int
    | Float of float

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
