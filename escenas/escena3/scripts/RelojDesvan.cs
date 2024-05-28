using Godot;
using System;

public partial class RelojDesvan : Area2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public AnimatedSprite2D animatedSprite2D;
	public override void _Ready() {
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap)
	{
		if (evento.IsActionPressed("click_izquierdo"))
		{
			animatedSprite2D.Play();
			GD.Print("Click");
		}
		}
}
