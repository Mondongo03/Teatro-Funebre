using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar cómo funciona el Reloj y que pueda almacenar objetos dentro del mismo
/// </summary>
public partial class Reloj : Area2D
{
    public static bool zoooom = false;
    public static bool terminado = false;
    public static bool suena = false;
    public static Node2D miniVarillaMInstancia;
    public static Node2D miniVarillaSInstancia;
    [Export] public AudioStreamPlayer2D audioStreamPlayer2D;

    /// <summary>
    /// Esta función se llama automáticamente cuando se instancia el objeto al cual está asociado el script
    /// </summary>
    public override void _Ready()
    {
        if(terminado)
        {
            InstanciarYAgregarNodo("res://escenas/escena1/objects/miniVarillaM.tscn", ref miniVarillaMInstancia);
            InstanciarYAgregarNodo("res://escenas/escena1/objects/miniVarillaS.tscn", ref miniVarillaSInstancia);
        }
    }

    /// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
    public override void _Process(double delta)
    {
        if (terminado && !suena)
        {
            audioStreamPlayer2D.Play();
            suena = true;
        }
        Cajon.SetZoom(RelojZoomeado.zoooom);
    }

    /// <summary>
	/// Señal de godot que nos permite comprobar si la colision de un objeto colisiona contra otro objeto
	/// </summary>
	/// <param name="collisionObject2D">Variable de la colision del objeto que colisiona con el objeto</param>
    public void _on_reloj_entered(CollisionObject2D collisionObject2D)
    {
        if (collisionObject2D.IsInGroup("VarillaM") && Main.varillaMinutosInstancia != null)
        {
            VarillaM.encontrado = true;
            collisionObject2D.QueueFree();
            Main.varillaMinutosReloj = true;
            InstanciarYAgregarNodo("res://escenas/escena1/objects/miniVarillaM.tscn", ref miniVarillaMInstancia);
        }
        if (collisionObject2D.IsInGroup("VarillaS"))
        {
            VarillaS.encontrado = true;
            Main.varillaSegundosReloj = true;
            collisionObject2D.QueueFree();
            InstanciarYAgregarNodo("res://escenas/escena1/objects/miniVarillaS.tscn", ref miniVarillaSInstancia);
        }
    }

    /// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="evento">Nos permite detectar cuando se hace click</param>
	/// <param name="shap">Variable que se utiliza para la API</param>
    public void _on_input_event(Node viewport, InputEvent evento, int shap)
    {
        if (evento.IsActionPressed("click_izquierdo") && !RelojZoomeado.zoooom && !Cajon.zoooom)
        {
            if (!VarillaM.encontrado && !VarillaS.encontrado)
            {
                InstanciarYAgregarNodo("res://escenas/escena1/objects/fondoNegro.tscn", new Vector2I(-400, -400), 0, ref Main.fondoNegroInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/relojZoomeado.tscn", 4, ref Main.relojZoomeadoInstancia);
            }
            else if (VarillaM.encontrado && !VarillaS.encontrado)
            {
                InstanciarYAgregarNodo("res://escenas/escena1/objects/fondoNegro.tscn", new Vector2I(-400, -400), 0, ref Main.fondoNegroInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/relojZoomeado.tscn", 4, ref Main.relojZoomeadoInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/varillaM.tscn", new Vector2I(235, 80), 5, ref Main.varillaMinutosInstancia);
            }
            else if (!VarillaM.encontrado && VarillaS.encontrado)
            {
                InstanciarYAgregarNodo("res://escenas/escena1/objects/fondoNegro.tscn", new Vector2I(-400, -400), 0, ref Main.fondoNegroInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/relojZoomeado.tscn", 4, ref Main.relojZoomeadoInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/varillaS.tscn", new Vector2I(235, 80), 5, ref Main.varillaSegundosInstancia);
            }
            else if (VarillaM.encontrado && VarillaS.encontrado && !Cajon.encontrado && !terminado)
            {
                zoooom = true;
                InstanciarYAgregarNodo("res://escenas/escena1/objects/fondoNegro.tscn", new Vector2I(-400, -400), 0, ref Main.fondoNegroInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/relojZoomeado.tscn", 4, ref Main.relojZoomeadoInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/varillaM.tscn", new Vector2I(235, 80), 5, ref Main.varillaMinutosInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/varillaS.tscn", new Vector2I(235, 80), 5, ref Main.varillaSegundosInstancia);
            }
            else if (VarillaM.encontrado && VarillaS.encontrado && Cajon.encontrado && !terminado)
            {
                zoooom = true;
                InstanciarYAgregarNodo("res://escenas/escena1/objects/fondoNegro.tscn", new Vector2I(-400, -400), 0, ref Main.fondoNegroInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/relojZoomeado.tscn", 4, ref Main.relojZoomeadoInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/varillaM.tscn", new Vector2I(235, 80), 5, ref Main.varillaMinutosInstancia);
                InstanciarYAgregarNodo("res://escenas/escena1/objects/varillaS.tscn", new Vector2I(235, 80), 5, ref Main.varillaSegundosInstancia);
            }
        }
    }

    /// <summary>
    /// Método que instancia un nodo y lo agrega al árbol de escenas
    /// </summary>
    /// <param name="rutaEscena">Ruta de la escena a instanciar</param>
    /// <param name="posicion">Referencia a la posicion deseada al instanciar el nodo</param>
    /// <param name="zIndex">Referencia al indice deseado en el nodo</param>
    /// <param name="node2D">Referencia al nodo instanciado</param>
    private void InstanciarYAgregarNodo(string rutaEscena, Vector2I posicion, int zIndex, ref Node2D node2D)
    {
        PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
        node2D = escena.Instantiate() as Node2D;
        node2D.GlobalPosition = posicion;
        node2D.ZIndex = zIndex;
        AddChild(node2D);
    }

    /// <summary>
    /// Método que instancia un nodo y lo agrega al árbol de escenas
    /// </summary>
    /// <param name="rutaEscena">Ruta de la escena a instanciar</param>
    /// <param name="zIndex">Referencia al indice deseado en el nodo</param>
    /// <param name="node2D">Referencia al nodo instanciado</param>
    private void InstanciarYAgregarNodo(string rutaEscena, int zIndex, ref Node2D node2D)
    {
        PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
        node2D = escena.Instantiate() as Node2D;
        node2D.ZIndex = zIndex;
        AddChild(node2D);
    }

    /// <summary>
    /// Método que instancia un nodo y lo agrega al árbol de escenas
    /// </summary>
    /// <param name="rutaEscena">Ruta de la escena a instanciar</param>
    /// <param name="node2D">Referencia al nodo instanciado</param>
	private void InstanciarYAgregarNodo(string rutaEscena, ref Node2D node2D)
    {
        PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
        node2D = escena.Instantiate() as Node2D;
        AddChild(node2D);
    }

    /// <summary>
    /// Getter de zooom
    /// </summary>
    /// <returns>devuelve la varibale de la clase zooom</returns>
    public static Boolean GetZoom()
    {
        return zoooom;
    }

    /// <summary>
    /// Setter de zooom
    /// </summary>
    /// <param name="value">El valor que queremos darle a zooom</param>
    public static void SetZoom(Boolean value)
    {
        zoooom = value;
    }
}