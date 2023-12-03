open System
open System.IO

[<Literal>]
let maxRedCubes = 12

[<Literal>]
let maxGreenCubes = 13

[<Literal>]
let maxBlueCubes = 14

let lines = File.ReadAllLines("input.txt")

let mutable gameSum = 0

for line in lines do
    let args = line.Split ":"
    let rounds = args[1].Split ";"
    
    let mutable countRedCubes = []
    let mutable countGreenCubes = []
    let mutable countBlueCubes = []
    
    let mutable digits = []
    for round in rounds do
        let cubes = round.Split ", "
        for cube in cubes do
            let cubeProperties = cube.TrimStart().Split " "
            let color = cubeProperties[1]
            let value = Int32.Parse(cubeProperties[0])
            
            match color with
            | "red" -> countRedCubes <- value :: countRedCubes
            | "green" -> countGreenCubes <- value :: countGreenCubes
            | "blue" -> countBlueCubes <- value :: countBlueCubes
            | _ -> ()
                   
    if countRedCubes.Length > 0 then
       digits <- (countRedCubes |> List.max) :: digits
    if countGreenCubes.Length > 0 then
       digits <- (countGreenCubes |> List.max) :: digits
    if countBlueCubes.Length > 0 then
       digits <- (countBlueCubes |> List.max) :: digits
    
    let mutable sum = 1
    for digit in digits do
        sum <- sum * digit

    gameSum <- gameSum + sum

printfn "%d" gameSum