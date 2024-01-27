using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{	
	
	[Export]
	public float speed = 400f;

	[Export]
	public Vector2 direction;

	public Vector2 ScreenSize; // Size of the game window.

	// public AnimationTree animTree;
	public AnimationPlayer animPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = new Vector2(0,0);
		
		direction = new Vector2(
			Input.GetActionStrength("Right") - Input.GetActionStrength("Left"),
			Input.GetActionStrength("Down") - Input.GetActionStrength("Up")

		);

		// update_animation_direction(direction);

		if(direction != Vector2.Zero) {
			if (Input.IsActionPressed("Right")) {
				velocity.X += speed;
				animPlayer.Play("walk_right");
			}
			if (Input.IsActionPressed("Left")) {
				velocity.X -= speed;
				animPlayer.Play("walk_left");
			}
			if (Input.IsActionPressed("Down")){
				velocity.Y += speed;
				animPlayer.Play("walk_down");
			}
			if (Input.IsActionPressed("Up")) {
				velocity.Y -= speed;
				animPlayer.Play("walk_up");
			}

			velocity = velocity.Normalized() * speed;
			Position += velocity * (float)delta;
			Position = new Vector2(
				x: Mathf.Clamp(Position.X, 0, ScreenSize.X - 64),
				y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y - 64)
			);
			MoveAndSlide();
		}
		else {
			animPlayer.Play("idle");
		}

		
	}
	
}
