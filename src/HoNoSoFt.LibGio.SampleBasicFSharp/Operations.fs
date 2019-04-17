module Operations
open HoNoSoFt.LibGio.Bindings;
open System
open FSharp.Collections
open System.Linq

let showSchemas () = 
    let schemaSource = new GSettingsSchemaSource()
    let schemas = schemaSource.ListSchemas(false)
    printfn "\tRelocatable:"
    List.ofSeq schemas.Relocatable |> Seq.sortBy (fun f -> f) |> Seq.iter (fun schema -> printfn "\t\t%s" schema)
    printfn "\tNon-Relocatable:"
    List.ofSeq schemas.NonRelocatable |> Seq.sortBy (fun f -> f) |> Seq.iter (fun schema -> printfn "\t\t%s" schema)
    None

let displaySchemaDetails (item:GSettingsSchema) =
    printfn "\tId: %s" (item.GetId())
    printfn "\tPath: %s" (item.GetPath())
    printfn "\tKeys:" 
    List.ofSeq (item.ListKeys().ToList()) |> Seq.iter (fun f -> printfn "\t\t%s" f)

    item

let chooseSchema () =
    // read from console
    let readInput () =
        printf "\t> "
        Console.ReadLine()
    let schemaExists str =
        let schemaSource = new GSettingsSchemaSource()
        let schema = schemaSource.Lookup(str, true)
        match schema with
            | null ->
                    printfn "===> Schema not found. <==="
                    None
            | _  -> Some schema

    let schema = Seq.initInfinite(fun _ -> readInput()) 
                    |> Seq.choose schemaExists
                    |> Seq.head

    schema