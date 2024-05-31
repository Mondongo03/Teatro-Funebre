using Godot;
using System;

/// <summary>
/// Esta clase es la clase que se utiliza para detectar cuando entra y sale un objeto de una area especifica
/// </summary>
public partial class InteractuarCon : Area2D
{
	/// <summary>
	/// Instanciacio de la clase Despertarse
	/// </summary>
	Despertarse despertarse = new Despertarse();

	public static Boolean clickado = false;

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (Reloj.terminado) despertarse.despertar(true);
	}
	/// <summary>
	/// Metodo que nos permite ejecutar codigo cuando algo entra en el area, este metodo es una señal de godot
	/// </summary>
	/// <param name="area">Es la variable que nos dice el donde a entrado un objeto</param>
	public void _on_hueco_area_entered(Area2D area) {
		if (area.IsInGroup("personaje"))
		{
			GD.Print("Saul ha entrado al área. Cambiando de escena...");
			GetTree().ChangeSceneToFile("res://escenas/escena2/Prueba.tscn");
		}
	}
}

