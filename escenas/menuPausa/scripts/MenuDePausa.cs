using Godot;
using System;

public partial class MenuDePausa : Control
{
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

	}

	public void _on_salir_al_menu_principal_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("escenas/menuInicio/node_2d.tscn");
	}
}
