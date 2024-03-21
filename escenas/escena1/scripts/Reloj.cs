using Godot;
using System;

public partial class Reloj : Area2D {
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
				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
			Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(Main.relojZoomeadoInstancia);

			PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
			Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(Main.varillaMinutosInstancia);

			PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
			Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
			Main.varillaSegundosInstancia.Position = new Vector2I(280, 100); // Cast the instance to Node
			AddChild(Main.varillaSegundosInstancia);
		}
	}
}
