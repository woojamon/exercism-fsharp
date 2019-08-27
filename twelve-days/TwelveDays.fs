module TwelveDays

let private dayGift (day: int) =
    match day with
        | 1 -> ("first", Some "a Partridge in a Pear Tree")
        | 2 -> ("second", Some "two Turtle Doves")
        | 3 -> ("third", Some "three French Hens")
        | 4 -> ("fourth", Some "four Calling Birds")
        | 5 -> ("fifth", Some "five Gold Rings")
        | 6 -> ("sixth", Some "six Geese-a-Laying")
        | 7 -> ("seventh", Some "seven Swans-a-Swimming")
        | 8 -> ("eighth", Some "eight Maids-a-Milking")
        | 9 -> ("ninth", Some "nine Ladies Dancing")
        | 10 -> ("tenth", Some "ten Lords-a-Leaping")
        | 11 -> ("eleventh", Some "eleven Pipers Piping")
        | 12 -> ("twelfth", Some "twelve Drummers Drumming")
        | _ -> ("", None)

let private giftsForDay (day:int) =
    [1..day]
    |> Seq.map (dayGift >> snd)
    |> Seq.where Option.isSome
    |> Seq.map Option.get
    |> Seq.rev
    |> String.concat ", "

let verse (number: int) =
    ("On the " 
    + (dayGift number |> fst) 
    + " day of Christmas my true love gave to me: "
    + (giftsForDay number) 
    + ".").Replace(", a ", ", and a ")

let recite start stop = 
    [start .. stop]
    |> List.map verse