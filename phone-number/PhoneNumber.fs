module PhoneNumber

open System.Text.RegularExpressions

let clean input = 
    match input with
    | "" -> Error "blah"
    | _ ->  input
            |> Seq.filter System.Char.IsDigit            
            |> Seq.map string
            |> String.concat ""       
            |> (fun input -> Regex.Replace (input, "^1", ""))
            |> uint64
            |> Ok

    
    




        

    
    