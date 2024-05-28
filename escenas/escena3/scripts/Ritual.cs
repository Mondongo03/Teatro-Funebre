using Godot;
using System;
using System.Collections.Generic;


public partial class Ritual : Area2D {

	public static int slotCorrecto;
	public override void _Process(double delta) {
		if(slotCorrecto == 5)
		{
			MainDesvan.ritualAcabado = true;
		}
		 if(this.IsInGroup("Izquierda")){
			GD.Print(this.Position);
		}
		
	}

	public void _on_area_entered(Area2D area) {
        if(this.IsInGroup("Arriba") && area.IsInGroup("UnicornioRojo")){
			slotCorrecto++;
			Particula.rojo = true;
		}
		 if(this.IsInGroup("Derecha") && area.IsInGroup("UnicornioVerde")){
			slotCorrecto++;
			Particula.verde = true;
		}
		 if(this.IsInGroup("Izquierda") && area.IsInGroup("UnicornioAmarillo")){
			slotCorrecto++;
			Particula.amarillo = true;
		}
		
		 if(this.IsInGroup("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja")){
			slotCorrecto++;
			Particula.naranja = true;
		}
		if(this.IsInGroup("AbajoDerecha") && area.IsInGroup("UnicornioBlanco")){
			slotCorrecto++;
			Particula.blanco = true;
		}
		
    }

	public void _on_area_exited(Area2D area) {
        if(this.IsInGroup("Arriba") && area.IsInGroup("UnicornioRojo")){
			slotCorrecto--;
			Particula.rojo = false;
		}
		 if(this.IsInGroup("Derecha") && area.IsInGroup("UnicornioVerde")){
			slotCorrecto--;
			Particula.verde = false;
		}
		 if(this.IsInGroup("Izquierda") && area.IsInGroup("UnicornioAmarillo")){
			slotCorrecto--;
			Particula.amarillo = false;
		}
		
		 if(this.IsInGroup("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja")){
			slotCorrecto--;
			Particula.naranja = false;
		}
		if(this.IsInGroup("AbajoDerecha") && area.IsInGroup("UnicornioBlanco")){
			slotCorrecto--;
			Particula.blanco = false;
		}
		
    }
}
