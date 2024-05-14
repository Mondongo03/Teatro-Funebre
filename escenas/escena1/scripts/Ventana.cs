using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata;

/// <summary>
/// Clase que nos permite gestinar como funciona la logica de la ventana en la escena 1
/// </summary>
public partial class Ventana : Area2D
{

    public static Boolean Ventanazoom = false;

    private AnimationPlayer animPlayer;

    public static Node2D ventanaZoomeadaInstancia;

    
    /// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="evento">Nos permite detectar cuando se hace click</param>
	/// <param name="shap">Variable que se utiliza para la API</param>
    public void _on_input_event(Node viewport, InputEvent evento, int shap)
    {
        if (evento.IsActionPressed("click_izquierdo") && !Cajon.zoooom && !Reloj.zoooom && !Ventanazoom)
        {
            Ventanazoom = true;

            PackedScene fondoNegro = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/fondoNegro.tscn");
            Main.fondoNegroInstancia = fondoNegro.Instantiate() as Node2D;
            Main.fondoNegroInstancia.Position = new Vector2I(-400, -400);
            Main.fondoNegroInstancia.ZIndex = 1;
            AddChild(Main.fondoNegroInstancia);

            PackedScene ventanaZoomeada = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/ventanaZoomeada.tscn");
            ventanaZoomeadaInstancia = ventanaZoomeada.Instantiate() as Node2D;
            ventanaZoomeadaInstancia.ZIndex = 10;
            AddChild(ventanaZoomeadaInstancia);
        }

    }
}