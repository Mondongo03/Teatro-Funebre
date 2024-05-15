using Godot;
using System;

public partial class RespuestasRamon : Area2D
{
	Sprite2D sprite1;
    Sprite2D sprite2;
	public static bool jugar = false;
	public static bool pasar = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		sprite1 = GetChild<Sprite2D>(0);
        sprite2 = GetChild<Sprite2D>(1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	void _on_mouse_entered(){
		sprite2.Visible = false;
	}
	void _on_mouse_exited(){
		sprite2.Visible = true;
	}

	void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {
		if(@event.IsActionPressed("click_izquierdo")&& this.IsInGroup("Si")){
			jugar = true;
			GetTree().ChangeSceneToFile("res://escenas/escena2.5/CartasCartitas.tscn");
			GD.Print("Jugar");
		}
		else if(@event.IsActionPressed("click_izquierdo")&& this.IsInGroup("No")){
			pasar = true;
			GD.Print("Pasar");
		}
	}
}
