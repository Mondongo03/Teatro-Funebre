using Godot;
using Microsoft.VisualBasic;
using System;

/// <summary>
/// Clase que nos perimte gestionar la varilla mas grande para saber cuando esta en el reloj y hacer su movimiento
/// </summary>
public partial class VarillaM : Area2D
{
	bool puedoMover = false;
	public static Boolean encontrado = false;

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (puedoMover && !Main.varillaMinutosReloj)
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
		if (evento.IsActionPressed("click_izquierdo") && !Main.varillaMinutosReloj)
		{

			puedoMover = true;

		}
		if (evento.IsActionReleased("click_izquierdo"))
		{
			puedoMover = false;

		}
	}

	/// <summary>
	/// Getter de encontrar
	/// </summary>
	/// <returns>Devuelve la variable encontrar</returns>
	public static Boolean devolverClickado()
	{
		return encontrado;
	}
}
