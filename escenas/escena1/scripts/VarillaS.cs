using Godot;
using Microsoft.VisualBasic;
using System;

/// <summary>
/// Clase que nos perimte gestionar la varilla mas pequeña para saber cuando esta en el reloj y hacer su movimiento
/// </summary>
public partial class VarillaS : Area2D
{

	bool puedoMover = false;
	public static bool encontrado = false;

	public static bool ring = false;

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		//GD.Print(this.GlobalPosition);
		if (Main.varillaSegundosReloj && Main.varillaMinutosReloj && !Reloj.terminado)
		{
			if (Cajon.encontrado)
			{
				if (Main.varillaMinutosInstancia.Rotation < 3.45F && Main.varillaSegundosInstancia.Rotation < 20.35F)
				{
					rotar();

				}
				if (Main.varillaMinutosInstancia.Rotation >= 3.45F && Main.varillaSegundosInstancia.Rotation >= 20.35F && Cajon.encontrado)
				{
					ring = true;

					Reloj.terminado = true;
					Main.varillaMinutosInstancia.QueueFree();
					Main.varillaSegundosInstancia.QueueFree();
					Main.fondoNegroInstancia.QueueFree();
					Main.relojZoomeadoInstancia.QueueFree();

				}
			}
		}
		if (!Cajon.encontrado)
		{
			if (Reloj.zoooom)
			{
				rotar();
			}
		}
		if (puedoMover)
		{
			this.GlobalPosition = GetGlobalMousePosition();
		}

		Main.varillaMinutosInstancia.Rotation = (Main.varillaSegundosInstancia.Rotation / 5) * 0.846f;
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
			puedoMover = true;

		}
		if (evento.IsActionReleased("click_izquierdo"))
		{
			puedoMover = false;
		}
	}

	/// <summary>
	/// Getter de encontrado
	/// </summary>
	/// <returns>Devuleve encontrado</returns>
	public Boolean devolverClickado()
	{
		return encontrado;
	}

	/// <summary>
	/// Metodo que nos permite girar las abujas del reloj cuando este esta en pantalla grande
	/// </summary>
	public void rotar()
	{
		if (!Reloj.terminado) LookAt(GetGlobalMousePosition());

	}

	/// <summary>
	/// Getter de encontrado pero estatico
	/// </summary>
	/// <returns>Devuleve encontrado</returns>
	public static Boolean GetClickado()
	{
		return encontrado;
	}
}
