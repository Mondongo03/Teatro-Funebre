using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

public partial class Cajon : Area2D {

public static Boolean encontrado = false;
public static Boolean zoooom = false;
[Export] public AudioStreamPlayer2D abrir;

private AnimationPlayer animPlayer;


	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

public void _on_input_event(Node viewport, InputEvent evento, int shap){
	if(evento.IsActionPressed("click_izquierdo")&& !zoooom && !Reloj.zoooom){
	encontrado = true;
	zoooom = true;
	abrir.Play();

	PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
	Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
	Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
	Main.fondoNegroInstancia.ZIndex = 1;
	AddChild(Main.fondoNegroInstancia);

	PackedScene cajonZoomeado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/cajonZoomeado.tscn");
	Main.cajonZoomeadoInstancia = cajonZoomeado.Instantiate() as Node2D; 
	Main.cajonZoomeadoInstancia.ZIndex = 10;
	AddChild(Main.cajonZoomeadoInstancia);

	}
}

}
