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
    let gameId = args[0]
    let rounds = args[1].Split ";"
    
    let mutable validGame = true
    for round in rounds do
        let mutable countRedCubes = 0
        let mutable countGreenCubes = 0
        let mutable countBlueCubes = 0
        let cubes = round.Split ", "
        for cube in cubes do
            let cubeProperties = cube.TrimStart().Split " "
            let color = cubeProperties[1]
            let value = Int32.Parse(cubeProperties[0])
            
            match color with
            | "red" -> countRedCubes <- countRedCubes + value
            | "green" -> countGreenCubes <- countGreenCubes + value
            | "blue" -> countBlueCubes <- countBlueCubes + value
            | _ -> ()
            
        if countRedCubes > maxRedCubes || countGreenCubes > maxGreenCubes || countBlueCubes > maxBlueCubes then
            validGame <- false
    
    if validGame then
        gameSum <- gameSum + Int32.Parse(gameId.Split(" ")[1])

printfn "%d" gameSum