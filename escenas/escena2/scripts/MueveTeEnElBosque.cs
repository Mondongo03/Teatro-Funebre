using Godot;
using System;

/// <summary>
/// Script que nos permite gestionar el movimiento de gnomo en el boque
/// </summary>
public partial class MueveTeEnElBosque : PathFollow2D
{
	float speed = 0.2f;
	[Export] public AnimatedSprite2D animatedSprite2D;
	public static bool comenzar;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		comenzar = true;
		
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if(comenzar){
			animatedSprite2D.Play("AccionBosque");
			ProgressRatio += (float)delta * speed;

			if(ProgressRatio == 0.7748){
				animatedSprite2D.Stop();
				animatedSprite2D.Play("SaltarBosque");
			}

			if (ProgressRatio == 1){
				animatedSprite2D.Stop();
				animatedSprite2D.Play("AlSueloBosque");
				comenzar = false;
			}
		}
	}

	public void _on_area_2d_area_entered(CollisionObject2D collisionObject2D)
	{
		if(collisionObject2D.IsInGroup("pocion"))
		{
			GD.Print("La pocion ha enttrado");
		}
	}
}
