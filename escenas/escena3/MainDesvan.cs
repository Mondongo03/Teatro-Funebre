using Godot;
using System;

/// <summary>
/// Escript que nos permite gestionar como funciona la escena 3
/// </summary>
public partial class MainDesvan : Node2D
{
	[Export] public Area2D unicornioRojo,unicornioVerde,unicornioAmarillo,unicornioNaranja,unicornioBlanco;
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;
	private static bool ritualAcabado;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(ritualAcabado);
		audioStreamPlayer2D.Play();
		if(ritualAcabado)
		{
			unicornioRojo.QueueFree();
			unicornioVerde.QueueFree();
			unicornioAmarillo.QueueFree();
			unicornioNaranja.QueueFree();
			unicornioBlanco.QueueFree();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static void setRitualAcabado(bool ritual)
	{
		ritualAcabado = ritual;
	}

	public static bool getRitualAcabado()
	{
		return ritualAcabado;
	}
}
