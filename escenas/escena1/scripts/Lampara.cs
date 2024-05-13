using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

public partial class Lampara : Area2D {

	public static bool encendido = false;
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

public void _on_input_event(Node viewport, InputEvent evento, int shap){
	if(evento.IsActionPressed("click_izquierdo")){
		if(encendido){
			apagarLampara();
			
		}
		else {
			encenderLampara();
		}
    	
	}
}

public void apagarLampara(){
		QueueFree();
		PackedScene lamparaApagada = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaApagada.tscn");
		Main.lamparaApagadaInstancia = lamparaApagada.Instantiate() as Node2D; // Cast the instance to Node
		//Main.lamparaApagadaInstancia.ZIndex = 2;
		Main.lamparaApagadaInstancia.Position = new Vector2I(0,0);
		GD.Print("antes de apagarla");
		AddChild(Main.lamparaApagadaInstancia);
		
		encendido = false;
		
		
}


public void encenderLampara(){
			QueueFree();
			PackedScene lamparaEncendida = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaEncendida.tscn");
			Main.lamparaEncendidaInstancia = lamparaEncendida.Instantiate() as Node2D; // Cast the instance to Node
			//Main.lamparaEncendidaInstancia.ZIndex = 10;
			Main.lamparaEncendidaInstancia.Position = new Vector2I(0,0);
			GD.Print("antes de encenderla");
			AddChild(Main.lamparaEncendidaInstancia);
			
			encendido = true;
			
			
}
}
