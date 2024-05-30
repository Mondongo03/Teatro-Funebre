using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar al hueso del gnomo
/// </summary>
public partial class Hueso : Area2D
{

	Sprite2D sprite;
	bool puedoMover = false;

	bool postAnimacion = false;
	public static bool guardado = false;
	public static int clicks = 0;
	public static bool metidoEnCaldero = false;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{

		sprite = GetChild<Sprite2D>(0);

		comprobarSkin();

	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (puedoMover) this.GlobalPosition = GetGlobalMousePosition();

		if (Cofre.abierto && guardado)
		{
			sprite.Visible = true;
		}
		if (this.IsInGroup("HuesoGnomo") && !MueveTeEnElBosque.comenzar && !postAnimacion)
		{
			sprite.Visible = true;
			postAnimacion = true;
		}
		if (this.IsInGroup("Hueso"))

			comprobarSkin();

	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="event">Nos permite detectar cuando se hace click</param>
	/// <param name="shape_idx">Variable que se utiliza para la API</param>
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{

		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Hueso") && !MueveTeEnElBosque.comenzar)
		{
			puedoMover = true;
			sprite.Visible = true;
		}
		if (@event.IsActionReleased("click_izquierdo") && this.IsInGroup("Hueso"))
		{
			puedoMover = false;
			clicks++;
		}
	}

	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo entra en el colision, este metodo es una señal de godot
	/// </summary>
	/// <param name="collisionObject2D">Es la variable que nos dice el donde a entrado un objeto</param>
	private void _on_area_entered(CollisionObject2D collisionObject2D)
	{
		if (collisionObject2D.IsInGroup("HuesoGnomo") && !MueveTeEnElBosque.comenzar && this.IsInGroup("Hueso"))
		{
			sprite.Visible = false;
		}
		else if (collisionObject2D.IsInGroup("Hueso") && !MueveTeEnElBosque.comenzar && this.IsInGroup("HuesoGnomo"))
		{
			sprite.Visible = true;
		}
	}

	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo sale en el colision, este metodo es una señal de godot
	/// </summary>
	/// <param name="collisionObject2D">Es la variable que nos dice el donde a entrado un objeto</param>
	private void _on_area_exited(CollisionObject2D collisionObject2D)
	{
		if (collisionObject2D.IsInGroup("GnomoSinCosas") && !MueveTeEnElBosque.comenzar && this.IsInGroup("Hueso"))
		{
			sprite.Visible = true;
		}
		else if (collisionObject2D.IsInGroup("Hueso") && !MueveTeEnElBosque.comenzar && this.IsInGroup("HuesoGnomo"))
		{
			sprite.Visible = false;
		}
	}

	/// <summary>
	/// Metodo que nos permite gestionar el sprite del hueso he ir cambiadolo cuando llega a x numero de clicks
	/// </summary>
	private void comprobarSkin()
	{
		if (clicks >= 3 && clicks <= 14 && this.IsInGroup("Hueso"))
		{
			sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/Hueso2.png");
		}
		if (clicks >= 15 && clicks <= 29 && this.IsInGroup("Hueso"))
		{
			sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/Hueso3.png");
		}
		if (clicks >= 30 && this.IsInGroup("Hueso"))
		{
			sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/Hueso4.png");
		}
	}
}
