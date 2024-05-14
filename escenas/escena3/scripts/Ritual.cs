using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Script que nos permite gestionar el ritual de la escena 3
/// </summary>
public partial class Ritual : Area2D {
	List<string> grupos = new List<string>();

	public static int slotCorrecto = 0;

	
	public override void _Ready() {
		

        // Obtener los grupos como una lista de strings
        foreach (StringName nombreGrupo in GetGroups())
        {
            grupos.Add(nombreGrupo.ToString());
			GD.Print(nombreGrupo);
        }
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
			GD.Print(slotCorrecto);
		
	}

	/// <summary>
	/// Señal de godot que nos permite comprobar si la area de un objeto colisiona contra la area del objeto
	/// </summary>
	/// <param name="area">Variable de la colision del objeto que colisiona con el objeto</param>
	public void _on_area_entered(Area2D area) {
        if(grupos[0].Equals("Arriba") && area.IsInGroup("UnicornioRojo")){
			slotCorrecto++;
		}
		 if(grupos[0].Equals("Derecha") && area.IsInGroup("UnicornioVerde")){
			slotCorrecto++;
		}
		 if(grupos[0].Equals("Izquierda") && area.IsInGroup("UnicornioAmarillo")){
			slotCorrecto++;
		}
		
		 if(grupos[0].Equals("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja")){
			slotCorrecto++;
		}
		if(grupos[0].Equals("AbajoDerecha") && area.IsInGroup("UnicornioBlanco")){
			slotCorrecto++;
		}
		
    }

	/// <summary>
	/// Este metodo es una señal de godot, detecta cuando salga del area objeto
	/// </summary>
	/// <param name="area">Variable de la area del objeto que colisiona con el objeto</param>
	public void _on_area_exited(Area2D area) {
        if(grupos[0].Equals("Arriba") && area.IsInGroup("UnicornioRojo")){
			slotCorrecto--;
		}
		 if(grupos[0].Equals("Derecha") && area.IsInGroup("UnicornioVerde")){
			slotCorrecto--;
		}
		 if(grupos[0].Equals("Izquierda") && area.IsInGroup("UnicornioAmarillo")){
			slotCorrecto--;
		}
		
		 if(grupos[0].Equals("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja")){
			slotCorrecto--;
		}
		if(grupos[0].Equals("AbajoDerecha") && area.IsInGroup("UnicornioBlanco")){
			slotCorrecto--;
		}
		
    }
}
