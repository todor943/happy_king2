using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{	
	
	public float speed = 400f;

	public Vector2 ScreenSize; // Size of the game window.

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = new Vector2(0,0);

		if (Input.IsActionPressed("Right"))
			velocity.X += speed;
		if (Input.IsActionPressed("Left"))
			velocity.X -= speed;
		if (Input.IsActionPressed("Down"))
			velocity.Y += speed;
		if (Input.IsActionPressed("Up"))
			velocity.Y -= speed;

		velocity = velocity.Normalized() * speed;
		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	}
}
