open System
open System.IO
open System.Text.RegularExpressions

let allowedNumbers = ["one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine"]

let lines = File.ReadAllLines("input.txt")

let parseNumber(n : string) =
    match n with
    | "one" -> 1
    | "two" -> 2
    | "three" -> 3
    | "four" -> 4
    | "five" -> 5
    | "six" -> 6
    | "seven" -> 7
    | "eight" -> 8
    | "nine" -> 9
    | _ -> 0

let mutable finalNumbers = []
for line in lines do
    let mutable result = ""
    let mutable numbers = []
    let mutable chars = ""
    
    let mutable i = 0
    while line.Length <> i do
        chars <- chars + line[i].ToString()
        i <- i + 1
        let n = 
            match Int32.TryParse(chars[chars.Length - 1].ToString()) with
            | true, number -> number
            | _ -> 0
        if n > 0 && n < 10 then
            numbers <- n :: numbers
            chars <- ""
        elif n > 10 then
            chars <- ""
        else
            for allowedNumber in allowedNumbers do
                let matches = Regex.Match(chars, allowedNumber)
                if matches.Value = allowedNumber then
                    let number = parseNumber matches.Value
                    numbers <- number :: numbers
                    chars <- ""
                
        
    if numbers.Length = 1 then
        result <- $"{numbers.Head}{numbers.Head}"
    else
        result <- $"{numbers[numbers.Length - 1]}{numbers[0]}"
    finalNumbers <- result :: finalNumbers
    
let countNumbers = finalNumbers |> List.map Int32.Parse |> List.sum
printf "%A" finalNumbers
printfn "%d" countNumbers