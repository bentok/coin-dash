namespace FSharp.Coin

open Godot

type CoinFs() =
    inherit Area2D()

    let screensize = Vector2()

    member this.pickup () =
        this.QueueFree()
