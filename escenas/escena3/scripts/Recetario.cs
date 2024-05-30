using Godot;
using System;

/// <summary>
/// Clase para gestionar el recetario del desban 
/// </summary>
public partial class Recetario : Area2D
{
	static bool zoom = false;
	PackedScene escena;
	Node2D node2D;

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="event">Nos permite detectar cuando se hace click</param>
	/// <param name="shape_idx">Variable que se utiliza para la API</param>
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {

		if (@event.IsActionPressed("click_izquierdo") && !zoom && this.IsInGroup("Recetario")) {
			zoom = true;
		escena = (PackedScene)ResourceLoader.Load("res://escenas/escena3/objects/recetarioZoomeado.tscn");
        node2D = escena.Instantiate() as Node2D;
		node2D.Position = new Vector2I(-259, -350);
        AddChild(node2D);
		}
		else if (@event.IsActionPressed("click_izquierdo") && zoom && this.IsInGroup("RecetarioZoomeado")) {
			zoom = false;
			QueueFree();
        	AddChild(node2D);
		}
	}
}
