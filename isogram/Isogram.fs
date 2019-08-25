module Isogram

let isIsogram str =
    match str with
    | "" -> true
    | _ ->
        str.ToLower()
        |> Seq.filter System.Char.IsLetter
        |> Seq.groupBy id
        |> Seq.exists (fun (_, v) -> (Seq.length v) > 1)
        |> not
