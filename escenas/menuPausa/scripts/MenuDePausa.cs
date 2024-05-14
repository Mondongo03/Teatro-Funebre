using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar el menu de pausa dentro del juego
/// </summary>
public partial class MenuDePausa : Control
{
	[Export] private Button continuar, opciones, salir, exit;
	[Export] private CanvasLayer video, sonido;

	public GuardarEscena guardarEscena = new GuardarEscena();

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui.accept"))
		{
			Visible = true;
			GetTree().Paused = true;
		}
		if (Visible == true)
		{
			if (Input.IsActionPressed("ui.accept"))
			{
				GetTree().Paused = false;
				Visible = true;
			}
		}
	}

	/// <summary>
	/// Metodo que se llama cuando clickas el boton de continuar
	/// </summary>
	public void _on_continuar_pressed()
	{
		GetTree().Paused = false;
		Hide();
	}

	/// <summary>
	/// Metodo que se llama cuando clickas el boton de opciones y las muestra en pantalla 
	/// </summary>
	public void _on_opciones_pressed()
	{
		continuar.Hide();
		opciones.Hide();
		salir.Hide();
		video.Visible = true;
		sonido.Visible = true;
		exit.Visible = true;
		Video_settings.setPantalla(true);
	}

	/// <summary>
	/// Metodo que se activa cuando pulsas el boton de salir al menu y te lleva a el
	/// </summary>
	public void _on_salir_al_menu_principal_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("escenas/menuInicio/node_2d.tscn");
	}

	/// <summary>
	/// Metodo del boton exit de la pestaña de ajustes
	/// </summary>
	public void _on_exit_pressed()
	{
		continuar.Visible = true;
		opciones.Visible = true;
		salir.Visible = true;
		exit.Hide();
		video.Hide();
		sonido.Hide();
		Video_settings.setPantalla(false);
	}
}
