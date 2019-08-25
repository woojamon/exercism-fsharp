module PhoneNumber

open System.Text.RegularExpressions

let clean input = 
    match input with
    | "" -> Error "blah"
    | _ ->  input
            |> Seq.filter System.Char.IsDigit            
            |> Seq.map string
            |> String.concat ""       
            |> (fun input -> input.Length == 11 ? Regex.Replace (input, "^1", "") : input)            
            |> uint64
            |> Ok

    
    




        

    
    