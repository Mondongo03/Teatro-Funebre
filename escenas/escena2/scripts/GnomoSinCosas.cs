using Godot;
using System;

public partial class GnomoSinCosas : Area2D
{
	public static Sprite2D sprite;
	public override void _Ready() {
		sprite = GetChild<Sprite2D>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_area_entered(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("Ojo")&& !MueveTeEnElBosque.comenzar) {
				sprite.Visible = false;
			}
	}
	private void _on_area_exited(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("Ojo")&& !MueveTeEnElBosque.comenzar) {
				sprite.Visible = true;
			}
	}
}
