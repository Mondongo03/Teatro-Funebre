using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar cuando el Gnomo se movera y hacia que direccion
/// </summary>
public partial class Despertarse : PathFollow2D
{

	float speed = 0.2f;
	[Export]
	private AnimatedSprite2D animatedSprite2D;
	public static bool funciona, camina = false;
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;


	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (funciona == true)
		{
			animatedSprite2D.Play("CaminarDerecha");
			ProgressRatio += (float)delta * speed;

			if (!camina)
			{
				audioStreamPlayer2D.Play();
				camina = true;
			}
		}
	}

	/// <summary>
	/// Metodo que nos permite cambiar el booleano funciona
	/// </summary>
	/// <param name="boolean">Booleano de entrada que cambiara funciona</param>
	public void despertar(bool boolean)
	{
		funciona = boolean;
	}
}