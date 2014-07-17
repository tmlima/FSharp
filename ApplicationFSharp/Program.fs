
open System

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

//    printf "sum: %i" (Sum.sum 2 3)
    printfn "fibonacci: %i" (Operations.fibonacci 0)
    printfn "fibonacci: %i" (Operations.fibonacci 1)
    printfn "fibonacci: %i" (Operations.fibonacci 2)
    printfn "fibonacci2: %i" (Operations.fibonacci 3)
    printfn "fibonacci2: %i" (Operations.fibonacci 4)

    printfn "%A" (Quicksort.quicksort [1;5;23;18;9;1;3])
    Console.ReadKey() |> ignore
    0   
