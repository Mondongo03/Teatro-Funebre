using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar el producto final del ritual
/// </summary>
public partial class Sangre : Area2D
{
	static bool puedoMover = false;


	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (puedoMover) this.GlobalPosition = GetGlobalMousePosition();
	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="event">Nos permite detectar cuando se hace click</param>
	/// <param name="shape_idx">Variable que se utiliza para la API</param>
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{

		if (@event.IsActionPressed("click_izquierdo"))
		{
			puedoMover = true;
		}
		if (@event.IsActionReleased("click_izquierdo"))
		{
			puedoMover = false;
		}
	}
}
