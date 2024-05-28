using Godot;
using System;

public partial class Caldero : Area2D {
	// Called when the node enters the scene tree for the first time.
	AnimatedSprite2D rojo;
	AnimatedSprite2D verde;
	AnimatedSprite2D azul;
	static int contador = 1;
	public override void _Ready() {
		rojo  = GetChild<AnimatedSprite2D>(0);
		verde  = GetChild<AnimatedSprite2D>(1);
		azul  = GetChild<AnimatedSprite2D>(2);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if(contador == 1) {
			rojo.Visible = true;
			verde.Visible = false;
			azul.Visible = false;
		}
		if(contador == 2) {
			rojo.Visible = false;
			verde.Visible = true;
			azul.Visible = false;
		}
		if(contador == 3) {
			rojo.Visible = false;
			verde.Visible = false;
			azul.Visible = true;
		}
	}

	public void _on_input_event(Node viewport, InputEvent evento, int shap) {
		if (evento.IsActionPressed("click_izquierdo")) {
			contador++;
		}
	}
}
