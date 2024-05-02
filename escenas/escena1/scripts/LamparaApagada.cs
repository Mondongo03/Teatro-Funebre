using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

/// <summary>
/// Clase que nos permite gestinar cuando se enciende y se apaga la lampara de la primera escena
/// </summary>
public partial class LamparaApagada : Area2D
{

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
			PackedScene lamparaEncendida = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaEncendida.tscn");
			Main.lamparaEncendidaInstancia = lamparaEncendida.Instantiate() as Node2D; // Cast the instance to Node
			Main.lamparaEncendidaInstancia.ZIndex = 2;
			Main.lamparaEncendidaInstancia.Position = new Vector2I(0, 0);
			AddChild(Main.lamparaEncendidaInstancia);
		}
	}
}
