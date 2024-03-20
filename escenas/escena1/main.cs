using Godot;
using System;
using System.Numerics;

public partial class main : Node2D {
			InteractuarCon interactuarCon = new InteractuarCon();
			ArrastrarYsoltar arrastrarYsoltar = new ArrastrarYsoltar();
			 Node2D bolaInstancia;
			 Node2D godotInstancia2;
			 int slotsOcupados;
			 Boolean clickado = false;
	public override void _Ready() {
		
			
		InstanciarEscena();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		if (slotsOcupados ==0){}
		if (slotsOcupados ==1){}
		if (slotsOcupados ==2){}
		
		clickado = arrastrarYsoltar.devolverClickado();
		slotsOcupados = interactuarCon.devolverSlotsOcupados();
		//GD.Print(slotsOcupados);

		_on_area_2d_area_entered((CollisionObject2D)bolaInstancia);
		_on_area_2d_area_exited((CollisionObject2D)bolaInstancia);

		_on_area_2d_area_entered((CollisionObject2D)godotInstancia2);
		_on_area_2d_area_exited((CollisionObject2D)godotInstancia2);
	}
	public void InstanciarEscena() {
			PackedScene bola = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/bola.tscn");
			bolaInstancia = bola.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(bolaInstancia);
			
			PackedScene godot = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/godot.tscn");
			godotInstancia2 = godot.Instantiate() as Node2D; 
			godotInstancia2.Position = new Vector2I(600, 600);// Cast the instance to Node
			AddChild(godotInstancia2);

			var hueco = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/hueco.tscn");
			var huecoInstancia = hueco.Instantiate() as Node2D;// Cast the instance to Node
			huecoInstancia.Position = new Vector2I(140, 200);
			AddChild(huecoInstancia);

			var huecoInstancia2 = hueco.Instantiate() as Area2D;
			huecoInstancia2.Position = new Vector2I(280, 200);
    		AddChild(huecoInstancia2);

			var huecoInstancia3 = hueco.Instantiate() as Node2D; // Cast the instance to Node
			huecoInstancia3.Position = new Vector2I(420, 200);
			AddChild(huecoInstancia3);
    }


	void _on_area_2d_area_entered(CollisionObject2D collisionObject2D){
		if(slotsOcupados == 0 && clickado && collisionObject2D == bolaInstancia){
			bolaInstancia.Position = new Vector2I(140, 100);
		}
		else if(slotsOcupados == 1 && clickado && collisionObject2D == bolaInstancia){
			bolaInstancia.Position = new Vector2I(280, 100);
			
		}
		if(slotsOcupados == 0 && clickado && collisionObject2D == godotInstancia2){
			godotInstancia2.Position = new Vector2I(140, 100);
		}
		else if(slotsOcupados == 1 && clickado && collisionObject2D == godotInstancia2){
			godotInstancia2.Position = new Vector2I(140, 100);
			
		}

		


}
void _on_area_2d_area_exited(CollisionObject2D collisionObject2D){
}
}


