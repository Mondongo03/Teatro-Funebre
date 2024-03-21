using Godot;
using System;
using System.Numerics;

public partial class Main : Node2D {
			VarillaM varillaMClass = new VarillaM();
			InteractuarCon interactuarCon = new InteractuarCon();
			Bola bolaClass = new Bola();
			Reloj reloj = new Reloj();

			 Node2D bolaInstancia;
			 Node2D godotInstancia2;
			 public static Node2D varillaMinutosInstancia;
			 public static Node2D varillaSegundosInstancia;
			 public static Node2D relojZoomeadoInstancia;
			 Node2D relojInstancia;
			[Export] 
			int slotsOcupados;
			 Boolean clickadoBola = false;
			 Boolean clickadoVarillaM = false;
			public static Boolean varillaMinutosReloj = false;
			public static Boolean varillaSegundosReloj = false;
	public override void _Ready() {
		
			
		InstanciarEscena();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		
		 if (varillaMinutosInstancia != null) {
		clickadoVarillaM = varillaMClass.devolverClickado();
		 }
		clickadoBola = bolaClass.devolverClickado();
		slotsOcupados = interactuarCon.devolverSlotsOcupados();
		GD.Print(varillaMinutosReloj);

		_on_area_2d_area_entered((CollisionObject2D)bolaInstancia);
		_on_area_2d_area_exited((CollisionObject2D)bolaInstancia);

	if(varillaMinutosInstancia != null){
		_on_area_2d_area_entered((CollisionObject2D)varillaMinutosInstancia);
		_on_area_2d_area_exited((CollisionObject2D)varillaMinutosInstancia);
}
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

			PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
			varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(varillaSegundosInstancia);
    }


	void _on_area_2d_area_entered(CollisionObject2D collisionObject2D){
		
		if(clickadoBola && collisionObject2D == bolaInstancia){
			bolaInstancia.Position = new Vector2I(280, 100);
		}
		else if(clickadoVarillaM && collisionObject2D == varillaMinutosInstancia){
			if(varillaMinutosInstancia != null) varillaMinutosInstancia.Position = new Vector2I(140, 100);
		}

}
void _on_area_2d_area_exited(CollisionObject2D collisionObject2D){
}

}


