using Godot;
using Microsoft.VisualBasic;
using System;
using System.Dynamic;

public partial class Escalera : Area2D {

    bool puedoMover = false;
    bool estaMoviendo = false;
    float yPrime;

    int noFlechasInfinitas = 0;
    Vector2 posicionInicialClick;
    Vector2 posicionInicial;
    public static Node2D flechaInstancia;
    [Export] public AnimationPlayer animationPlayer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        animationPlayer.Play("cosa");
        posicionInicial = Position;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta){
        if (puedoMover && estaMoviendo) {
            Vector2 offset = GetGlobalMousePosition() - posicionInicialClick;
             yPrime = Mathf.Clamp(posicionInicial.Y + offset.Y, -75, 325);
            Position = new Vector2(Position.X, yPrime);
        }
        
        if(Position.Y == -75 && noFlechasInfinitas == 0){
            PackedScene flecha = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/flecha.tscn");
			flechaInstancia = flecha.Instantiate() as Node2D;
            flechaInstancia.ZIndex = 777;
            flechaInstancia.Position = new Vector2I(-120,142);
			AddChild(flechaInstancia);
            noFlechasInfinitas ++;
        }
        if(Position.Y != -75){
            if(noFlechasInfinitas == 1) flechaInstancia.QueueFree();
            noFlechasInfinitas = 0;
        }
    }

    public void _on_input_event(Node viewport, InputEvent evento, int shap) {
        if (evento.IsActionPressed("click_izquierdo")) {
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
