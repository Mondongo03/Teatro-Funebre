using Godot;
using System;
using System.Collections.Generic;


public partial class Ritual : Area2D {

	public static int slotCorrecto = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public void _on_tree_entered(Area2D area) {
		
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
