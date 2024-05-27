using Godot;
using System;

/// <summary>
/// Primera clase del proyecto que nos permite gestionar la primera escena al completo, como instanciar los objetos en ella
/// </summary>
public partial class Main : Node2D
{
    int slotsOcupados;
    Area2D pista_1;
    Node2D godotInstancia2;
    public static Node2D varillaMinutosInstancia,varillaSegundosInstancia,relojZoomeadoInstancia,fondoNegroInstancia,cajonZoomeadoInstancia,huecoInstancia,escaleraInstancia,cajetillaInstancia,tapaInstancia,pista_1Instancia,lamparaEncendidaInstancia,lamparaApagadaInstancia,relojInstancia,posterInstancia,monstruoInstancia, flechaDerechaInstancia;
    Boolean clickadoBola, clickadoVarillaM = false;
    public static Boolean varillaMinutosReloj, varillaSegundosReloj = false;
    [Export] public AnimationPlayer animationPlayer;
    [Export] public AudioStreamPlayer2D audioStreamPlayer2D;
    [Export] public Path2D gnomo;

    bool comprobanteArray = false;

    /// <summary>
    /// Esta función se llama automáticamente cuando se instancia el objeto al cual está asociado el script
    /// </summary>
    public override void _Ready()
    {
        audioStreamPlayer2D.Play();
        animationPlayer.Play("cosa");
        InstanciarEscena();

        if (Reloj.terminado) {
            gnomo.QueueFree();
        }
        if(Despertarse.funciona){
            
        }
    }

    /// <summary>
    /// Este método está siempre en ejecución mientras el objeto que tiene asociado el script esté en pantalla
    /// </summary>
    /// <param name="delta">Es una variable generada por Godot que almacena la posición del objeto</param>
    public override void _Process(double delta) {
        if (varillaMinutosInstancia != null) {
            clickadoVarillaM = VarillaM.devolverClickado();
        }
        if(Despertarse.funciona){
            flechaDerechaInstancia.Visible = true;
        }
    }

    /// <summary>
    /// Método que instancia todos los elementos de la escena y los añade a su respectivo padre
    /// </summary>
    public void InstanciarEscena()
    {
        if (!Reloj.terminado)
        {
            instanciarYAgregarNodo("res://escenas/escena1/objects/varillaM.tscn", ref varillaMinutosInstancia);
            instanciarYAgregarNodo("res://escenas/escena1/objects/varillaS.tscn", ref varillaSegundosInstancia);
        }

        instanciarYAgregarNodo("res://escenas/escena1/objects/reloj.tscn", ref relojInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/hueco.tscn", ref huecoInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/escalera.tscn", ref escaleraInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/cajetilla.tscn", ref cajetillaInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/tapa.tscn", ref tapaInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/pista_1.tscn", ref pista_1Instancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/lamparaApagada.tscn", ref lamparaApagadaInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/poster.tscn", ref posterInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/monstruo.tscn", ref monstruoInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/flechaDerecha.tscn", ref flechaDerechaInstancia);
    }

    /// <summary>
    /// Método que instancia un nodo y lo agrega al árbol de escenas
    /// </summary>
    /// <param name="rutaEscena">Ruta de la escena a instanciar</param>
    /// <param name="node2D">Referencia al nodo instanciado</param>
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
    /// Método que gestiona las pistas de la escena
    /// </summary>
    public void popPista_1()
    {
        pista_1Instancia.Position = new Vector2I(334, 255);
    }

    /// <summary>
    /// Señal de Godot que nos permite poner un contador y cuando llega a cero hace las acciones específicas
    /// </summary>
    public void _on_timer_timeout()
    {
        if (!VarillaM.encontrado || !VarillaS.encontrado)
        {
            popPista_1();
        }
    }
}