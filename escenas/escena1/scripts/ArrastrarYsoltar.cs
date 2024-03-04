using Godot;

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
	public void _on_mouse_exited(){
		Modulate = colorOriginal;
	}
}
