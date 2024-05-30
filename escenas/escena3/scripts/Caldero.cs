using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar el puzle del caldero
/// </summary>
public partial class Caldero : Area2D
{
	AnimatedSprite2D rojo;
	AnimatedSprite2D verde;
	AnimatedSprite2D azul;
	AnimatedSprite2D rosa;
	Sprite2D vacio;
	public static int contador = 1;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		rojo = GetChild<AnimatedSprite2D>(0);
		verde = GetChild<AnimatedSprite2D>(1);
		rosa = GetChild<AnimatedSprite2D>(2);
		azul = GetChild<AnimatedSprite2D>(3);
		vacio = GetChild<Sprite2D>(4);
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (contador == 1)
		{
			rojo.Visible = true;
			verde.Visible = false;
			rosa.Visible = false;
			azul.Visible = false;

		}
		if (contador == 2)
		{
			rojo.Visible = false;
			verde.Visible = true;
			rosa.Visible = false;
			azul.Visible = false;

		}
		if (contador == 3)
		{
			rojo.Visible = false;
			verde.Visible = false;
			rosa.Visible = true;
			azul.Visible = false;

		}
		if (contador == 4)
		{
			rojo.Visible = false;
			verde.Visible = false;
			rosa.Visible = false;
			azul.Visible = true;

		}
		if (MegaPoti.lleno)
		{
			azul.Visible = false;
			vacio.Visible = true;
		}
	}

	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo entra en el colision, este metodo es una señal de godot
	/// </summary>
	/// <param name="collisionObject2D">Es la variable que nos dice el donde a entrado un objeto</param>
	void _on_area_entered(CollisionObject2D collisionObject2D)
	{
		if (collisionObject2D.IsInGroup("Vial") || collisionObject2D.IsInGroup("FlorBuena") || collisionObject2D.IsInGroup("Hueso") && Hueso.clicks >= 30)
		{
			contador++;
			if (collisionObject2D.IsInGroup("FlorBuena")) Flor.metidoEnCaldero = true;
			if (collisionObject2D.IsInGroup("Hueso")) Hueso.metidoEnCaldero = true;
			collisionObject2D.QueueFree();
		}
	}
}
