using Godot;
using System;
using System.Numerics;

public partial class Main : Node2D {
			VarillaM varillaMClass = new VarillaM();
			InteractuarCon interactuarCon = new InteractuarCon();
			Reloj reloj = new Reloj();
			int slotsOcupados;
			Area2D pista_1;
			 Node2D godotInstancia2;
			 public static Node2D varillaMinutosInstancia;
			 public static Node2D varillaSegundosInstancia;
			 public static Node2D relojZoomeadoInstancia;
			 public static Node2D fondoNegroInstancia;
			 public static Node2D cajonZoomeadoInstancia;
			 public static Node2D huecoInstancia;
			 public static Node2D escaleraInstancia;
			 public static Node2D tapaInstancia;
			 public static Node2D pista_1Instancia;
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
		 if (varillaMinutosInstancia != null) {
		clickadoVarillaM = varillaMClass.devolverClickado();
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

			PackedScene hueco = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/hueco.tscn");
			huecoInstancia = hueco.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(huecoInstancia);

			PackedScene escalera = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/escalera.tscn");
			escaleraInstancia = escalera.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(escaleraInstancia);

			PackedScene tapa = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/tapa.tscn");
	    	tapaInstancia = tapa.Instantiate() as Node2D; 
			AddChild(tapaInstancia);

			PackedScene pista_1 = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/pista_1.tscn");
	    	pista_1Instancia = pista_1.Instantiate() as Node2D; 
			AddChild(pista_1Instancia);
	}

	public void popPista_1(){
		pista_1Instancia.Position = new Vector2I(334,255);
	}

	public void _on_timer_timeout(){
		if(VarillaM.encontrado == false || VarillaS.encontrado == false){
			popPista_1();}
	}

}



