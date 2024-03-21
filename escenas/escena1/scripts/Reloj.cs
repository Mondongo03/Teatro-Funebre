using Godot;
using System;

public partial class Reloj : Area2D {

    public override void _Ready(){
		
    }

    public override void _Process(double delta){

	}

	public void _on_reloj_entered(CollisionObject2D collisionObject2D){


		if (collisionObject2D.IsInGroup("VarillaM")){
		GD.Print("Varilla a entrau");
		collisionObject2D.QueueFree();
	
		}
	}

	public void _on_reloj_exited(CollisionObject2D collisionObject2D){
		if (collisionObject2D.IsInGroup("VarillaM")){
		GD.Print("Varilla a saliu");
		}
	}
	
}
