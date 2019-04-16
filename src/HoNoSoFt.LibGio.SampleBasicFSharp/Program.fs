// Learn more about F# at http://fsharp.org

open System
open Menu
open Domain

let showResult item =
    printfn "Some result = %A" item

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    let res = Seq.initInfinite( fun _ -> mainMenu())
                |> Seq.choose tryParseMainMenu
                |> Seq.takeWhile ((<>) Exit)
                |> Seq.map processMainMenu
                |> List.ofSeq  // Don't ask... simply to execute the loop

    0 // return an integer exit code
