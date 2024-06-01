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
    public static Node2D narrador, miniVarillaMInstancia, miniVarillaSInstancia, varillaMinutosInstancia, pista, varillaSegundosInstancia,relojZoomeadoInstancia,fondoNegroInstancia,cajonZoomeadoInstancia,huecoInstancia,escaleraInstancia,cajetillaInstancia,tapaInstancia,pista_1Instancia,lamparaEncendidaInstancia,lamparaApagadaInstancia,relojInstancia,posterInstancia,monstruoInstancia, flechaDerechaInstancia, camaInstancia;
    Boolean clickadoBola, clickadoVarillaM = false;
    public static bool subir;
    static int narradorNum = 0;
    public static Boolean varillaMinutosReloj, varillaSegundosReloj = false;
    [Export] public AnimationPlayer animationPlayer;
    [Export] public AudioStreamPlayer2D audioStreamPlayer2D;
    [Export] public Path2D gnomo;

    static Timer pista1, pista2, pista3;

    public static bool pista1POP, pista2POP, pista3POP;

    bool comprobanteArray = false;

    /// <summary>
    /// Esta función se llama automáticamente cuando se instancia el objeto al cual está asociado el script
    /// </summary>
    public override void _Ready() {

        pista1 = new Timer();
        pista2 = new Timer();
        pista3 = new Timer();

        // Agregar los timers de las super pistas a la escena
        AddChild(pista1);
        AddChild(pista2);
        AddChild(pista3);
        pista1Timer();
        audioStreamPlayer2D.Play();
        animationPlayer.Play("cosa");
        InstanciarEscena();

        if (Reloj.terminado) {
            gnomo.QueueFree();
        }
        if(Despertarse.funciona){
            flechaDerechaInstancia.Visible = true;
        }
        if(narradorNum == 0){
            narradorNum++;
            instanciarYAgregarNodo("res://escenas/Pistas/NarracionEscena1.tscn", ref narrador);
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
        
    }

    /// <summary>
    /// Método que instancia todos los elementos de la escena y los añade a su respectivo padre
    /// </summary>
     void InstanciarEscena() {
        if (!VarillaM.encontrado) instanciarYAgregarNodo("res://escenas/escena1/objects/varillaM.tscn", ref varillaMinutosInstancia);
            
        //else instanciarYAgregarNodo("res://escenas/escena1/objects/MiniVarillaM.tscn", ref miniVarillaMInstancia);


        if (!VarillaS.encontrado) instanciarYAgregarNodo("res://escenas/escena1/objects/varillaS.tscn", ref varillaSegundosInstancia);

       // else  instanciarYAgregarNodo("res://escenas/escena1/objects/MiniVarillaS.tscn", ref miniVarillaSInstancia);
           

        instanciarYAgregarNodo("res://escenas/escena1/objects/reloj.tscn", ref relojInstancia);
        if(!Reloj.terminado) instanciarYAgregarNodo("res://escenas/escena1/objects/hueco.tscn", ref huecoInstancia);
        
        instanciarYAgregarNodo("res://escenas/escena1/objects/escalera.tscn", ref escaleraInstancia);
        if (subir)
        {
            escaleraInstancia.Position = new Vector2I((int)escaleraInstancia.Position.X, -75);
        }
        instanciarYAgregarNodo("res://escenas/escena1/objects/cajetilla.tscn", ref cajetillaInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/tapa.tscn", ref tapaInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/pista_1.tscn", ref pista_1Instancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/lamparaApagada.tscn", ref lamparaApagadaInstancia);
        //instanciarYAgregarNodo("res://escenas/escena1/objects/poster.tscn", ref posterInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/monstruo.tscn", ref monstruoInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/flechaDerecha.tscn", ref flechaDerechaInstancia);
        instanciarYAgregarNodo("res://escenas/escena1/objects/cama.tscn", ref camaInstancia);
        instanciarYAgregarNodo("res://escenas/Pistas/pista.tscn", ref pista);
        pista.AddToGroup("Escena1");
        pista.Position = new Vector2I(1064, 72);
        
    }

    /// <summary>
    /// Método que instancia un nodo y lo agrega al árbol de escenas
    /// </summary>
    /// <param name="rutaEscena">Ruta de la escena a instanciar</param>
    /// <param name="node2D">Referencia al nodo instanciado</param>
    private void instanciarYAgregarNodo(String rutaEscena, ref Node2D node2D)
{
    foreach (String objeto in Cofre.objetosGuardados)
    {
        if (objeto.Equals(rutaEscena))
        {
            comprobanteArray = true;
        }
    }

    if (!comprobanteArray)
    {
        PackedScene escena = (PackedScene)ResourceLoader.Load(rutaEscena);
        node2D = escena.Instantiate() as Node2D;

        // Usar call_deferred para agregar el nodo al árbol de nodos
        CallDeferred("add_child", node2D);
    }
    comprobanteArray = false;
}


    /// <summary>
    /// Método que gestiona las pistas de la escena
    /// </summary>
    public async void pista1Timer() {
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