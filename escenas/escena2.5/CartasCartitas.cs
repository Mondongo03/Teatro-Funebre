using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
public partial class CartasCartitas : Node2D
{

	public static int[] cartas = { 0, 1, 2 };
	public static int intento = 0;
	public static bool victoria = false;
	float speed = 1f;
	bool remenar;
	Timer timer;
	public static bool empezamos = false;
	public static bool animacionBarajarCartas = false;
	[Export] public PathFollow2D sol, estrella, luna;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		remenar = true;
		barajarCartas();
		timer = new Timer();
		AddChild(timer);
		timer.OneShot = false;

	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public async override void _Process(double delta)
	{
		if (remenar)
		{
			sol.ProgressRatio += (float)delta * speed;
			estrella.ProgressRatio += (float)delta * speed;
			luna.ProgressRatio += (float)delta * speed;
		}

		if (intento > 0 && !victoria)
		{
			barajarCartas();
			intento--;
			timer.Start(1);
			await ToSignal(timer, "timeout");
			sol.ProgressRatio = 0;
			estrella.ProgressRatio = 0;
			luna.ProgressRatio = 0;
			sol.ProgressRatio += (float)delta * speed;
			estrella.ProgressRatio += (float)delta * speed;
			luna.ProgressRatio += (float)delta * speed;
			CartaTarot.clickDisponible = true;
		}
		if (luna.ProgressRatio != 1 && sol.ProgressRatio != 1 && estrella.ProgressRatio != 1) animacionBarajarCartas = true;
		else animacionBarajarCartas = false;

		if (victoria)
		{
			cambioEscena();
		}
	}

	/// <summary>
	/// Metodo que nos permite gestionar como se barajan las cartas dentro del codigo
	/// </summary>
	void barajarCartas()
	{
		Random rnd = new Random();

		// Ordenar el array aleatoriamente
		cartas = cartas.OrderBy(x => rnd.Next()).ToArray();
	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="event">Nos permite detectar cuando se hace click</param>
	/// <param name="shape_idx">Variable que se utiliza para la API</param>
	void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("TextoInicioCartas"))
		{
			QueueFree();
			CartaTarot.clickDisponible = true;
		}
	}

	/// <summary>
	/// Metodo asincrono que nos permite volver a la escena anterior
	/// </summary>
	/// <returns></returns>
	async void cambioEscena()
	{
		GetTree().ChangeSceneToFile("res://escenas/escena2/Prueba.tscn");
	}
}
