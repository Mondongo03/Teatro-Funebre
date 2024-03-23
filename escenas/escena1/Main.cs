using Godot;
using System;
using System.Numerics;

public partial class Main : Node2D {
			VarillaM varillaMClass = new VarillaM();
			InteractuarCon interactuarCon = new InteractuarCon();
			Reloj reloj = new Reloj();
			int slotsOcupados;
			 Node2D godotInstancia2;
			 public static Node2D varillaMinutosInstancia;
			 public static Node2D varillaSegundosInstancia;
			 public static Node2D relojZoomeadoInstancia;
			 public static Node2D fondoNegroInstancia;
			 public static Node2D cajonZoomeadoInstancia;
			 Node2D relojInstancia;
			
			 Boolean clickadoBola = false;
			 Boolean clickadoVarillaM = false;
			public static Boolean varillaMinutosReloj = false;
			public static Boolean varillaSegundosReloj = false;
	public override void _Ready() {
		
			
		InstanciarEscena();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		GD.Print("Reloj: "+Reloj.terminado);
		 if (varillaMinutosInstancia != null) {
		clickadoVarillaM = varillaMClass.devolverClickado();
		 }

	if(varillaMinutosInstancia != null){
		_on_area_2d_area_entered((CollisionObject2D)varillaMinutosInstancia);
		_on_area_2d_area_exited((CollisionObject2D)varillaMinutosInstancia);
}
	}
	public void InstanciarEscena() {

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
}
void _on_area_2d_area_exited(CollisionObject2D collisionObject2D){
}

}


