using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar como funciona el cajon cuando salta en pantalla completa
/// </summary>
public partial class CajonZoomeado : Area2D
{
	[Export] public AudioStreamPlayer2D cerrar;

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
			
			QueueFree();
			Main.fondoNegroInstancia.QueueFree();
			Reloj.zoooom = false;
			Cajon.zoooom = false;
		}
	}
}
