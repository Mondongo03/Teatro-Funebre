using Godot;
using Microsoft.VisualBasic;
using System;

public partial class Escalera : Area2D {

    bool puedoMover = false;
    bool estaMoviendo = false;
    float yPrime;
    Vector2 posicionInicialClick;
    Vector2 posicionInicial;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        posicionInicial = Position;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta){
        GD.Print(Position.Y);
        if (puedoMover && !Main.varillaMinutosReloj && estaMoviendo) {
            Vector2 offset = GetGlobalMousePosition() - posicionInicialClick;
             yPrime = Mathf.Clamp(posicionInicial.Y + offset.Y, -75, 325);
            Position = new Vector2(Position.X, yPrime);
        }
    }

    public void _on_input_event(Node viewport, InputEvent evento, int shap) {
        if (evento.IsActionPressed("click_izquierdo") && !Main.varillaMinutosReloj) {
            puedoMover = true;
            posicionInicialClick = GetGlobalMousePosition();
            estaMoviendo = true;
        }
        if (evento.IsActionReleased("click_izquierdo")) {
            puedoMover = false;
            estaMoviendo = false;
            posicionInicial = Position;
        }
    }
}
