open System;

type MainMenuChoice = ListAvailableSchema | ChooseFromAvailableSchema | SelectSpecificSchema

let mainMenu ():Option<MainMenuChoice> =
    printfn "What do you want to do?"
    printfn "  1. List the available Schema (no path)."
    printfn "  2. Choose one of the available schema."
    printfn "  3. Select a specific Schema (using path)."
    printf "Choice: "
    //let key = Console.ReadKey().KeyChar
    let key = '1' //Console.ReadKey().KeyChar
    match key with
        | '1' -> Some ListAvailableSchema
        | '2' -> Some ChooseFromAvailableSchema
        | '3' -> Some SelectSpecificSchema
        | _ -> None

mainMenu()