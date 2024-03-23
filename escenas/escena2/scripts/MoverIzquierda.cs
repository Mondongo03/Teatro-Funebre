using Godot;
using System;

public partial class MoverIzquierda : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var bola = (PackedScene)ResourceLoader.Load("res://escenas/escena1/Objetos/bola.tscn");
		var godot = (PackedScene)ResourceLoader.Load("res://escenas/escena1/Objetos/godot.tscn");
		var hueco = (PackedScene)ResourceLoader.Load("res://escenas/escena1/Objetos/hueco.tscn");

		var bolaInstancia = bola.Instantiate();
		var godotInstancia = godot.Instantiate();
		var huecoInstancia = hueco.Instantiate();

		AddChild(bolaInstancia);
		AddChild(godotInstancia);
		AddChild(huecoInstancia);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
<<<<<<< HEAD:escenas/escena2/scripts/MoverIzquierda.cs
=======
		
>>>>>>> main:escenas/escena1/scripts/aaaa.cs
	}
}
