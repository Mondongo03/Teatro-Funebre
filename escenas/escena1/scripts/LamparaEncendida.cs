using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

public partial class LamparaEncendida : Area2D {
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

public void _on_input_event(Node viewport, InputEvent evento, int shap){
	if(evento.IsActionPressed("click_izquierdo")){
			GD.Print("Hago click");
    			Main.lamparaEncendidaInstancia.QueueFree();
				QueueFree();
    }
	}

}
