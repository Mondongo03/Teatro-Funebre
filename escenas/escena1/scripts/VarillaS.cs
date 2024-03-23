using Godot;
using Microsoft.VisualBasic;
using System;

public partial class VarillaS : Area2D {

	bool puedoMover = false;
	public static bool encontrado = false;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		if(Main.varillaSegundosReloj && Main.varillaMinutosReloj && !Reloj.terminado){
			if(Cajon.encontrado){
			if (Main.varillaMinutosInstancia.Rotation <3.45F && Main.varillaSegundosInstancia.Rotation <20.35F) {
				rotar();
				
				}
				if(Main.varillaMinutosInstancia.Rotation >=3.45F && Main.varillaSegundosInstancia.Rotation >=20.35F && Cajon.encontrado){ 
					Reloj.terminado = true;
					Main.varillaMinutosInstancia.QueueFree();
					Main.varillaSegundosInstancia.QueueFree();
					Main.fondoNegroInstancia.QueueFree();
					Main.relojZoomeadoInstancia.QueueFree();
				}
			}
		}if(!Cajon.encontrado){
			if(Reloj.zoooom){
				rotar();
			}
		}
		if(puedoMover){
			Position = GetGlobalMousePosition();
		}

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
			if(!Reloj.terminado) LookAt(GetGlobalMousePosition()/1.3F);
		
	}

	public static Boolean GetClickado(){
		return encontrado;
	}
}
