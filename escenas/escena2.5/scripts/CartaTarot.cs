using Godot;
using System;

public partial class CartaTarot : Area2D
{
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	
	}
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {
	 if(@event.IsActionPressed("click_izquierdo")){
			GD.Print(this.GetGroups());
			
		}
		
	}
}
