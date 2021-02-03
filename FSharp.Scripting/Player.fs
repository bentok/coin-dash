namespace FSharp.Player

open Godot

type PlayerFs() =
    inherit Area2D()

    [<Export>]
    let mutable Speed = 2.00f

    override this._Ready() =
        ignore 0

    override this._Process(delta) =
        ignore 0
