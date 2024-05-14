using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar todo lo que ocurre en la segunda escena
/// </summary>
public partial class escena2 : Node2D
{
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		audioStreamPlayer2D.Play();
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
	}
}
