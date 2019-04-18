module Menu
open System;
open Domain;
open Operations;

let showAvailableSchemas () =
    printfn ""
    printfn "Here's the available schemas:"
    showSchemas() |> ignore
    printfn "----------------------------------------------------------------"
    0

let chooseSchemas () =
    printfn """Which schemas would you like to work with? (enter the "name", e.g.: org.gnome.desktop.calendar)"""
    chooseSchema() 
        |> displaySchemaDetails
        |> ignore // showSchema
    // |> tryParseSchema name...
    // |> showGSettingsMenu
    printfn "----------------------------------------------------------------"
    0
    
let mainMenu () =
    printfn ""
    printfn "What do you want to do?"
    printfn "  1. List the available Schema (no path)."
    printfn "  2. Choose from available schema (1)."
    printfn "  3. Specify a schema (using path)"
    printfn "  x. Exit"
    printf "Choice: "
    let key = Console.ReadKey().KeyChar
    printfn ""
    key

let tryParseMainMenu cmd =
    match cmd with
        | '1' -> Some ListAvailableSchema
        | '2' -> Some ChooseFromAvailableSchema
        | '3' -> Some SelectSpecificSchema
        | 'x' -> Some Exit
        | _ -> None

let processMainMenu choice =
    match choice with 
        | ListAvailableSchema -> showAvailableSchemas()
        | ChooseFromAvailableSchema -> chooseSchemas()
        | _ ->  printfn "Not yet available..."
                0
