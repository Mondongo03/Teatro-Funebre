using Godot;
using System;

public partial class Ramon : Area2D {

	public static int stepTexto = 0;
	PackedScene texto1;
	static Node2D instanciaTextoActual;
	PackedScene texto2;
	PackedScene texto3;
	PackedScene texto4;
	PackedScene texto5;
	bool ojoEnseñado = false;
	public override void _Ready() {
	}
	
	public override void _Process(double delta) {
		if(RespuestasRamon.pasar && stepTexto!=4){
			if (instanciaTextoActual != null) {
		instanciaTextoActual.Visible = false;
			}
			stepTexto = 4;
			RespuestasRamon.pasar = false;
		}
		
	}

	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {
		
	if (@event.IsActionPressed("click_izquierdo")){
		
		if(stepTexto == 0){
			mostrarTexto(texto1,"res://escenas/escena2/objetos/textBox1Ramon.tscn");
			stepTexto++;
		}
		else if(stepTexto == 1){
			mostrarTexto(texto2,"res://escenas/escena2/objetos/textBox2Ramon.tscn");
		}
		else if(stepTexto == 2){
			mostrarTexto(texto3,"res://escenas/escena2/objetos/textBox3Ramon.tscn");
			stepTexto++;
		}
		else if(stepTexto == 3){
			mostrarTexto(texto4,"res://escenas/escena2/objetos/textBox4Ramon.tscn");
			if(GnomoSinCosas.sprite.Visible == false){
				stepTexto++;
			}
		}
		else if(stepTexto == 4){
			GD.Print("STEP 4");
			mostrarTexto(texto5,"res://escenas/escena2/objetos/textBox5Ramon.tscn");
			stepTexto++;
		}
		else if(stepTexto == 5){
			mostrarTexto(texto5,"res://escenas/escena2/objetos/textBox6Ramon.tscn");
		}
	}
}

private void mostrarTexto(PackedScene escena, String ruta){
	if (instanciaTextoActual != null) {
		instanciaTextoActual.Visible = false;
	}
	escena = (PackedScene)ResourceLoader.Load(ruta);
	instanciaTextoActual = escena.Instantiate() as Node2D;
	instanciaTextoActual.GlobalPosition = new Vector2I(0, -161);
	AddChild(instanciaTextoActual);
}

private void _on_area_entered(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("Ojo")&& !ojoEnseñado) {
				ojoEnseñado = true;
				stepTexto++;
			}
	}
	private void _on_area_exited(CollisionObject2D collisionObject2D) {
			if (collisionObject2D.IsInGroup("Ojo")&& !ojoEnseñado) {
				
			}
	}
}



