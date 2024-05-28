using Godot;
using System;

/// <summary>
/// Escript que nos permite gestionar como funciona la escena 3
/// </summary>
public partial class MainDesvan : Node2D {
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;
	bool comprobanteArray = false;
	private static bool ritualAcabado;
	public static Node2D unicornioVerde, unicornioRojo, unicornioNaranja, unicornioBlanco, unicornioAmarillo, particulaUA, particulaUR, particulaUV, particulaUN, particulaUB, relojDesvan;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		if(!ritualAcabado){
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioAmarillo.tscn", ref unicornioAmarillo);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioBlanco.tscn", ref unicornioBlanco);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioNaranja.tscn", ref unicornioNaranja);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioRojo.tscn", ref unicornioRojo);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioVerde.tscn", ref unicornioVerde);
		}
		instanciarMain();
		
		//audioStreamPlayer2D.Play();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}

	public static void setRitualAcabado(bool ritual)
	{
		ritualAcabado = ritual;
	}

	public static bool getRitualAcabado()
	{
		return ritualAcabado;
	}
	private void instanciarYAgregarNodo(String rutaEscena, ref Node2D node2D) {

        foreach(String objeto in Cofre.objetosGuardados){
            if(objeto.Equals(rutaEscena)) comprobanteArray = true;
        }
        if(!comprobanteArray){
        PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
        node2D = escena.Instantiate() as Node2D;
        AddChild(node2D);
        }
        comprobanteArray = false;
    }
	private void instanciarMain(){
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUA.tscn", ref particulaUA);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUR.tscn", ref particulaUR);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUV.tscn", ref particulaUV);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUN.tscn", ref particulaUN);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUB.tscn", ref particulaUB);
		instanciarYAgregarNodo("res://escenas/escena3/objects/RelojDesvan.tscn", ref relojDesvan);

	}
}
