using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar al nmarrador en cada escena que empieza
/// </summary>
public partial class Narracion : Area2D
{
	public static Node2D pistasInstancia;
	public static bool pistasAbiertas;

    /// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="event">Nos permite detectar cuando se hace click</param>
    /// <param name="shape_idx">Variable que se utiliza para la API</param>
    void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsActionPressed("click_izquierdo") && !this.IsInGroup("Pista"))
		{
			pistasAbiertas = false;
			this.QueueFree();
		}
		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Escena1") && !pistasAbiertas)
		{
			instanciarYAgregarNodo("res://escenas/Pistas/PistasEscena1.tscn", ref pistasInstancia);
			pistasAbiertas = true;
			pistasInstancia.Position = new Vector2I(-1064, -72);
		}

		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Escena2") && !pistasAbiertas)
		{
			instanciarYAgregarNodo("res://escenas/Pistas/PistasEscena2.tscn", ref pistasInstancia);
			pistasAbiertas = true;
			pistasInstancia.Position = new Vector2I(-1017, -26);
		}
		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Escena3") && !pistasAbiertas)
		{
			instanciarYAgregarNodo("res://escenas/Pistas/PistasEscena3.tscn", ref pistasInstancia);
			pistasAbiertas = true;
			pistasInstancia.Position = new Vector2I(-1017, -26);
		}

	}

	/// <summary>
    /// Método que instancia todos los elementos de la escena y los añade a su respectivo padre
    /// </summary>
	private void instanciarYAgregarNodo(String rutaEscena, ref Node2D node2D)
	{
		PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
		node2D = escena.Instantiate() as Node2D;
		AddChild(node2D);
	}
}
