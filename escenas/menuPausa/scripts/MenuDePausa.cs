using Godot;
using System;

public partial class MenuDePausa : Control
{
	[Export] private Button continuar,opciones,salir,exit;
	[Export] private CanvasLayer video,sonido;

	public GuardarEscena guardarEscena = new GuardarEscena();

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui.accept")){
			Visible = true;
			GetTree().Paused = true;
		}
		if (Visible == true){
			if (Input.IsActionPressed("ui.accept")){
				GetTree().Paused = false;
				Visible = true;
			}
		}
	}

	public void _on_continuar_pressed()
	{
		GetTree().Paused = false;
		Hide();
	}

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

	public void _on_salir_al_menu_principal_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("escenas/menuInicio/node_2d.tscn");
	}

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
