using Godot;
using Microsoft.VisualBasic;
using System;

public partial class MoverPrueba : Area2D {

	bool puedoMover = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){

		if(puedoMover){
			 Vector2 mousePosition = GetGlobalMousePosition();
            float xCoordinate = mousePosition.X;
            float yCoordinate = mousePosition.Y;
		}
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap){
		if(evento.IsActionPressed("click_izquierdo")){
			puedoMover = true;
		}
		if(evento.IsActionReleased("click_izquierdo")){
			puedoMover = false;
		}
	}
}