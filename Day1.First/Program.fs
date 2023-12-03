open System
open System.IO

let lines = File.ReadAllLines("input.txt")

let mutable finalNumbers = []
for line in lines do
    let mutable result = ""
    let mutable numbers = []
    let chars = line.ToCharArray()
    
    for char in chars do
        let n = 
            match Int32.TryParse(char.ToString()) with
            | true, number -> number
            | _ -> 0
        if n > 0 then
            numbers <- n :: numbers
        
    if numbers.Length = 1 then
        result <- $"{numbers.Head}{numbers.Head}"
    else
        result <- $"{numbers[numbers.Length - 1]}{numbers[0]}"
    finalNumbers <- result :: finalNumbers
    
let a = finalNumbers |> List.map Int32.Parse |> List.sum
printf "%d" a