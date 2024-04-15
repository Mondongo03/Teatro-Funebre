using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

public partial class lamaparaApagada : Area2D {
	public Node2D lamparaEncendidaInstancia;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

public void _on_input_event(Node viewport, InputEvent evento, int shap){
	if(evento.IsActionPressed("click_izquierdo")){
    
	PackedScene lamparaEncendida = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaEncendida.tscn");
			lamparaEncendidaInstancia = lamparaEncendida.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(lamparaEncendidaInstancia);

			


	}
}

}
