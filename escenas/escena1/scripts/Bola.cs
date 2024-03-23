using Godot;
using System;

<<<<<<< HEAD:escenas/escena1/scripts/Bola.cs
public partial class Bola : Area2D {

	bool puedoMover = false;
	public static Boolean encontrado = false;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
=======
public partial class ArrastrarYsoltar : Area2D {
	[Signal]
	public delegate void MouseShapeEnteredEventHandler();
	[Signal]
	public delegate void MouseShapeExitedEventHandler();
    Color colorOriginal;
    Color colorResaltado = new Color(1, 1, 0); // Color amarillo para resaltar

    bool puedoMover = false;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        // Guarda el color original del objeto
        colorOriginal = Modulate;
    }
>>>>>>> main:escenas/escena1/scripts/ArrastrarYsoltar.cs

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta){
        if(puedoMover){
            Position = GetGlobalMousePosition();
        }
    }

    public void _on_input_event(Node viewport, InputEvent evento, int shap){
        if(evento.IsActionPressed("click_izquierdo")){
            puedoMover = true;
        }
        if(evento.IsActionReleased("click_izquierdo")){
            puedoMover = false;
        }
    }
	public void _on_mouse_entered(){
		Modulate = colorResaltado;
	}
<<<<<<< HEAD:escenas/escena1/scripts/Bola.cs

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){

		if(puedoMover){
			Position = GetGlobalMousePosition();
		}
	}
	public void _on_input_event(Node viewport, InputEvent evento, int shap){
		if(evento.IsActionPressed("click_izquierdo")){
			puedoMover = true;
			encontrado = true;

		}
		if(evento.IsActionReleased("click_izquierdo")){
			puedoMover = false;
			encontrado = true;
		}
=======
	public void _on_mouse_exited(){
		Modulate = colorOriginal;
>>>>>>> main:escenas/escena1/scripts/ArrastrarYsoltar.cs
	}
	public Boolean devolverClickado(){
		return encontrado;
	}
	
}
