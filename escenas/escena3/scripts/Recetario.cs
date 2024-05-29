using Godot;
using System;

public partial class Recetario : Area2D
{
	// Called when the node enters the scene tree for the first time.
	static bool zoom = false;
	PackedScene escena;
	Node2D node2D;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(this.IsInGroup("RecetarioZoomeado")) GD.Print(GetGlobalMousePosition());
	}
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {

		if (@event.IsActionPressed("click_izquierdo") && !zoom && this.IsInGroup("Recetario")) {
			zoom = true;
		escena = (PackedScene)ResourceLoader.Load("res://escenas/escena3/objects/recetarioZoomeado.tscn");
        node2D = escena.Instantiate() as Node2D;
		node2D.Position = new Vector2I(-259, -350);
        AddChild(node2D);
		}
		else if (@event.IsActionPressed("click_izquierdo") && zoom && this.IsInGroup("RecetarioZoomeado")) {
			zoom = false;
			QueueFree();
        	AddChild(node2D);
		}
		
		
	}
}
