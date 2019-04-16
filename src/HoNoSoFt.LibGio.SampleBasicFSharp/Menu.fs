module Menu
open System;
open Domain;
open HoNoSoFt.LibGio.Bindings;

let showAvailableSchemas () =
    printfn ""
    printfn "Here's the available schemas:"
    GSettings.ListSchemas()
        |> Seq.iter (fun f-> printfn "\t%s" f)
    printfn "----------------------------------------------------------------"
    0

let chooseSchemas () =
    printfn """Which schemas would you like to work with? (enter the "name", e.g.: org.gnome.desktop.calendar)"""
    printf "\t> "
    let schema = Console.ReadLine()
    // |> tryParseSchema name...
    // |> showGSettingsMenu
    printfn "----------------------------------------------------------------"
    0
    
let mainMenu () =
    printfn ""
    printfn "What do you want to do?"
    printfn "  1. List the available Schema (no path)."
    printfn "  2. Choose one of the available schema and show details."
    printfn "  3. Select a specific Schema (using path)."
    printfn "  x. Exit"
    printf "Choice: "
    let key = Console.ReadKey().KeyChar
    printfn ""
    key

let tryParseMainMenu (cmd:char) =
    match cmd with
        | '1' -> Some ListAvailableSchema
        | '2' -> Some ChooseFromAvailableSchema
        | '3' -> Some SelectSpecificSchema
        | 'x' -> Some Exit
        | _ -> None

let processMainMenu choice =
    match choice with 
        | ListAvailableSchema -> showAvailableSchemas()
        | _ ->  printfn "Not yet available..."
                0
