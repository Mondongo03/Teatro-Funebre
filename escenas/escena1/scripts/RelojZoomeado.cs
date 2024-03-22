using Godot;
using System;

public partial class RelojZoomeado : Area2D {
	
	Reloj reloj = new Reloj();
    public override void _Ready(){
		
    }

    public override void _Process(double delta){
				
	}

	public void _on_reloj_entered(CollisionObject2D collisionObject2D){


		if (collisionObject2D.IsInGroup("VarillaM") && Main.varillaMinutosInstancia != null){
		GD.Print("Varilla a entrau");
		collisionObject2D.QueueFree();
		Main.varillaMinutosReloj = true;

	
		}
		if (collisionObject2D.IsInGroup("VarillaS")){
		GD.Print("Varilla a entrau");
		Main.varillaSegundosReloj = true;
		collisionObject2D.QueueFree();
	
		}
	}

	public void _on_reloj_exited(CollisionObject2D collisionObject2D){
		if (collisionObject2D.IsInGroup("VarillaM") && Main.varillaMinutosInstancia != null){
		GD.Print("Varilla a saliu");
		}
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap){
		if(evento.IsActionPressed("click_izquierdo")){
			GD.Print("click");
			Reloj.zoooom = false;
			Main.varillaSegundosInstancia.QueueFree();
			Main.varillaMinutosInstancia.QueueFree();
			QueueFree();
			Main.fondoNegroInstancia.QueueFree();
			
		}
	}
}
