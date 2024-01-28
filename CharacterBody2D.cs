using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{	
	
	[Export]
	public float speed = 400f;

	[Export]
	public bool hasKey = true;
	
	[Export]
	public bool isPlayer = true;

	private bool isFalling = false;

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
	
	public void slip_and_fall() {
		isFalling = true;
		Timer timer = new Timer();
		timer.WaitTime = 0.5f;
		// timer.Set("OneShot", true);
		timer.OneShot = true;
		// timer.Set("WaitTime",  0.4f);
		// timer.ProcessCallback
		Callable callable = new Callable(this, "stand_up");
		timer.Connect("timeout", callable);
		AddChild(timer);
		timer.Start();
		animPlayer.Play("fall");
		
	}

	public void stand_up() {
		GD.Print("STANDING UP");
		isFalling = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = new Vector2(0,0);
		
		direction = new Vector2(
			Input.GetActionStrength("Right") - Input.GetActionStrength("Left"),
			Input.GetActionStrength("Down") - Input.GetActionStrength("Up")

		);
		
		if(!isFalling) {
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
				MoveAndSlide();
			}
			else {
				animPlayer.Play("idle");
			}
		}
		
	}
	
}
