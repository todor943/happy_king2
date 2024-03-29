using Godot;
using System;

public partial class GuardNode2D : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animPlayer = GetNode<AnimationPlayer>("GuardAnimation");
		animPlayer.Play("standing");

		var buuble_animPlayer = GetNode<AnimationPlayer>("SpeechAnimation");
		buuble_animPlayer.Play("say");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
