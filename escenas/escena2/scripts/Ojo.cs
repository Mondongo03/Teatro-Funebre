using Godot;
using System;

public partial class Ojo : Area2D
{
	Sprite2D sprite;
	bool puedoMover = false;
	public override void _Ready() {
		sprite = GetChild<Sprite2D>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if(puedoMover){
			Position = GetGlobalMousePosition();
		}
	}
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {
	 if(@event.IsActionPressed("click_izquierdo")){
			puedoMover = true;
			sprite.Visible = true;
		}
		if(@event.IsActionReleased("click_izquierdo")){
			puedoMover = false;
		}
	}
	private void _on_area_entered(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("GnomoSinCosas")&& !MueveTeEnElBosque.comenzar) {
				sprite.Visible = false;
			}
	}
	private void _on_area_exited(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("GnomoSinCosas")&& !MueveTeEnElBosque.comenzar) {
				sprite.Visible = true;
			}
	}
}
