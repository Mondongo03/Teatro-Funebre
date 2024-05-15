using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
public partial class CartasCartitas : Node2D {

	public static int[] cartas = { 0, 1, 2 };
	public static int intento = 0;
	public static bool victoria = false;
	float speed = 0.3f;
	bool remenar;
	[Export] public PathFollow2D sol, estrella, luna;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		remenar = true;

		barajarCartas();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if(intento >0 && !victoria){
			barajarCartas();
			intento--;
		}
		if (remenar)
		{
			sol.ProgressRatio += (float)delta * speed;
			estrella.ProgressRatio += (float)delta * speed;
			luna.ProgressRatio += (float)delta * speed;
		}
	}
	void barajarCartas(){
		Random rnd = new Random();

		// Ordenar el array aleatoriamente
		cartas = cartas.OrderBy(x => rnd.Next()).ToArray();

		// Imprimir los elementos del array
		foreach (int numero in cartas)
		{
			GD.Print(numero);
		}
	}
}
