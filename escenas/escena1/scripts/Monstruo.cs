using Godot;
using System;

public partial class Monstruo : Area2D {

	[Export]
	public AnimationPlayer animationPlayer;
	public static bool encontrado = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_input_event(Node viewport, InputEvent evento, int shap){
	if(evento.IsActionPressed("click_izquierdo")){

		GD.Print("LLega");
	if (!encontrado){
		animationPlayer.Play("MonstruoEscondido");
		encontrado = true;
	}
	else{
		animationPlayer.Play("MonstruoEncontrado");
		encontrado = false;
	}
}
}
}
