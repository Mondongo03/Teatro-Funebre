using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar el estado de la pocion del puzle de la escena 2
/// </summary>
public partial class MegaPoti : Area2D
{
	static bool puedoMover = false;
	Sprite2D spriteVacio, spriteLleno;
	static MegaPoti objetoEnMovimiento = null;
	public static bool lleno = false;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		spriteVacio = GetChild<Sprite2D>(0);
		spriteLleno = GetChild<Sprite2D>(1);
		if (lleno)
		{
			spriteVacio.Visible = false;
			spriteLleno.Visible = true;
		}

	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (puedoMover && objetoEnMovimiento == this) this.GlobalPosition = GetGlobalMousePosition();
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
			objetoEnMovimiento = this;
		}
		if (@event.IsActionReleased("click_izquierdo"))
		{
			puedoMover = false;
			objetoEnMovimiento = null;
		}
	}

	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo entra en el colision, este metodo es una señal de godot
	/// </summary>
	/// <param name="collisionObject2D">Es la variable que nos dice el donde a entrado un objeto</param>
	private void _on_area_entered(CollisionObject2D collisionObject2D)
	{
		if (collisionObject2D.IsInGroup("Caldero") && Caldero.contador >= 4)
		{
			spriteVacio.Visible = false;
			spriteLleno.Visible = true;
			lleno = true;
			GD.Print("Caaaaaaaaaaalderooooooo");
		}
	}
}
