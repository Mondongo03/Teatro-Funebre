using Godot;
using System;

/// <summary>
/// Escript que nos permite gestionar como funciona la escena 3
/// </summary>
public partial class MainDesvan : Node2D {
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;
	bool comprobanteArray = false;
	static int narradorNum = 0;
	public static bool ritualAcabado;
	static bool comprobanteSangre = false;
	public static Node2D pista, narrador, megaPoti, vial, unicornioVerde, unicornioRojo, unicornioNaranja, unicornioBlanco, unicornioAmarillo, particulaUA, particulaUR, particulaUV, particulaUN, particulaUB, relojDesvan, caldero, izquierda, derecha, arriba, abajoDerecha, abajoIzquierda, muebleRecetario;
	
	static Timer pista1, pista2, pista3;

    public static bool pista1POP, pista2POP, pista3POP;
	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready() {
		pista1 = new Timer();
        pista2 = new Timer();
        pista3 = new Timer();

        // Agregar los timers de las super pistas a la escena
        AddChild(pista1);
        AddChild(pista2);
        AddChild(pista3);
        pista3Timer();

		if(!ritualAcabado){
			if(narradorNum == 0){
				instanciarYAgregarNodo("res://escenas/Pistas/NarracionEscena3PrePoti.tscn", ref narrador);
				narradorNum++;
			}
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioAmarillo.tscn", ref unicornioAmarillo);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioBlanco.tscn", ref unicornioBlanco);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioNaranja.tscn", ref unicornioNaranja);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioRojo.tscn", ref unicornioRojo);
			instanciarYAgregarNodo("res://escenas/escena3/objects/unicornioVerde.tscn", ref unicornioVerde);
		}
		instanciarMain();
		audioStreamPlayer2D.Play();
		
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta) {
		if(ritualAcabado && !comprobanteSangre){
			comprobanteSangre = true;
			instanciarYAgregarNodo("res://escenas/escena3/objects/vialSangre.tscn", ref vial);
		}
		if(MegaPoti.lleno && narradorNum == 1){
			instanciarYAgregarNodo("res://escenas/Pistas/NarracionEscena3PostPoti.tscn", ref narrador);
			narradorNum++;
		}
		
	}

	/// <summary>
    /// Método que instancia todos los elementos de la escena y los añade a su respectivo padre
    /// </summary>
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
	/// <summary>
    /// Método que instancia todos los elementos de la escena y los añade a su respectivo padre
    /// </summary>
	private void instanciarMain(){
		instanciarYAgregarNodo("res://escenas/escena3/objects/izquierda.tscn", ref izquierda);
		instanciarYAgregarNodo("res://escenas/escena3/objects/derecha.tscn", ref derecha);
		instanciarYAgregarNodo("res://escenas/escena3/objects/abajoDerecha.tscn", ref abajoDerecha);
		instanciarYAgregarNodo("res://escenas/escena3/objects/abajoIzquierda.tscn", ref abajoIzquierda);
		instanciarYAgregarNodo("res://escenas/escena3/objects/arriba.tscn", ref arriba);

		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUA.tscn", ref particulaUA);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUR.tscn", ref particulaUR);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUV.tscn", ref particulaUV);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUN.tscn", ref particulaUN);
		instanciarYAgregarNodo("res://escenas/escena3/objects/ParticulaUB.tscn", ref particulaUB);
		instanciarYAgregarNodo("res://escenas/escena3/objects/caldero.tscn", ref caldero);
		instanciarYAgregarNodo("res://escenas/escena3/objects/relojDesvan.tscn", ref relojDesvan);
		instanciarYAgregarNodo("res://escenas/escena3/objects/muebleRecetario.tscn", ref muebleRecetario);
		instanciarYAgregarNodo("res://escenas/escena3/objects/megaPoti.tscn", ref megaPoti);
		instanciarYAgregarNodo("res://escenas/Pistas/pista.tscn", ref pista);
		pista.Position = new Vector2I(1072, 130);
		pista.AddToGroup("Escena3");
	}

	/// <summary>
	/// Metodo que nos permite gestionar como funcionan las pistas en esta pantalla
	/// </summary>
	public async void pista3Timer() {
        pista1.Start(5);
	    await ToSignal(pista1, "timeout");
        GD.Print("Timer1");
        pista1POP = true;
        
        pista2.Start(5);
	    await ToSignal(pista2, "timeout");
        pista2POP = true;
        GD.Print("Timer2");

        pista3.Start(5);
	    await ToSignal(pista3, "timeout");
        pista3POP = true;
        GD.Print("Timer3");
    }
}
