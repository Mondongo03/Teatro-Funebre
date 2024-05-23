using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar las respuesta que da el jugador a Ramon

public partial class RespuestasRamon : Area2D {
	Sprite2D sprite1;
	Sprite2D sprite2;
	public static bool jugar = false;
	public static bool pasar = false;
	
	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		sprite1 = GetChild<Sprite2D>(0);
		sprite2 = GetChild<Sprite2D>(1);
	}

	/// <summary>
	/// Señal de godot que nos permite saber cuando el raton entra en el area de un objeto
	/// </summary>
	void _on_mouse_entered()
	{
		sprite2.Visible = false;
	}

	/// <summary>
	/// Señal de godot que nos permite saber cuando el raton sale en el area de un objeto
	/// </summary>
	void _on_mouse_exited()
	{
		sprite2.Visible = true;
	}

	/// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="event">Nos permite detectar cuando se hace click</param>
    /// <param name="shape_idx">Variable que se utiliza para la API</param>
	void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Si"))
		{
			jugar = true;
			GetTree().ChangeSceneToFile("res://escenas/escena2.5/CartasCartitas.tscn");
			GD.Print("Jugar");
		}
		else if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("No"))
		{
			pasar = true;
			GD.Print("Pasar");
		}
	}
}
