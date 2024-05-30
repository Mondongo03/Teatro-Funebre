using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

/// <summary>
/// Clase que nos permite gestionar el cajon de la primera escena
/// </summary>
public partial class Cajon : Area2D
{

	public static Boolean encontrado = false;
	public static Boolean zoooom = false;
	[Export] public AudioStreamPlayer2D abrir;

	private AnimationPlayer animPlayer;

	/// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="evento">Nos permite detectar cuando se hace click</param>
    /// <param name="shap">Variable que se utiliza para la API</param>
	public void _on_input_event(Node viewport, InputEvent evento, int shap)
	{
		if (evento.IsActionPressed("click_izquierdo") && !zoooom && !RelojZoomeado.zoooom)
		{
			encontrado = true;
			zoooom = true;
			abrir.Play();

			PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
			Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
			Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
			Main.fondoNegroInstancia.ZIndex = 4;
			AddChild(Main.fondoNegroInstancia);

			PackedScene cajonZoomeado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/cajonZoomeado.tscn");
			Main.cajonZoomeadoInstancia = cajonZoomeado.Instantiate() as Node2D;
			Main.cajonZoomeadoInstancia.ZIndex = 10;
			AddChild(Main.cajonZoomeadoInstancia);

		}
	}
}
