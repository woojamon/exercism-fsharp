module RobotName

open System
open System.Collections.Generic

type Robot() = 
    static let alphaIdentifiers = Stack<string>()
    static let numberIdentifiers = Stack<string>()
    static let randomizer _ _ = Random().Next(-1,1)

    static do 
            [for i in ['A'..'Z'] do
                for j in ['A'..'Z'] do
                  yield string i + string j] 
            |> Seq.sortWith randomizer 
            |> Seq.iter alphaIdentifiers.Push

    static do 
            [0..999]
            |> Seq.map (fun x -> x.ToString("000"))
            |> Seq.sortWith randomizer
            |> Seq.iter numberIdentifiers.Push

    static let getNextName() = 
        alphaIdentifiers.Pop() + numberIdentifiers.Pop()

    let mutable _name = 
        getNextName()

    member this.name = 
        _name
        
    member this.reset() =
        _name <- getNextName()
        this

let robots = Dictionary<Robot,Robot>()

let mkRobot() = 
    let robot = Robot()
    robots.[robot] <- robot
    robot

let name robot = 
    robots.[robot].name

let reset (robot: Robot) = robot.reset()
