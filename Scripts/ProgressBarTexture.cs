using Godot;
using System;

public partial class ProgressBarTexture : TextureProgressBar
{
	private bool isDead = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Assume the Timer node is a child of this node
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Value <= 0 && !isDead) {
			GD.Print("u died!");
			isDead = true;
			// change scene to game over
			GetTree().ChangeSceneToFile("res://Scenes/GameOver.tscn");
		}
	}

	public void _on_timer_timeout() {
		Value = Value - 5;
		// if value <= 0 then die
	}
	
	private void _on_area_2d_body_entered(Node2D body)
	{
		// Replace with function body.
		Value = Value + 20;
		AudioStreamPlayer stream_player = GetNode<AudioStreamPlayer>("%BananaSlipPlayer");
		stream_player.Play();
		// play sound
	}
}

