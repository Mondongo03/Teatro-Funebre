using Godot;
using System;

public partial class InteractuarCon : Area2D {

	public static Boolean clickado = false;

	public static int slotsOcupados = 0;
    public override void _Ready(){
		
    }

    public override void _Process(double delta){

	}

	public void _on_hueco_area_entered(CollisionObject2D collisionObject2D){


		if (collisionObject2D.IsInGroup("bola")){
			slotsOcupados++;
			GD.Print(slotsOcupados);
		GD.Print("Bola a entrau");
		
	
		}
		else if (collisionObject2D.IsInGroup("godot")){
			slotsOcupados++;
			GD.Print(slotsOcupados);
		GD.Print("Godot a entrau");
		}
	}

	public void _on_hueco_area_exited(CollisionObject2D collisionObject2D){
		if (collisionObject2D.IsInGroup("bola")){
			clickado = false;
			slotsOcupados--;
			GD.Print(slotsOcupados);
		GD.Print("Bola a saliu");
		}
		else if (collisionObject2D.IsInGroup("godot")){
		GD.Print("Godot a saliu");
		}
	}

	public int devolverSlotsOcupados(){
		return slotsOcupados;
	}
	
}
