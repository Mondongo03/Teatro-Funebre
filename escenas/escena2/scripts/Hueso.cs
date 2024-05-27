using Godot;
using System;

public partial class Hueso : Area2D {

	Sprite2D sprite;
	bool puedoMover = false;

	bool postAnimacion = false;
	public static bool guardado = false;
	static int clicks = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		sprite = GetChild<Sprite2D>(0);

		if(clicks >= 10 && this.IsInGroup("Hueso")){
			sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/Hueso2.png");
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (puedoMover) this.GlobalPosition = GetGlobalMousePosition();
		
		if(Cofre.abierto && guardado){
			sprite.Visible = true;
		}
		if(this.IsInGroup("HuesoGnomo")&& !MueveTeEnElBosque.comenzar && !postAnimacion){
			sprite.Visible = true;
			postAnimacion = true;
		}
		if(clicks == 10 && this.IsInGroup("Hueso")){
			sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2/assets/Hueso2.png");
		}
	}

	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		clicks++;
		if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Hueso"))
		{
			puedoMover = true;
			sprite.Visible = true;
		}
		if (@event.IsActionReleased("click_izquierdo") && this.IsInGroup("Hueso"))
		{
			puedoMover = false;
		}
	}

	private void _on_area_entered(CollisionObject2D collisionObject2D) {
		if (collisionObject2D.IsInGroup("HuesoGnomo") && !MueveTeEnElBosque.comenzar && this.IsInGroup("Hueso"))
		{
			sprite.Visible = false;
		}
		else if(collisionObject2D.IsInGroup("Hueso") && !MueveTeEnElBosque.comenzar && this.IsInGroup("HuesoGnomo")) {
			sprite.Visible = true;
		}
	}

		private void _on_area_exited(CollisionObject2D collisionObject2D)
	{
		if (collisionObject2D.IsInGroup("GnomoSinCosas") && !MueveTeEnElBosque.comenzar && this.IsInGroup("Hueso"))
		{
			sprite.Visible = true;
		}
		else if(collisionObject2D.IsInGroup("Hueso") && !MueveTeEnElBosque.comenzar && this.IsInGroup("HuesoGnomo")) {
			sprite.Visible = false;
		}
	}
}
