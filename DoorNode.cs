using Godot;
using System;

public partial class DoorNode : Node2D
{
	bool isOpen= false;
	Area2D doorcollision = GetNode<Area2D>("Area2D");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{


	}
}
