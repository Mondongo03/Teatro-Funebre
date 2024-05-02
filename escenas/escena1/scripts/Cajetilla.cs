using Godot;
using System;

/// <summary>
/// Clase que gestiona el Objeto cajetilla de la escena 1
/// </summary>
public partial class Cajetilla : Area2D
{

    public static Boolean abierto = false;

    /// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="evento">Nos permite detectar cuando se hace click</param>
    /// <param name="shap">Variable que se utiliza para la API</param>
    public void _on_input_event(Node viewport, InputEvent evento, int shap)
    {
        if (evento.IsActionPressed("click_izquierdo") && abierto == false)
        {
            GD.Print("Abierto");
            Main.tapaInstancia.Position = new Vector2((int)Main.tapaInstancia.Position.X, 276);
            abierto = true;
        }
        else if (evento.IsActionPressed("click_izquierdo") && abierto == true)
        {
            GD.Print("Cerrado");
            Main.tapaInstancia.Position = new Vector2((int)Main.tapaInstancia.Position.X, 288);
            abierto = false;
        }
    }
}