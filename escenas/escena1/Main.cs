using Godot;
using System;
using System.Numerics;
using System.Threading;

/// <summary>
/// Primera case del proyecto que nos per mite gestionar la primera escena al completo, como instanciar los objetos en ella
/// </summary>
public partial class Main : Node2D
{
	int slotsOcupados;
	Area2D pista_1;
	Node2D godotInstancia2;
	public static Node2D varillaMinutosInstancia;
	public static Node2D varillaSegundosInstancia;
	public static Node2D relojZoomeadoInstancia;
	public static Node2D fondoNegroInstancia;
	public static Node2D cajonZoomeadoInstancia;
	public static Node2D huecoInstancia;
	public static Node2D escaleraInstancia;
	public static Node2D cajetillaInstancia;
	public static Node2D tapaInstancia;
	public static Node2D pista_1Instancia;
	public static Node2D lamparaEncendidaInstancia;
	public static Node2D lamparaApagadaInstancia;
	public static Node2D relojInstancia;
	public static Node2D posterInstancia;
	public static Node2D monstruoInstancia;
	Boolean clickadoBola = false;
	Boolean clickadoVarillaM = false;
	public static Boolean varillaMinutosReloj = false;
	public static Boolean varillaSegundosReloj = false;
	[Export] public AnimationPlayer animationPlayer;
	[Export] public AudioStreamPlayer2D audioStreamPlayer2D;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		audioStreamPlayer2D.Play();
		animationPlayer.Play("cosa");
		InstanciarEscena();
	}
	
	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
	{
		if (varillaMinutosInstancia != null)
		{
			clickadoVarillaM = VarillaM.devolverClickado();
		}
	}

	/// <summary>
	/// Metodo que instancia todos los elementos de la escena y los añade a su respectivo padre
	/// </summary>
	public void InstanciarEscena()
	{


		PackedScene reloj = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/reloj.tscn");
		relojInstancia = reloj.Instantiate() as Node2D; // Cast the instance to Node
		AddChild(relojInstancia);

		PackedScene varillaMinutos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaM.tscn");
		varillaMinutosInstancia = varillaMinutos.Instantiate() as Node2D; // Cast the instance to Node
		AddChild(varillaMinutosInstancia);

		PackedScene varillaSegundos = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/varillaS.tscn");
		varillaSegundosInstancia = varillaSegundos.Instantiate() as Node2D; // Cast the instance to Node
		AddChild(varillaSegundosInstancia);

		PackedScene hueco = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/hueco.tscn");
		huecoInstancia = hueco.Instantiate() as Node2D; // Cast the instance to Node
		AddChild(huecoInstancia);

		PackedScene escalera = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/escalera.tscn");
		escaleraInstancia = escalera.Instantiate() as Node2D; // Cast the instance to Node
		AddChild(escaleraInstancia);

		PackedScene cajetilla = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/cajetilla.tscn");
		cajetillaInstancia = cajetilla.Instantiate() as Node2D;
		AddChild(cajetillaInstancia);

		PackedScene tapa = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/tapa.tscn");
		tapaInstancia = tapa.Instantiate() as Node2D;
		AddChild(tapaInstancia);

		PackedScene pista_1 = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/pista_1.tscn");
		pista_1Instancia = pista_1.Instantiate() as Node2D;
		AddChild(pista_1Instancia);

		PackedScene lamparaApagada = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/lamparaApagada.tscn");
		lamparaApagadaInstancia = lamparaApagada.Instantiate() as Node2D;
		AddChild(lamparaApagadaInstancia);

		PackedScene poster = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/poster.tscn");
		posterInstancia = poster.Instantiate() as Node2D;
		AddChild(posterInstancia);

		PackedScene monstruo = (PackedScene)ResourceLoader.Load("res://escenas/escena1/objects/monstruo.tscn");
		monstruoInstancia = monstruo.Instantiate() as Node2D;
		AddChild(monstruoInstancia);

	}

	/// <summary>
	/// Metodo que gestina las pistas de la escena
	/// </summary>
	public void popPista_1()
	{
		pista_1Instancia.Position = new Vector2I(334, 255);
	}

	/// <summary>
	/// Señal de godot que nos permite poner un contador y cuando llega a cero hace las acciones especificas
	/// </summary>
	public void _on_timer_timeout()
	{
		if (VarillaM.encontrado == false || VarillaS.encontrado == false)
		{
			popPista_1();
		}
	}
}

