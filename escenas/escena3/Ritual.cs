using Godot;
using System;
using System.Collections.Generic;


public partial class Ritual : Area2D {
	List<string> grupos = new List<string>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		

        // Obtener los grupos como una lista de strings
        foreach (StringName nombreGrupo in GetGroups())
        {
            grupos.Add(nombreGrupo.ToString());
			GD.Print(nombreGrupo);
        }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
			
		
	}

	public void _on_tree_entered(Area2D area){
		
	}

	public void _on_area_entered(Area2D area) {
        if(grupos[0].Equals("Arriba") && area.IsInGroup("UnicornioRojo")){
			GD.Print("Arriba: Okkkk");
		}
		 if(grupos[0].Equals("Izquierda") && area.IsInGroup("UnicornioVerde")){
			GD.Print("Derecha: Okkkk");
		}
		 if(grupos[0].Equals("Izquierda") && area.IsInGroup("UnicornioAmarillo")){
			GD.Print("Izquierda: Okkkk");
		}
		
		 if(grupos[0].Equals("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja")){
			GD.Print("AbajoIzquierda: Okkkk");
		}
		if(grupos[0].Equals("AbajoDerecha") && area.IsInGroup("UnicornioBlanco")){
			GD.Print("AbajoDerecha: Okkkk");
		}
		GD.Print(area.GetGroups());
    }
}
