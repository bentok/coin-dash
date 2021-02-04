namespace FSharp.Player

open Godot

type PlayerFs() =
    inherit Area2D()

    [<Export>]
    let mutable Speed = 2.00f

    let velocity = Vector2()

    let screensize = Vector2(480.00f, 720.00f)

    let velo (a, b) =
            Vector2(a, b)

    let getInput() =
        velo(1.00f, 1.00f).Normalized() * Speed
//        let mutable velocity = Vector2()
//        if Input.IsActionPressed("ui_left") then velocity.x <- velocity.x - 1.00f
//        if Input.IsActionPressed("ui_right") then velocity.x <- velocity.x + 1.00f
//        if Input.IsActionPressed("ui_up") then velocity.y <- velocity.y - 1.00f
//        if Input.IsActionPressed("ui_down") then velocity.x <- velocity.y + 1.00f
//        if velocity.Length() > 0.00f then velocity = velocity.Normalized() * Speed
//        else ignore 0

    override this._Ready() =
        ignore 0

    override this._Process(delta) =
        let velocity = getInput()
        this.Position <- this.Position + delta * velocity
//        this.Position <- (Mathf.Clamp(this.Position.x, 0.00f, screensize.x), Mathf.Clamp(this.Poition.y, 0.00f, screensize.y))

