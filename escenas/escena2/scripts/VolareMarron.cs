using Godot;
using System;

public partial class VolareMarron : PathFollow2D
{
	float speed = 0.2f;
	[Export] public AnimatedSprite2D animatedSprite2D;
	bool volar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		volar = true;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(volar){
			animatedSprite2D.Play("volar");
			ProgressRatio += (float)delta * speed;

			if (ProgressRatio == 1){
				animatedSprite2D.Stop();
				volar = false;
			}
		}
	}
}
