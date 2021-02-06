namespace FSharp.Player

open Godot



type PlayerFs() =
    inherit Area2D()

    [<Export>]
    let mutable Speed = 2.00f

    let screensize = Vector2(480.00f, 720.00f)

    let velo (a, b) =
        Vector2(a, b)

    let veloX() =
        if Input.IsActionPressed("ui_left") then -1.00f
        elif Input.IsActionPressed("ui_right") then 1.00f
        else 0.00f

    let veloY() =
        if Input.IsActionPressed("ui_up") then -1.00f
        elif Input.IsActionPressed("ui_down") then 1.00f
        else 0.00f

    override this._Ready() =
        ignore 0

    override this._Process(delta) =
        let velocity = velo(veloX(), veloY()).Normalized() * Speed
        this.Position <- this.Position + delta * velocity
        this.Position <- Vector2(
            Mathf.Clamp(this.Position.x, 0.00f, screensize.x),
            Mathf.Clamp(this.Position.y, 0.00f, screensize.y))

