using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{	
	
	[Export]
	public float speed = 400f;

	[Export]
	public Vector2 direction;

	public Vector2 ScreenSize; // Size of the game window.

	public AnimationTree animTree;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		animTree = GetNode<AnimationTree>("AnimationTree");
		animTree.Set("parameters/Idle/blend_position", new Vector2(0,0));
	}

	public void update_animation_direction(Vector2 direction) {
		if(direction != Vector2.Zero) {
			animTree.Set("parameters/Idle/blend_position", direction);
			animTree.Set("parameters/Walk/blend_position", direction);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = new Vector2(0,0);
		
		direction = new Vector2(
			Input.GetActionStrength("Right") - Input.GetActionStrength("Left"),
			Input.GetActionStrength("Down") - Input.GetActionStrength("Up")

		);

		update_animation_direction(direction);

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
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X -65),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y -65)
		);
		MoveAndSlide();
	}
	
}
