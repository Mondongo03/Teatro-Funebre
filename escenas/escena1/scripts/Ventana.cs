using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

public partial class Ventana Area2D{

    public static Boolean Ventanazoom = false;



    private AnimationPlayer animPlayer;

    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void _on_input_event(Node viewport, InputEvent evento, int shap){
    if(evento.IsActionPressed("click_izquierdo")&& !Cajon.zoooom && !Reloj.zoooom && !Ventanazoom){
        Ventanazoom = true;
    
        PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
        Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
        Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
        Main.fondoNegroInstancia.ZIndex = 1;
        AddChild(Main.fondoNegroInstancia);

        PackedScene ventanaZoomeada = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects(venatnaZoomeada.tscn");
        Main.venatnaZoomeadaInstancia = ventanaZoomeada.Instantiate() as Node2D;
        Main.ventanaZoomeada.ZIndex = 10;
        AddChild(Main.venatnaZoomeadaInstancia);
    }

    }
}