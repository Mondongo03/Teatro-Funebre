using Godot;
using System;
using System.Collections.Generic;


public partial class Ritual : Area2D {
	List<string> grupos = new List<string>();

	public int slotCorrecto;
	public override void _Process(double delta)
	{
		if(slotCorrecto == 5)
		{
			MainDesvan.setRitualAcabado(true);
		}
	}

	public void _on_area_entered(Area2D area) {
        if(this.IsInGroup("Arriba") && area.IsInGroup("UnicornioRojo")){
			slotCorrecto++;
		}
		 if(this.IsInGroup("Derecha") && area.IsInGroup("UnicornioVerde")){
			slotCorrecto++;
		}
		 if(this.IsInGroup("Izquierda") && area.IsInGroup("UnicornioAmarillo")){
			slotCorrecto++;
		}
		
		 if(this.IsInGroup("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja")){
			slotCorrecto++;
		}
		if(this.IsInGroup("AbajoDerecha") && area.IsInGroup("UnicornioBlanco")){
			slotCorrecto++;
		}
		
    }

	public void _on_area_exited(Area2D area) {
        if(this.IsInGroup("Arriba") && area.IsInGroup("UnicornioRojo")){
			slotCorrecto--;
		}
		 if(this.IsInGroup("Derecha") && area.IsInGroup("UnicornioVerde")){
			slotCorrecto--;
		}
		 if(this.IsInGroup("Izquierda") && area.IsInGroup("UnicornioAmarillo")){
			slotCorrecto--;
		}
		
		 if(this.IsInGroup("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja")){
			slotCorrecto--;
		}
		if(this.IsInGroup("AbajoDerecha") && area.IsInGroup("UnicornioBlanco")){
			slotCorrecto--;
		}
		
    }
}
