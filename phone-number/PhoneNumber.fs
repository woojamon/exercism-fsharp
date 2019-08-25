module PhoneNumber

open System.Text.RegularExpressions

let letterCheck input =
    match (Regex.IsMatch (input, "[a-z]|[A-Z]")) with 
        | true -> Error "letters not permitted"
        | false -> Ok input
        
let punctuationCheck input = 
    match input with 
        | Error err -> Error err
        | Ok str -> 
            if (Regex.IsMatch (str, "@|:|\!"))
                then Error "punctuations not permitted"
                else Ok str

let extractDigits input =
    match input with
        | Error err -> Error err
        | Ok (str:string) -> 
            match 
                str
                |> Seq.filter System.Char.IsDigit            
                |> Seq.map string
                |> String.concat ""
                    with
                    | "" -> Error "No digits found"
                    | _ as digits   -> Ok digits

let minLengthCheck input =
    match input with
        | Error err -> Error err
        | Ok (str:string) -> 
            if (str.Length < 10)
                then Error "incorrect number of digits"
                else Ok str

let maxLengthCheck input = 
    match input with
        | Error err -> Error err
        | Ok (str:string) ->
            if (str.Length > 11)
                then Error "more than 11 digits"
                else Ok str

let countryCodeCheck input =
    match input with
        | Error err -> Error err
        | Ok (str:string) ->
            if (Regex.IsMatch (str, "[^1]\d{10}"))
                then Error "11 digits must start with 1"
                else Ok str

let stripCountryCode input =
    match input with 
        | Error err -> Error err
        | Ok (str:string) ->
            str.ToCharArray()
            |> Array.rev
            |> Array.take 10 
            |> Array.rev
            |> Array.map string
            |> String.concat ""
            |> Ok

let areaCodeCheck input = 
    match input with    
        | Error err -> Error err
        | Ok (str:string) ->
            match str.Chars 0 with
            | '0' -> Error "area code cannot start with zero"
            | '1' -> Error "area code cannot start with one"
            | _ -> Ok str

let exchangeCodeCheck input =
    match input with
        | Error err -> Error err
        | Ok (str:string) -> 
            match str.Chars 3 with
            | '0' -> Error "exchange code cannot start with zero"
            | '1' -> Error "exchange code cannot start with one"
            | _ -> Ok str

let parseResult input =
    match input with
        | Error err -> Error err
        | Ok str -> uint64 str |> Ok

let clean input = 
   input
   |> letterCheck
   |> punctuationCheck
   |> extractDigits
   |> minLengthCheck
   |> maxLengthCheck
   |> countryCodeCheck
   |> stripCountryCode
   |> areaCodeCheck
   |> exchangeCodeCheck
   |> parseResult
   

    
    




        

    
    