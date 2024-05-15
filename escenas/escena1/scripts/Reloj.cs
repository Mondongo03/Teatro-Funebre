using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

/// <summary>
/// Clase que nos permite gestionar como funciona el Reloj y que pueda almacenar objetos dentro del mismo
/// </summary>
public partial class Reloj : Area2D
{

	public static bool zoooom = false;
	public static bool terminado = false;
	public static bool suena = false;
	public static Node2D miniVarillaMInstancia;
	public static Node2D miniVarillaSInstancia;
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (terminado && !suena)
		{
			audioStreamPlayer2D.Play();
			suena = true;
		}
	}

	/// <summary>
	/// Señal de godot que nos permite comprobar si la colision de un objeto colisiona contra la colision del reloj
	/// </summary>
	/// <param name="collisionObject2D">Variable de la colision del objeto que colisiona con el reloj</param>
	public void _on_reloj_entered(CollisionObject2D collisionObject2D) {
		if (collisionObject2D.IsInGroup("VarillaM") && Main.varillaMinutosInstancia != null)
		{

			collisionObject2D.QueueFree();
			Main.varillaMinutosReloj = true;
			PackedScene miniVarillaM = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/miniVarillaM.tscn");
			miniVarillaMInstancia = miniVarillaM.Instantiate() as Node2D;
			AddChild(miniVarillaMInstancia);

		}
		if (collisionObject2D.IsInGroup("VarillaS"))
		{
			Main.varillaSegundosReloj = true;
			collisionObject2D.QueueFree();
			PackedScene miniVarillaS = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/miniVarillaS.tscn");
			miniVarillaSInstancia = miniVarillaS.Instantiate() as Node2D;
			AddChild(miniVarillaSInstancia);
		}
	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="evento">Nos permite detectar cuando se hace click</param>
	/// <param name="shap">Variable que se utiliza para la API</param>
	public void _on_input_event(Node viewport, InputEvent evento, int shap)
	{
		if (evento.IsActionPressed("click_izquierdo") && !RelojZoomeado.zoooom && !Cajon.zoooom)
		{
			if (!VarillaM.encontrado && !VarillaS.encontrado)
			{
				Main.varillaMinutosInstancia.ZIndex = -1;
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D;
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

			}
			else if (VarillaM.encontrado && !VarillaS.encontrado)
			{
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D;
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
				Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
				Main.varillaMinutosInstancia.Position = new Vector2I(235, 80);
				Main.varillaMinutosInstancia.ZIndex = 5;
				AddChild(Main.varillaMinutosInstancia);

			}
			else if (!VarillaM.encontrado && VarillaS.encontrado)
			{
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D;
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				Main.varillaMinutosInstancia.ZIndex = -1;
				PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
				Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
				Main.varillaSegundosInstancia.Position = new Vector2I(235, 80);
				Main.varillaSegundosInstancia.ZIndex = 5;
				AddChild(Main.varillaSegundosInstancia);

			}
			else if (VarillaM.encontrado && VarillaS.encontrado && !Cajon.encontrado && !terminado)
			{
				zoooom = true;
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D;
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
				Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
				Main.varillaMinutosInstancia.Position = new Vector2I(235, 80);
				Main.varillaMinutosInstancia.ZIndex = 5;
				AddChild(Main.varillaMinutosInstancia);

				PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
				Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
				Main.varillaSegundosInstancia.Position = new Vector2I(235, 80);
				Main.varillaSegundosInstancia.ZIndex = 5;
				AddChild(Main.varillaSegundosInstancia);

			}
			else if (VarillaM.encontrado && VarillaS.encontrado && Cajon.encontrado && !terminado)
			{
				zoooom = true;
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D;
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
				Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
				Main.varillaMinutosInstancia.Position = new Vector2I(235, 80);
				Main.varillaMinutosInstancia.ZIndex = 5;
				AddChild(Main.varillaMinutosInstancia);

				PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
				Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
				Main.varillaSegundosInstancia.Position = new Vector2I(235, 80);
				Main.varillaSegundosInstancia.ZIndex = 5;
				AddChild(Main.varillaSegundosInstancia);

			}
		}
	}

	/// <summary>
	/// Getter de la variable zooom
	/// </summary>
	/// <returns>Devuelve la variable zooom</returns>
	public static Boolean GetZoom()
	{
		return zoooom;
	}

	/// <summary>
	/// Setter de la variable zooom
	/// </summary>
	/// <param name="value">Cambio de la variable zooom</param>
	public static void SetZoom(Boolean value)
	{
		zoooom = value;
	}
}
