module Hamming

open System.Linq
open System.Collections.Generic

let hammingCount (referenceStrand : IEnumerable<char>)
    (differenceStrand : IEnumerable<char>) =
    referenceStrand.Zip(differenceStrand, (fun s1 s2 -> s1.Equals s2))
                   .Count(fun b -> b.Equals false)

let distance (strand1 : string) (strand2 : string) : int option =
    if (strand1.Length <> strand2.Length) then None
    else if (strand1.Equals strand2) then Some 0
    else
        let bases1 = strand1.ToCharArray()
        let bases2 = strand2.ToCharArray()
        Some(hammingCount bases1 bases2)
