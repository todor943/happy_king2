using Godot;
using System;

public partial class DoorSprite2D : Sprite2D
{

	private bool isOpen = false;

	private CollisionShape2D blockedNode ; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		blockedNode = GetNode<CollisionShape2D>("%DoorBlock2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(isOpen) {
			Frame = 1;
			blockedNode.Disabled = true;
			//GetTree().ChangeSceneToFile("res://Scenes/Win.tscn");
		}
		else {
			Frame = 0;
			blockedNode.Disabled = false;
		}
	}
	
	private void _on_body_entered(Node2D body)
	{
		
		isOpen = true;
		
	}
	
	private void _on_area_2d_body_exited(Node2D body)
	{
		isOpen = false;
	}
}






