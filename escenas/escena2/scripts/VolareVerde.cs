using Godot;
using System;

/// <summary>
/// Clase del pajaro Verde que controla sus movimientos, velocidad y ratio de aparicion 
/// </summary>
public partial class VolareVerde : PathFollow2D
{
	float speed = 0.1f;
	[Export] public AnimatedSprite2D animatedSprite2D;
	bool volar;
	Random random = new Random();

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		volar = true;
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (random.Next(1, 100) == 1 && ProgressRatio == 0)
		{
			GD.Print("Va el Verde");
			volar = true;
		}
		if (volar)
		{
			animatedSprite2D.Play("Volar");
			ProgressRatio += (float)delta * speed;

			if (ProgressRatio == 1)
			{
				animatedSprite2D.Stop();
				volar = false;
				ProgressRatio = 0;
			}
		}
	}
}
