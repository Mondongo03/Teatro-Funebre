using Godot;
using System;
using System.Numerics;

public partial class main : Node2D {
			VarillaM varillaMClass = new VarillaM();
			InteractuarCon interactuarCon = new InteractuarCon();
			Bola bolaClass = new Bola();
			Reloj reloj = new Reloj();

			 Node2D bolaInstancia;
			 Node2D godotInstancia2;
			 Node2D varillaMinutosInstancia;
			 Node2D relojInstancia;
			 int slotsOcupados;
			 Boolean clickadoBola = false;
			 Boolean clickadoVarillaM = false;
	public override void _Ready() {
		
			
		InstanciarEscena();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		
		clickadoVarillaM = varillaMClass.devolverClickado();
		clickadoBola = bolaClass.devolverClickado();
		slotsOcupados = interactuarCon.devolverSlotsOcupados();
		//GD.Print(slotsOcupados);

		_on_area_2d_area_entered((CollisionObject2D)bolaInstancia);
		_on_area_2d_area_exited((CollisionObject2D)bolaInstancia);

		_on_area_2d_area_entered((CollisionObject2D)varillaMinutosInstancia);
		_on_area_2d_area_exited((CollisionObject2D)varillaMinutosInstancia);
	}
	public void InstanciarEscena() {
			
			PackedScene bola = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/bola.tscn");
			bolaInstancia = bola.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(bolaInstancia);
			
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

			PackedScene reloj = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/reloj.tscn");
			relojInstancia = reloj.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(relojInstancia);

			PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
			varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(varillaMinutosInstancia);
    }


	void _on_area_2d_area_entered(CollisionObject2D collisionObject2D){
		
		if(clickadoBola && collisionObject2D == bolaInstancia){
			bolaInstancia.Position = new Vector2I(280, 100);
		}
		else if(clickadoVarillaM && collisionObject2D == varillaMinutosInstancia){
			varillaMinutosInstancia.Position = new Vector2I(140, 100);
		}

}
void _on_area_2d_area_exited(CollisionObject2D collisionObject2D){
}

}


