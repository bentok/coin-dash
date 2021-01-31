namespace FSharp.Player

open Godot

type PlayerFs() =
    inherit Area2D()

    override this._Ready() =
        GD.Print("Hello from F#!")
