using Godot;
using System;

public partial class Despertarse : PathFollow2D
{
	
	float speed = 0.1f;

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
			ProgressRatio += (float)delta * speed;
		}
	}

	public void despertar(bool boolean)
	{
		funciona = boolean;
	}
}
