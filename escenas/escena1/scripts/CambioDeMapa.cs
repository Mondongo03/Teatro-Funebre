using Godot;
using System;

public partial class CambioDeMapa : Area2D
{
    public override void _Ready(){

    }

    public override void _Process(double delta){

	}
    public void _on_hueco_area_entered(CollisionObject2D collisionObject2D)
    {
        if (collisionObject2D.IsInGroup("bola"))
        {
            GetTree().ChangeSceneToFile("res://escenas/escena2/Prueba.tscn");
        }
    }
}
