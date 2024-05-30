using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Clase que nos permite gestionar el puzzle del ritual
/// </summary>
public partial class Ritual : Area2D
{
	public static int slotCorrecto;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Process(double delta)
	{
		if (slotCorrecto == 5)
		{
			MainDesvan.ritualAcabado = true;
		}
	}

	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo entra en el area, este metodo es una señal de godot
	/// </summary>
	/// <param name="area">Es la variable que nos dice el donde a entrado un objeto</param>
	public void _on_area_entered(Area2D area)
	{
		if (this.IsInGroup("Arriba") && area.IsInGroup("UnicornioRojo"))
		{
			slotCorrecto++;
			Particula.rojo = true;
		}
		if (this.IsInGroup("Derecha") && area.IsInGroup("UnicornioVerde"))
		{
			slotCorrecto++;
			Particula.verde = true;
		}
		if (this.IsInGroup("Izquierda") && area.IsInGroup("UnicornioAmarillo"))
		{
			slotCorrecto++;
			Particula.amarillo = true;
		}

		if (this.IsInGroup("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja"))
		{
			slotCorrecto++;
			Particula.naranja = true;
		}
		if (this.IsInGroup("AbajoDerecha") && area.IsInGroup("UnicornioBlanco"))
		{
			slotCorrecto++;
			Particula.blanco = true;
		}

	}
	
	/// <summary>
	/// Señal de godot que nos permite comprobar si el area de un objeto deja de colisionar contra otro objeto
	/// </summary>
	/// <param name="area">Variable de la colision del objeto que colisiona con el objeto</param>
	public void _on_area_exited(Area2D area)
	{
		if (this.IsInGroup("Arriba") && area.IsInGroup("UnicornioRojo"))
		{
			slotCorrecto--;
			Particula.rojo = false;
		}
		if (this.IsInGroup("Derecha") && area.IsInGroup("UnicornioVerde"))
		{
			slotCorrecto--;
			Particula.verde = false;
		}
		if (this.IsInGroup("Izquierda") && area.IsInGroup("UnicornioAmarillo"))
		{
			slotCorrecto--;
			Particula.amarillo = false;
		}

		if (this.IsInGroup("AbajoIzquierda") && area.IsInGroup("UnicornioNaranja"))
		{
			slotCorrecto--;
			Particula.naranja = false;
		}
		if (this.IsInGroup("AbajoDerecha") && area.IsInGroup("UnicornioBlanco"))
		{
			slotCorrecto--;
			Particula.blanco = false;
		}
	}
}
