using Godot;
using System;

public partial class Monstruo : PathFollow2D
{

	float speed = 0.2f;
	[Export]
	private AnimatedSprite2D animatedSprite2D;
	public static bool funciona = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(funciona == true)
		{
			animatedSprite2D.Play("");
			ProgressRatio += (float)delta * speed;
		}
	}

	public void despertar(bool boolean)
	{
		funciona = boolean;
	}
}