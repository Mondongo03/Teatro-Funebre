using Godot;
using System;

public partial class MegaPoti : Area2D
{
	static bool puedoMover = false;
	Sprite2D spriteVacio, spriteLleno;
	static MegaPoti objetoEnMovimiento = null;
	public static bool lleno = false;
	public override void _Ready() {
		spriteVacio = GetChild<Sprite2D>(0);
		spriteLleno = GetChild<Sprite2D>(1);
		if(lleno){
			spriteVacio.Visible = false;
			spriteLleno.Visible = true;
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (puedoMover && objetoEnMovimiento == this) this.GlobalPosition = GetGlobalMousePosition();
	}
		private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {

		if (@event.IsActionPressed("click_izquierdo")) {
			puedoMover = true;
			objetoEnMovimiento = this;
		}
		if (@event.IsActionReleased("click_izquierdo")) {
			puedoMover = false;
			objetoEnMovimiento = null;
		}
	}

	private void _on_area_entered(CollisionObject2D collisionObject2D) {
		if (collisionObject2D.IsInGroup("Caldero") && Caldero.contador >=4) {
			spriteVacio.Visible = false;
			spriteLleno.Visible = true;
			lleno = true;
		}
	}
}
