using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

public partial class Reloj : Area2D {
	
	public static bool zoooom = false;
	public static bool terminado = false;
	public override void _Ready(){
		
	}

	public override void _Process(double delta){
	}

	public void _on_reloj_entered(CollisionObject2D collisionObject2D){


		if (collisionObject2D.IsInGroup("VarillaM") && Main.varillaMinutosInstancia != null){
		
		collisionObject2D.QueueFree();
		Main.varillaMinutosReloj = true;

	
		}
		if (collisionObject2D.IsInGroup("VarillaS")){
		Main.varillaSegundosReloj = true;
		collisionObject2D.QueueFree();
	
		}
	}

	public void _on_reloj_exited(CollisionObject2D collisionObject2D){
		if (collisionObject2D.IsInGroup("VarillaM") && Main.varillaMinutosInstancia != null){
		}
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap){
		
		if(evento.IsActionPressed("click_izquierdo") && !zoooom && !Cajon.zoooom){
			if(!VarillaM.encontrado && !VarillaS.encontrado){
				Main.varillaMinutosInstancia.ZIndex = -1;
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);


				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; 
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

			}
			else if(VarillaM.encontrado && !VarillaS.encontrado){
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; 
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
				Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
				Main.varillaMinutosInstancia.Position = new Vector2I(235, 80); 
				Main.varillaMinutosInstancia.ZIndex = 5;
				AddChild(Main.varillaMinutosInstancia);

			}
			else if(!VarillaM.encontrado && VarillaS.encontrado){
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; 
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				Main.varillaMinutosInstancia.ZIndex = -1;
				PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
				Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
				Main.varillaSegundosInstancia.Position = new Vector2I(235, 80);
				Main.varillaSegundosInstancia.ZIndex = 5;
				AddChild(Main.varillaSegundosInstancia);

			}
			else if(VarillaM.encontrado && VarillaS.encontrado && !Cajon.encontrado && !terminado){
				zoooom = true;
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; 
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
				Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
				Main.varillaMinutosInstancia.Position = new Vector2I(235, 80); 
				Main.varillaMinutosInstancia.ZIndex = 5;
				AddChild(Main.varillaMinutosInstancia);

				PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
				Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
				Main.varillaSegundosInstancia.Position = new Vector2I(235, 80);
				Main.varillaSegundosInstancia.ZIndex = 5;
				AddChild(Main.varillaSegundosInstancia);

			}
			else if(VarillaM.encontrado && VarillaS.encontrado && Cajon.encontrado && !terminado){
				zoooom = true;
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; 
				Main.relojZoomeadoInstancia.ZIndex = 4;
				AddChild(Main.relojZoomeadoInstancia);

				PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
				Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
				Main.varillaMinutosInstancia.Position = new Vector2I(235, 80); 
				Main.varillaMinutosInstancia.ZIndex = 5;
				AddChild(Main.varillaMinutosInstancia);

				PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
				Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
				Main.varillaSegundosInstancia.Position = new Vector2I(235, 80);
				Main.varillaSegundosInstancia.ZIndex = 5;
				AddChild(Main.varillaSegundosInstancia);

			}
			

			/*if(terminado){
				zoooom = true;
				PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
				Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D; 
				Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
				Main.fondoNegroInstancia.ZIndex = 0;
				AddChild(Main.fondoNegroInstancia);

				PackedScene relojZooemado = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/relojZoomeado.tscn");
				Main.relojZoomeadoInstancia = relojZooemado.Instantiate() as Node2D; 
				Main.relojZoomeadoInstancia.ZIndex = 4;
				Main.varillaMinutosInstancia.Rotate(3.45F);
				AddChild(Main.relojZoomeadoInstancia);

				PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
				Main.varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D;
				Main.varillaMinutosInstancia.Position = new Vector2I(235, 80); 
				Main.varillaMinutosInstancia.ZIndex = 5;
				AddChild(Main.varillaMinutosInstancia);

				PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
				Main.varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D;
				Main.varillaSegundosInstancia.Position = new Vector2I(235, 80);
				Main.varillaSegundosInstancia.ZIndex = 5;
				Main.varillaSegundosInstancia.Rotate(20.35F);
				AddChild(Main.varillaSegundosInstancia);
			}*/
			
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
