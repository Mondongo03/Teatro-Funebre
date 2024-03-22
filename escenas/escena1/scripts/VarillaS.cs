using Godot;
using Microsoft.VisualBasic;
using System;

public partial class VarillaS : Area2D {

	bool puedoMover = false;
	public static Boolean encontrado = false;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		if(Main.varillaSegundosReloj){
			if (Main.varillaMinutosInstancia.Rotation <3.45 && Main.varillaSegundosInstancia.Rotation <20.35) {
				rotar();
				
				}
			}
		if(puedoMover){
			Position = GetGlobalMousePosition();
		}
		GD.Print("Rotación: "+Rotation);
		GD.Print(Main.varillaMinutosInstancia.Rotation);
				GD.Print(Main.varillaSegundosInstancia.Rotation);
				Main.varillaMinutosInstancia.Rotation = (float)((Main.varillaSegundosInstancia.Rotation /5)*0.846);
	
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap){
		if(evento.IsActionPressed("click_izquierdo")){
			puedoMover = true;
			encontrado = true;

		}
		if(evento.IsActionReleased("click_izquierdo")){
			puedoMover = false;
			encontrado = true;
		}
	}

	public Boolean devolverClickado(){
		return encontrado;
	}
	public void rotar(){
		
			LookAt(GetGlobalMousePosition());
		
		
	}
}
