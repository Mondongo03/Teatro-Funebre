using Godot;
using Microsoft.VisualBasic;
using System;

/// <summary>
/// Clase que nos permite gestionar la flecha que aparece y nos permite subir al desban en la primera escena
/// </summary>
public partial class Flecha : Area2D
{

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="evento">Nos permite detectar cuando se hace click</param>
	/// <param name="shap">Variable que se utiliza para la API</param>
	public void _on_input_event(Node viewport, InputEvent evento, int shap)
	{
		if (evento.IsActionPressed("click_izquierdo")){
			if(Cofre.abierto) Cofre.cerrarCofre();
			try{
			if(Narracion.pistasAbiertas &&  Narracion.pistasInstancia != null){
				Narracion.pistasInstancia.QueueFree();
				Narracion.pistasAbiertas = false;
			}
			}catch (ExecutionEngineException e){}
			
			if(this.IsInGroup("HaciaDesvan")){
				GetTree().ChangeSceneToFile("res://escenas/escena3/node_2d.tscn");
				Main.subir = true;
			}
			if(this.IsInGroup("HaciaCasa")) GetTree().ChangeSceneToFile("res://escenas/escena1/node_2d.tscn");
			if(this.IsInGroup("HaciaBosque")) GetTree().ChangeSceneToFile("res://escenas/escena2/Prueba.tscn");
		}
	}
	void _on_area_entered(CollisionObject2D collisionObject2D){
		GD.Print("Esta");
		if(collisionObject2D.IsInGroup("CaminoFinal")){
			GD.Print("Pasamos el if");
			GetTree().ChangeSceneToFile("res://escenas/EscenaFinal/Final.tscn");
		}
	}
}
