using Godot;
using System;

public partial class InteractuarCon : Area2D
{
    Despertarse despertarse = new Despertarse();

    private bool bolaInside = false;
    private bool godotInside = false;


    public override void _Ready()
    {
    }

    public override void _Process(double delta)
	{
        if (bolaInside && godotInside)
        {   
            despertarse.despertar(true);
        }
	}

    public void _on_hueco_area_entered(CollisionObject2D collisionObject2D)
    {
        if (collisionObject2D.IsInGroup("bola"))
        {
            GD.Print("Bola ha entrado al área.");
            bolaInside = true;
        }
        else if (collisionObject2D.IsInGroup("godot"))
        {
            GD.Print("Godot ha entrado al área.");
            godotInside = true;
        }
        else if (collisionObject2D.IsInGroup("personaje"))
        {
            GD.Print("Saul ha entrado al área. Cambiando de escena...");
            GetTree().ChangeSceneToFile("res://escenas/escena2/Prueba.tscn");
        }
    }

    public void _on_hueco_area_exited(CollisionObject2D collisionObject2D)
    {
        if (collisionObject2D.IsInGroup("bola"))
        {
            GD.Print("Bola ha salido del área.");
            bolaInside = false;
        }
        else if (collisionObject2D.IsInGroup("godot"))
        {
            GD.Print("Godot ha salido del área.");
            godotInside = false;
        }
    }
}