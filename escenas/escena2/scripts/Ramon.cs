using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar al personaje segundario de Ramon
/// </summary>
public partial class Ramon : Area2D
{
	public static int stepTexto = 0;
	PackedScene texto1, texto2, texto3, texto4, texto5, texto6;
	Node2D instanciaTextoActual;
	bool ojoEnseñado = false;

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta) {

		if (RespuestasRamon.pasar && stepTexto != 4)
		{
			if (instanciaTextoActual != null)
			{
				instanciaTextoActual.Visible = false;
			}
			RespuestasRamon.pasar = false;
		}

	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="event">Nos permite detectar cuando se hace click</param>
	/// <param name="shape_idx">Variable que se utiliza para la API</param>
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {
		GD.Print(stepTexto);
		if (@event.IsActionPressed("click_izquierdo")) {
			switch (stepTexto) {
				case 0:
					mostrarTexto(texto1, "res://escenas/escena2/objetos/textBox1Ramon.tscn");
					stepTexto++;
					break;
				case 1:
					mostrarTexto(texto2, "res://escenas/escena2/objetos/textBox2Ramon.tscn");
					break;
				case 2:
					mostrarTexto(texto3, "res://escenas/escena2/objetos/textBox3Ramon.tscn");
					stepTexto++;
					break;
				case 3:
					mostrarTexto(texto4, "res://escenas/escena2/objetos/textBox4Ramon.tscn");
					if (GnomoSinCosas.tullido) stepTexto++;
					break;
				case 4:
					GD.Print("STEP 4");
					mostrarTexto(texto5, "res://escenas/escena2/objetos/textBox5Ramon.tscn");
					stepTexto++;
					break;
				case 5:
					mostrarTexto(texto5, "res://escenas/escena2/objetos/textBox6Ramon.tscn");
					break;
				case 6:
				Escena2.contestacionRamon();
					break;
			}
		}
	}

	/// <summary>
	/// Metodo que nos permite gestionar los textos de Ramon
	/// </summary>
	/// <param name="escena">Paquete de la escena para que podamos añadirla</param>
	/// <param name="ruta">Ruta de la escena con el texto</param>
	private void mostrarTexto(PackedScene escena, String ruta)
	{
		if (instanciaTextoActual != null)
		{
			instanciaTextoActual.Visible = false;
		}
		escena = (PackedScene)ResourceLoader.Load(ruta);
		instanciaTextoActual = escena.Instantiate() as Node2D;
		instanciaTextoActual.GlobalPosition = new Vector2I(0, -161);
		AddChild(instanciaTextoActual);
	}

	/// <summary>
	/// Señal de godot que nos permite comprobar si la colision de un objeto colisiona contra otro objeto
	/// </summary>
	/// <param name="collisionObject2D">Variable de la colision del objeto que colisiona con el objeto</param>
	private void _on_area_entered(CollisionObject2D collisionObject2D)
	{
		if (collisionObject2D.IsInGroup("Ojo") && !ojoEnseñado)
		{
			ojoEnseñado = true;
			stepTexto++;
		}
	}

}