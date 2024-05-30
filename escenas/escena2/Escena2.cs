using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar todo lo que ocurre en la segunda escena
/// </summary>
public partial class Escena2 : Node2D
{
	public static Node2D node2D, gnomoCrecer, ojo, cofre, pista, hueso, huesoPegadoCuerpo, flor1, flor2, flor3, flor4, flor5, flor6, carta;
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;
	bool comprobanteArray = false;
	bool comprobanteCrecer = false;
	Timer timer;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		timer = new Timer();
		AddChild(timer);
		timer.OneShot = false;
		audioStreamPlayer2D = GetChild<AudioStreamPlayer2D>(2);
		audioStreamPlayer2D.Play();

		if (!Hueso.metidoEnCaldero)
		{
			instanciarYAgregarNodo("res://escenas/escena2/objetos/hueso.tscn", ref hueso);
			hueso.Position = new Vector2I(545, 512);
		}

		if (!Flor.metidoEnCaldero) instanciarYAgregarNodo("res://escenas/escena2/objetos/florLilaEspecial.tscn", ref flor5);

		InstanciarEscena();
	}

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public async override void _Process(double delta)
	{
		if (GnomoSinCosas.crecer && !comprobanteCrecer)
		{
			try
			{
				ojo.QueueFree();
			}
			catch (Exception e)
			{ }
			instanciarYAgregarNodo("res://escenas/escena2/objetos/GnomoCreciendo.tscn", ref gnomoCrecer);
			gnomoCrecer.Position = new Vector2I(500, 420);
			comprobanteCrecer = true;
			timer.Start(1);
			await ToSignal(timer, "timeout");
			carta.QueueFree();

		}
	}

	/// <summary>
    /// Método que instancia un nodo y lo agrega al árbol de escenas
    /// </summary>
    /// <param name="rutaEscena">Ruta de la escena a instanciar</param>
    /// <param name="node2D">Referencia al nodo instanciado</param>
	public void instanciarYAgregarNodo(String rutaEscena, ref Node2D node2D)
	{

		foreach (String objeto in Cofre.objetosGuardados)
		{
			if (objeto.Equals(rutaEscena)) comprobanteArray = true;
		}
		if (!comprobanteArray)
		{
			PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
			node2D = escena.Instantiate() as Node2D;
			AddChild(node2D);
		}
		comprobanteArray = false;
	}

	/// <summary>
    /// Método que instancia todos los elementos de la escena y los añade a su respectivo padre
    /// </summary>
	void InstanciarEscena()
	{
		instanciarYAgregarNodo("res://escenas/escena2/objetos/ojo.tscn", ref ojo);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/huesoPegadoCuerpo.tscn", ref huesoPegadoCuerpo);
		instanciarYAgregarNodo("res://escenas/Pistas/pista.tscn", ref pista);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florAmarilla.tscn", ref flor1);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florAmarillaGrande.tscn", ref flor2);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florAzul.tscn", ref flor3);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florLila.tscn", ref flor4);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/florRoja.tscn", ref flor6);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/greenPeace.tscn", ref node2D);
		instanciarYAgregarNodo("res://escenas/escena2/objetos/carta.tscn", ref carta);
	}
}
