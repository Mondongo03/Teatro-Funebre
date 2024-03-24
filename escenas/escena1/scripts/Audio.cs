using System.IO;
using Godot;

public partial class Audio : AudioStreamPlayer2D {

	public override void _Ready() {
		GD.Print("Lodeado");
	   Stream = GD.Load("res://escenas/escena1/assets/ring.ogg") as AudioStream;


	}
	public override void _Process(double delta) {
		
		if(VarillaS.ring) {
			GD.Print("Deberia sonar");
        	Play();
        }
	}
}
