namespace FSharp.Player

open Godot

type PlayerFs() =
    inherit Area2D()

    [<Export>]
    let mutable Speed = 2.00f

    let screensize = Vector2(480.00f, 720.00f)

    let veloX () =
        if Input.IsActionPressed("ui_left") then -1.00f
        elif Input.IsActionPressed("ui_right") then 1.00f
        else 0.00f

    let veloY () =
        if Input.IsActionPressed("ui_up") then -1.00f
        elif Input.IsActionPressed("ui_down") then 1.00f
        else 0.00f

    let getVeloInput () =
        Vector2(veloX(), veloY())

    let getAnimationState (velocity : Vector2) =
        if velocity.Length() > 0.00f then
           if velocity.x > 0.00f then ("run", false)
           else ("run", true)
        else ("idle", false)

    override this._Ready () =
        ignore 0

    override this._Process (delta) =
        let velocity = getVeloInput().Normalized() * Speed
        let sprite = this.GetNode<AnimatedSprite>(new NodePath("AnimatedSprite"))
        let animation, isFlipped = getAnimationState(velocity)

        // Group all class mutation. Consider increasing immutability
        this.Position <-
            this.Position + delta * velocity
        this.Position <-
            Vector2(
                Mathf.Clamp(this.Position.x, 0.00f, screensize.x),
                Mathf.Clamp(this.Position.y, 0.00f, screensize.y))
        sprite.Animation <- animation
        sprite.FlipH <- isFlipped

        ignore 0
