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
			 public static Node2D huecoInstancia;
			 public static Node2D lamparaApagadaInstancia;
			 public static Node2D lamparaEncendidaInstancia;
			 Node2D relojInstancia;
			
			 Boolean clickadoBola = false;
			 Boolean clickadoVarillaM = false;
			public static Boolean varillaMinutosReloj = false;
			public static Boolean varillaSegundosReloj = false;
	public override void _Ready() {
		GD.Print("aaaaaaaaaaaaa");
		InstanciarEscena();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		 if (varillaMinutosInstancia != null) {
		clickadoVarillaM = varillaMClass.devolverClickado();
		 }
	}
	public void InstanciarEscena() {
			GD.Print("LLEGA AL METODO");
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

			PackedScene lamparaApagada = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaApagada.tscn");
			lamparaApagadaInstancia = lamparaApagada.Instantiate() as Node2D; // Cast the instance to Node
			AddChild(lamparaApagadaInstancia);
	}

}



