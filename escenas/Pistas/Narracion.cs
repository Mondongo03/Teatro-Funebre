using Godot;
using System;

public partial class Narracion : Area2D
{
	public static Node2D pistasInstancia;
	public static bool pistasAbiertas;

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void _on_input_event(Node viewport, InputEvent @event, long shape_idx){
        if (@event.IsActionPressed("click_izquierdo") && !this.IsInGroup("Pista")) {
			pistasAbiertas = false;
            this.QueueFree();
        }
		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Escena1") && !pistasAbiertas) {
			instanciarYAgregarNodo("res://escenas/Pistas/PistasEscena1.tscn", ref pistasInstancia);
			pistasAbiertas = true;
			pistasInstancia.Position = new Vector2I(-1064, -72);
        }

	if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Escena2") && !pistasAbiertas) {
			instanciarYAgregarNodo("res://escenas/Pistas/PistasEscena2.tscn", ref pistasInstancia);
			pistasAbiertas = true;
			pistasInstancia.Position = new Vector2I(-1017, -26);
        }
	if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Escena3") && !pistasAbiertas) {
		instanciarYAgregarNodo("res://escenas/Pistas/PistasEscena3.tscn", ref pistasInstancia);
		pistasAbiertas = true;
		pistasInstancia.Position = new Vector2I(-1017, -26);
    }
        
    }

	private void instanciarYAgregarNodo(String rutaEscena, ref Node2D node2D) {  
        PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
        node2D = escena.Instantiate() as Node2D;
        AddChild(node2D);
    }
}
