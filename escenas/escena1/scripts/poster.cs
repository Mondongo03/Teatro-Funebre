using Godot;
using System;

/// <summary>
/// Clase que gestiona las fisicas del poster para que haga su interaccion
/// </summary>
public partial class Poster : Area2D
{
	[Export]
	public AnimationPlayer animationPlayer;

	public static Boolean animacionTerminada = false;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="evento">Nos permite detectar cuando se hace click</param>
	/// <param name="shap">Variable que se utiliza para la API</param>
	public void _on_input_event(Node viewport, InputEvent evento, int shap)
	{
		if (evento.IsActionPressed("click_izquierdo") && animacionTerminada == false)
		{
			animationPlayer.Play("rotacionPoster");
			animacionTerminada = true;
		}
	}
}
