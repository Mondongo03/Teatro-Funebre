using Godot;
using System;

public partial class Sangre : Area2D {
	static bool puedoMover = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (puedoMover) this.GlobalPosition = GetGlobalMousePosition();
	}
		private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {
		
		if (@event.IsActionPressed("click_izquierdo")) {
			puedoMover = true;
		}
		if (@event.IsActionReleased("click_izquierdo")) {
			puedoMover = false;
		}
	}
}
