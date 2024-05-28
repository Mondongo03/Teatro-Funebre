using Godot;
using System;

public partial class Particula : Area2D {

	public static bool rojo = false;
	public static bool amarillo = false;
	public static bool naranja = false;
	public static bool verde = false;
	public static bool blanco = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		encenderLuces();
		apagarLuces();
	}

	public void encenderLuces(){
		if(this.IsInGroup("Rojo") && rojo) this.Visible = true;
		if(this.IsInGroup("Amarillo") && amarillo) this.Visible = true;
		if(this.IsInGroup("Naranja") && naranja) this.Visible = true;
		if(this.IsInGroup("Verde") && verde) this.Visible = true;
		if(this.IsInGroup("Blanco") && blanco) this.Visible = true;
	}
	public void apagarLuces(){
		if(this.IsInGroup("Rojo") && !rojo) this.Visible = false;
		if(this.IsInGroup("Amarillo") && !amarillo) this.Visible = false;
		if(this.IsInGroup("Naranja") && !naranja) this.Visible = false;
		if(this.IsInGroup("Verde") && !verde) this.Visible = false;
		if(this.IsInGroup("Blanco") && !blanco) this.Visible = false;
	}
}
