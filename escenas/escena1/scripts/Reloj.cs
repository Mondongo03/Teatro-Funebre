using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

public partial class Reloj : Area2D {
	
	public static bool zoooom = false;
    public override void _Ready(){
		
    }

    public override void _Process(double delta){
		GD.Print("Posicion Varilla M: "+ Main.varillaMinutosInstancia.Rotation);
		GD.Print("Posicion Varilla S: "+ Main.varillaSegundosInstancia.Rotation);
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
		if(evento.IsActionPressed("click_izquierdo") && !zoooom){
			GD.Print("click");
			zoooom = true;
			PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
			Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
			Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
			AddChild(Main.fondoNegroInstancia);

			PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
			Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(Main.relojZoomeadoInstancia);

			PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
			Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
			Main.varillaMinutosInstancia.Position = new Vector2I(235, 80); 
			// Cast the instance to Node
			AddChild(Main.varillaMinutosInstancia);

			PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
			Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
			Main.varillaSegundosInstancia.Position = new Vector2I(235, 80); // Cast the instance to Node
			AddChild(Main.varillaSegundosInstancia);
		}
	}
	public static Boolean GetZoom() {
        return zoooom;
    }

    // Método público para establecer el valor de zoooom
    public static void SetZoom(Boolean value) {
        zoooom = value;
    }
}
