using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
public partial class CartasCartitas : Node2D {

	public static int[] cartas = { 0, 1, 2 };
	public static int intento = 0;
	public static bool victoria = false;
	float speed = 1f;
	bool remenar;
	Timer timer;
	public static bool animacionBarajarCartas = false;
	[Export] public PathFollow2D sol, estrella, luna;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		remenar = true;
		barajarCartas();
		timer = new Timer();
        AddChild(timer);
        timer.OneShot = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public async override void _Process(double delta) {
			if(remenar){
			sol.ProgressRatio += (float)delta * speed;
			estrella.ProgressRatio += (float)delta * speed;
			luna.ProgressRatio += (float)delta * speed;
			}

		if(intento >0 && !victoria){
			barajarCartas();
			intento--;
			timer.Start(1);
        	await ToSignal(timer, "timeout");
			sol.ProgressRatio =0;
			estrella.ProgressRatio =0;
			luna.ProgressRatio =0;
			sol.ProgressRatio += (float)delta * speed;
			estrella.ProgressRatio += (float)delta * speed;
			luna.ProgressRatio += (float)delta * speed;
			CartaTarot.clickDisponible = true;
		}
		if(luna.ProgressRatio!=1 && sol.ProgressRatio!=1 && estrella.ProgressRatio!=1) animacionBarajarCartas = true;
		else animacionBarajarCartas = false;
	}
	void barajarCartas(){
		Random rnd = new Random();

		// Ordenar el array aleatoriamente
		cartas = cartas.OrderBy(x => rnd.Next()).ToArray();
	}
}
