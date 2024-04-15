using Godot;
using System;

public partial class Cajetilla : Area2D {
    
public static Boolean abierto = false;
    public override void _Ready() {
       
    }

    public void _on_input_event(Node viewport, InputEvent evento, int shap){
	if(evento.IsActionPressed("click_izquierdo") && abierto== false){
        GD.Print("Abierto");
	 Main.tapaInstancia.Position = new Vector2((int)Main.tapaInstancia.Position.X, 280);
     abierto = true;
	}
    else if(evento.IsActionPressed("click_izquierdo") && abierto == true){
        GD.Print("Cerrado");
        Main.tapaInstancia.Position = new Vector2((int)Main.tapaInstancia.Position.X, 292);
        abierto = false;
    }
}
	}
