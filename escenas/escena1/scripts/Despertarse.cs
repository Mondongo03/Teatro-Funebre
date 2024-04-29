using Godot;
using System;

public partial class Despertarse : PathFollow2D
{

	float speed = 0.2f;
	[Export]
	private AnimatedSprite2D animatedSprite2D;
	public static bool funciona,camina = false;
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(funciona == true)
		{
			animatedSprite2D.Play("CaminarDerecha");
			ProgressRatio += (float)delta * speed;
		
			if(!camina){
				audioStreamPlayer2D.Play();
				camina = true;
			}
		}
	}

	public void despertar(bool boolean)
	{
		funciona = boolean;
	}
}