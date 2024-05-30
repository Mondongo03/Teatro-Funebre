using Godot;
using System;

public partial class Caldero : Area2D {
	// Called when the node enters the scene tree for the first time.
	AnimatedSprite2D rojo;
	AnimatedSprite2D verde;
	AnimatedSprite2D azul;
	AnimatedSprite2D rosa;
	Sprite2D vacio;
	public static int contador = 1;
	public override void _Ready() {
		rojo  = GetChild<AnimatedSprite2D>(0);
		verde  = GetChild<AnimatedSprite2D>(1);
		rosa  = GetChild<AnimatedSprite2D>(2);
		azul  = GetChild<AnimatedSprite2D>(3);
		vacio = GetChild<Sprite2D>(4);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if(contador == 1) {
			rojo.Visible = true;
			verde.Visible = false;
			rosa.Visible = false;
			azul.Visible = false;
			
		}
		if(contador == 2) {
			rojo.Visible = false;
			verde.Visible = true;
			rosa.Visible = false;
			azul.Visible = false;
			
		}
		if(contador == 3) {
			rojo.Visible = false;
			verde.Visible = false;
			rosa.Visible = true;
			azul.Visible = false;
			
		}
		if(contador == 4) {
			rojo.Visible = false;
			verde.Visible = false;
			rosa.Visible = false;
			azul.Visible = true;
			
		}
		if(MegaPoti.lleno) {
			azul.Visible = false;
			vacio.Visible = true;
		}
	}

	void _on_area_entered(CollisionObject2D collisionObject2D){
		if(collisionObject2D.IsInGroup("Vial") || collisionObject2D.IsInGroup("FlorBuena") || collisionObject2D.IsInGroup("Hueso") && Hueso.clicks >= 30){
			contador++;
			if(collisionObject2D.IsInGroup("FlorBuena")) Flor.metidoEnCaldero = true;
			if(collisionObject2D.IsInGroup("Hueso")) Hueso.metidoEnCaldero = true;
			collisionObject2D.QueueFree();
		}
	}
}
