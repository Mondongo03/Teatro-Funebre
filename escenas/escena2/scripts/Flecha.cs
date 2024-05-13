using Godot;
using Microsoft.VisualBasic;
using System;

/// <summary>
/// Clase que nos permite gestionar la flecha que aparece y nos permite subir al desban en la primera escena
/// </summary>
public partial class Flecha : Area2D
{

    /// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="evento">Nos permite detectar cuando se hace click</param>
    /// <param name="shap">Variable que se utiliza para la API</param>
    public void _on_input_event(Node viewport, InputEvent evento, int shap)
    {
        if (evento.IsActionPressed("click_izquierdo"))
        {
            GetTree().ChangeSceneToFile("res://escenas/escena1/node_2d.tscn");
        }
    }
}
