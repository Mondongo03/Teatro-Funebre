using Godot;
using System;
using System.IO;

/// <summary>
/// Clase que nos permite gestionar como funciona el ojo del gnomo
/// </summary>
public partial class Ojo : Area2D
{
	Sprite2D sprite;
	bool puedoMover = false;

	public static bool guardado = false;

	 

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
			
		sprite = GetChild<Sprite2D>(0);
	}

	/// <summary>
	/// Señal de godot que nos permite saber cuando el raton entra en el area de un objeto
	/// </summary>
	public override void _Process(double delta) 
	{
		if (puedoMover) this.GlobalPosition = GetGlobalMousePosition();
		
		if(Cofre.abierto && guardado){
			sprite.Visible = true;
		}
		
	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="event">Nos permite detectar cuando se hace click</param>
	/// <param name="shape_idx">Variable que se utiliza para la API</param>
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsActionPressed("click_izquierdo") && !MueveTeEnElBosque.comenzar && Ramon.stepTexto>=1) {
			puedoMover = true;
			sprite.Visible = true;
		}
		if (@event.IsActionReleased("click_izquierdo"))
		{
			puedoMover = false;
		}
	}

	/// <summary>
	/// Señal de godot que nos permite comprobar si la colision de un objeto colisiona contra otro objeto
	/// </summary>
	/// <param name="collisionObject2D">Variable de la colision del objeto que colisiona con el objeto</param>
	private void _on_area_entered(CollisionObject2D collisionObject2D) {
		if (collisionObject2D.IsInGroup("GnomoSinCosas") && !MueveTeEnElBosque.comenzar)
		{
			sprite.Visible = false;
		}
	}

	/// <summary>
	/// Señal de godot que nos permite comprobar si la colision de un objeto deja de colisionar contra otro objeto
	/// </summary>
	/// <param name="collisionObject2D">Variable de la colision del objeto que colisiona con el objeto</param>
	private void _on_area_exited(CollisionObject2D collisionObject2D)
	{
		if (collisionObject2D.IsInGroup("GnomoSinCosas") && !MueveTeEnElBosque.comenzar)
		{
			sprite.Visible = true;
		}
	}
}
