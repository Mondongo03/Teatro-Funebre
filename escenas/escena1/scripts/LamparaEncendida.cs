using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

/// <summary>
/// Clase que nos permite gestinar cuando se enciende y se apaga la lampara de la primera escena
/// </summary>
public partial class LamparaEncendida : Area2D
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
			GD.Print("Hago click");
			Main.lamparaEncendidaInstancia.QueueFree();
			QueueFree();
		}
	}
}
