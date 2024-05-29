using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar todo lo que ocurre en la segunda escena
/// </summary>
public partial class escena2 : Node2D
{
	public static Node2D node2D, ojo, cofre, pista, hueso, huesoPegadoCuerpo, flor1, flor2, flor3, flor4, flor5, flor6;
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;
	bool comprobanteArray = false;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		audioStreamPlayer2D.Play();
		instanciarYAgregarNodo("res://escenas/escena2/objetos/ojo.tscn", ref ojo);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/hueso.tscn", ref hueso);
		hueso.Position = new Vector2I(545, 512);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/huesoPegadoCuerpo.tscn", ref huesoPegadoCuerpo);
		instanciarYAgregarNodo("res://escenas/Pistas/pista.tscn", ref pista);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florAmarilla.tscn", ref flor1);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florAmarillaGrande.tscn", ref flor2);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florAzul.tscn", ref flor3);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florLila.tscn", ref flor4);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florLilaEspecial.tscn", ref flor5);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florRoja.tscn", ref flor6);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/greenPeace.tscn", ref node2D);
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta) {
		
	}
	public void instanciarYAgregarNodo(String rutaEscena, ref Node2D node2D) {

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
}
