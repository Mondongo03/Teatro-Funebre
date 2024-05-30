using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar al gnomo cuando esta tumbado en el suelo
/// </summary>
public partial class GnomoSinCosas : Area2D
{
	public static Sprite2D sprite;
	public static bool animacionTerminada = false;
	public static bool tullido = false;
	public static bool crecer = false;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready() {
		sprite = GetChild<Sprite2D>(0);
		
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta) {
		if(animacionTerminada) sprite.Visible = true;
		
	}

	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo entra en el colision, este metodo es una señal de godot
	/// </summary>
	/// <param name="collisionObject2D">Es la variable que nos dice el donde a entrado un objeto</param>
	private void _on_area_entered(CollisionObject2D collisionObject2D) {
		if (collisionObject2D.IsInGroup("Ojo")&& !MueveTeEnElBosque.comenzar) {
			sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/gnomoTullido.png");
			tullido = true;
		}
		if(collisionObject2D.IsInGroup("MegaPoti") && MegaPoti.lleno){
			crecer = true;
			collisionObject2D.QueueFree();
			Escena2.huesoPegadoCuerpo.QueueFree();
			this.QueueFree();
		}
	}

	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo sale en el colision, este metodo es una señal de godot
	/// </summary>
	/// <param name="collisionObject2D">Es la variable que nos dice el donde a entrado un objeto</param>
	private void _on_area_exited(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("Ojo")&& !MueveTeEnElBosque.comenzar) {
				sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/gnomoTullidoSinOjo.png");
				tullido = false;
			}
	}
}
