using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

/// <summary>
/// Script que nos permite gestionar como funciona la lampara de la primera escena
/// </summary>
public partial class Lampara : Area2D
{
	public static bool encendido = false;

	/// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="evento">Nos permite detectar cuando se hace click</param>
    /// <param name="shap">Variable que se utiliza para la API</param>
	public void _on_input_event(Node viewport, InputEvent evento, int shap)
	{
		if (evento.IsActionPressed("click_izquierdo"))
		{
			if (encendido)
			{
				apagarLampara();

			}
			else
			{
				encenderLampara();
			}

		}
	}

	/// <summary>
	/// Metodo creado para gestionar que se apage la
	/// </summary>
	public void apagarLampara()
	{
		QueueFree();
		PackedScene lamparaApagada = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaApagada.tscn");
		Main.lamparaApagadaInstancia = lamparaApagada.Instantiate() as Node2D; 
																			   
		Main.lamparaApagadaInstancia.Position = new Vector2I(0, 0);
		GD.Print("antes de apagarla");
		AddChild(Main.lamparaApagadaInstancia);

		encendido = false;


	}

	/// <summary>
	/// Metodo creado para gestionar que se encender la lampara
	/// </summary>
	public void encenderLampara()
	{
		QueueFree();
		PackedScene lamparaEncendida = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaEncendida.tscn");
		Main.lamparaEncendidaInstancia = lamparaEncendida.Instantiate() as Node2D;
																				   
		Main.lamparaEncendidaInstancia.Position = new Vector2I(0, 0);
		GD.Print("antes de encenderla");
		AddChild(Main.lamparaEncendidaInstancia);

		encendido = true;


	}
}
