module Pangram

open System.Linq

let a = 97 // ascii decimal code for 'a'
let z = 122 // ascii decimal code for 'z'
let alphabet =
    [ a..z ] |> Seq.map (System.Convert.ToByte >> System.Convert.ToChar)

let isPangram (input : string) : bool =
    input.ToLower()
    |> alphabet.Except
    |> Seq.length
    |> fun x -> x = 0
