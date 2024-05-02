using Godot;
using Microsoft.VisualBasic;
using System;
using System.Dynamic;

/// <summary>
/// Clase que nos permite gestionar el objeto escalera
/// </summary>
public partial class Escalera : Area2D {

    bool puedoMover = false;
    bool estaMoviendo = false;
    float yPrime;

    int noFlechasInfinitas = 0;
    Vector2 posicionInicialClick;
    Vector2 posicionInicial;
    public static Node2D flechaInstancia;
    [Export] public AnimationPlayer animationPlayer;

    /// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
    public override void _Ready(){
        animationPlayer.Play("cosa");
        posicionInicial = Position;
    }

    /// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
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

    /// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="evento">Nos permite detectar cuando se hace click</param>
    /// <param name="shap">Variable que se utiliza para la API</param>
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
