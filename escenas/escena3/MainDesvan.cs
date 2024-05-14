using Godot;
using System;

public partial class MainDesvan : Node2D
{
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audioStreamPlayer2D.Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
