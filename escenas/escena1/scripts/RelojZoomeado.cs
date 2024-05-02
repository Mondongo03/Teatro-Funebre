using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar al reloj en zooom
/// </summary>
public partial class RelojZoomeado : Area2D
{
	public static Boolean zoooom = false;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		zoooom = true;
	}

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
			Reloj.zoooom = false;
			zoooom = false;
			if (VarillaS.encontrado) Main.varillaSegundosInstancia.QueueFree();

			if (VarillaM.encontrado) Main.varillaMinutosInstancia.QueueFree();
			QueueFree();
			Main.fondoNegroInstancia.QueueFree();

		}
	}
}
