using Godot;
using System;

public partial class RelojZoomeado : Area2D {
	
	Reloj reloj = new Reloj();
	public override void _Ready(){
		
	}

	public override void _Process(double delta){
				
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap){
		if(evento.IsActionPressed("click_izquierdo")){
			Reloj.zoooom = false;
			if(VarillaS.encontrado) Main.varillaSegundosInstancia.QueueFree();

			if(VarillaM.encontrado) Main.varillaMinutosInstancia.QueueFree();
			QueueFree();
			Main.fondoNegroInstancia.QueueFree();
			
		}
	}
}
