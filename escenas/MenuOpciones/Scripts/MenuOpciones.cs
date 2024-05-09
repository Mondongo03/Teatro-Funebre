using Godot;
using System;

public partial class MenuOpciones : Node
{
	[Export] public AnimatedSprite2D animatedSprite2D;
	[Export] public CanvasLayer videoSettings, audioSettings;
	[Export] public Button button;
	public override void _Ready()
	{
		animatedSprite2D.Play("abrir");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_color_rect_animation_finished()
    {
        if(animatedSprite2D.Animation.ToString().Equals("cerrar")){
			GetTree().ChangeSceneToFile("escenas/menuInicio/node_2d.tscn");
		}
		if(animatedSprite2D.Animation.ToString().Equals("abrir")){
			videoSettings.Visible = true;
			audioSettings.Visible = true;
		}
    }

	private void _on_button_pressed()
	{
		videoSettings.Visible = false;
		audioSettings.Visible = false;
		animatedSprite2D.Play("cerrar");
	}
}
