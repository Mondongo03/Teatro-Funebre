using Godot;
using System;

/// <summary>
/// Clase de la escena final del proyecto
/// </summary>
public partial class Final2EstaVezEsPersonal : Area2D
{
	/// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="event">Nos permite detectar cuando se hace click</param>
    /// <param name="shape_idx">Variable que se utiliza para la API</param>
	void _on_input_event(Node viewport, InputEvent @event, long shape_idx){
        if (@event.IsActionPressed("click_izquierdo")) {
            GetTree().Quit();
        }
    }
	
}
