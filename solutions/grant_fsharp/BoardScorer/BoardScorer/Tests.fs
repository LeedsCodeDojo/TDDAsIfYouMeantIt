module Tests

open NUnit.Framework
open FsUnit

type Cell =
| Empty
| X
| O

type Status = 
| InProgress
| XWon
| OWon

let boardStatus board = 
    if board = [[Empty;Empty;Empty];
    [Empty;Empty;Empty];
    [Empty;Empty;Empty]] then
        InProgress
    else
        match List.head board with
        | [X;X;X] -> XWon
        | [O;O;O] -> OWon
        | [X;Empty;Empty] -> XWon

[<Test>]
let ``An empty board gives in progress`` () =
    [[Empty;Empty;Empty];
    [Empty;Empty;Empty];
    [Empty;Empty;Empty]] |> boardStatus |> should equal InProgress
    
[<Test>]
let ``A row of player X gives X Won`` () =
    [[X;X;X];
    [Empty;Empty;Empty];
    [Empty;Empty;Empty]] |> boardStatus |> should equal XWon

[<Test>]
let ``A row of player O gives O Won`` () =
    [[O;O;O];
    [Empty;Empty;Empty];
    [Empty;Empty;Empty]] |> boardStatus |> should equal OWon

[<Test>]
let ``A column of player X gives X Won`` () =
    [[X;Empty;Empty];
    [X;Empty;Empty];
    [X;Empty;Empty]] |> boardStatus |> should equal XWon