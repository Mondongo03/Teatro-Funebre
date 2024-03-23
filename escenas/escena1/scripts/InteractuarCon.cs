using Godot;
using System;

public partial class InteractuarCon : Area2D
{
	Despertarse despertarse = new Despertarse();

	private bool bolaInside = false;
	private bool godotInside = false;

	public static Boolean clickado = false;
	public static int slotsOcupados = 0;
	public override void _Ready(){
		
	}

	public override void _Process(double delta){
		if (Reloj.terminado)
		{   
			despertarse.despertar(true);
		}
	}


	public void _on_hueco_area_entered(Area2D area)
    {
        if (area.IsInGroup("personaje")) {

            GD.Print("Saul ha entrado al área. Cambiando de escena...");
            GetTree().ChangeSceneToFile("res://escenas/escena2/Prueba.tscn");
        }
    }
	public void _on_hueco_area_exited(Area2D area)
    {
        // Manejar la señal area_exited aquí
    }

	public int devolverSlotsOcupados(){
		return slotsOcupados;
	}
	
}
