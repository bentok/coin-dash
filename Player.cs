using FSharp.Player;
using Godot;

public class Player : PlayerFs
{
	[Signal]
	public delegate void Pickup();

	[Signal]
	public delegate void Hurt();
}
