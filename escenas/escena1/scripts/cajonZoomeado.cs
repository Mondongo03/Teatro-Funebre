using Godot;
using System;

public partial class cajonZoomeado : Area2D
{
	[Export] public AudioStreamPlayer2D cerrar;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap){
		if(evento.IsActionPressed("click_izquierdo")){
			Reloj.zoooom = false;
			Cajon.zoooom = false;
			QueueFree();
			Main.fondoNegroInstancia.QueueFree();
		}
	}
}
