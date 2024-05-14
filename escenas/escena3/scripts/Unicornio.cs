using Godot;
using Microsoft.VisualBasic;
using System;

/// <summary>
/// 
/// </summary>
public partial class Unicornio : Area2D
{
    static Unicornio objetoEnMovimiento = null;
    bool puedoMover = false;

    /// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
    public override void _Process(double delta)
    {
        if (puedoMover && objetoEnMovimiento == this)
        {
            Position = GetGlobalMousePosition();
        }
    }

	/// <summary>
    /// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
    /// </summary>
    /// <param name="viewport">Nodo del objeto parte de la API</param>
    /// <param name="evento">Nos permite detectar cuando se hace click</param>
    /// <param name="shap">Variable que se utiliza para la API</param>
    public void _on_input_event(Node viewport, InputEvent evento, int shap)
    {
        if (evento.IsActionPressed("click_izquierdo") && Ritual.slotCorrecto != 5)
        {
            puedoMover = true;
            objetoEnMovimiento = this;
        }
        if (evento.IsActionReleased("click_izquierdo"))
        {
            puedoMover = false;
            objetoEnMovimiento = null;
        }
    }
}