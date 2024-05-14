using System.IO;
using Godot;

/// <summary>
/// Esta clase es para getionar el efecto de sonido de la primera escena
/// </summary>
public partial class Audio : AudioStreamPlayer2D {

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready() {
		GD.Print("Lodeado");
	   Stream = GD.Load("res://escenas/escena1/assets/ring.ogg") as AudioStream;
	}
	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta) {
		
		if(VarillaS.ring) {
			GD.Print("Deberia sonar");
        	Play();
        }
	}
}
