using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

/// <summary>
/// Script que nos permite gestionar como funciona la lampara de la primera escena
/// </summary>
public partial class Lampara : Area2D
{
	[Export] public Sprite2D sprite2D;
	public bool encendido = false;

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
				sprite2D.Texture = (Texture2D)GD.Load("res://escenas/escena1/assets/Lampara apagada.png");
				encendido = false;
			}
			else
			{
				sprite2D.Texture = (Texture2D)GD.Load("res://escenas/escena1/assets/Lampara encendida.png");
				encendido = true;
			}
		}
	}
}
