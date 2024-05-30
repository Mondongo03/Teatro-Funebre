using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar las particulas que aparecen cuando haces el ritual de los unicornios
/// </summary>
public partial class Particula : Area2D
{

	public static bool rojo = false;
	public static bool amarillo = false;
	public static bool naranja = false;
	public static bool verde = false;
	public static bool blanco = false;

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		encenderLuces();
		apagarLuces();
	}

	/// <summary>
	/// Metodo que enciende las parcticulas cuando los unicornios estan en su sitio
	/// </summary>
	public void encenderLuces()
	{
		if (this.IsInGroup("Rojo") && rojo) this.Visible = true;
		if (this.IsInGroup("Amarillo") && amarillo) this.Visible = true;
		if (this.IsInGroup("Naranja") && naranja) this.Visible = true;
		if (this.IsInGroup("Verde") && verde) this.Visible = true;
		if (this.IsInGroup("Blanco") && blanco) this.Visible = true;
	}

	/// <summary>
	/// Metodo que apaga las parcticulas cuando los unicornios salen de su sitio
	/// </summary>
	public void apagarLuces()
	{
		if (this.IsInGroup("Rojo") && !rojo) this.Visible = false;
		if (this.IsInGroup("Amarillo") && !amarillo) this.Visible = false;
		if (this.IsInGroup("Naranja") && !naranja) this.Visible = false;
		if (this.IsInGroup("Verde") && !verde) this.Visible = false;
		if (this.IsInGroup("Blanco") && !blanco) this.Visible = false;
	}
}
