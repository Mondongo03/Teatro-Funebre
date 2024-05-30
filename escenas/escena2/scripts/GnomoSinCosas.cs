using Godot;
using System;

public partial class GnomoSinCosas : Area2D
{
	public static Sprite2D sprite;
	public static bool animacionTerminada = false;
	public static bool tullido = false;
	public static bool crecer = false;
	public override void _Ready() {
		sprite = GetChild<Sprite2D>(0);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if(animacionTerminada) sprite.Visible = true;
		
	}
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
	private void _on_area_exited(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("Ojo")&& !MueveTeEnElBosque.comenzar) {
				sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/gnomoTullidoSinOjo.png");
				tullido = false;
			}
	}
}
