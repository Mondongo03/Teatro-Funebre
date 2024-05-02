using Godot;
using System;

/// <summary>
/// Clase que gestiona todo el menu principal
/// </summary>
public partial class MenuPrincipal : CanvasLayer
{
    [ExportGroup("Buttons")]
    [ExportSubgroup("MenuPrincipal")]
    [Export] 
    public Button newGameButton;
    [Export] 
    public Button loadGameButton;
    [Export] 
    public Button settingsButton;
    [Export] 
    public Button exitButton;
    [Export] public AudioStreamPlayer2D audioStreamPlayer2D;
    public static GuardarEscena guardarEscena = new GuardarEscena();

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// </summary>
    public override void _Ready()
    {
        audioStreamPlayer2D.Play();

    }

    /// <summary>
    /// Función llamada cuando se presiona el botón de "Nuevo Juego"
    /// </summary>
    private void _onNewGameButtonPressed()
    {
        GD.Print("Nuevo juego iniciado.");
		GetTree().ChangeSceneToFile("res://escenas/escena1/node_2d.tscn");
    }

    /// <summary>
    /// Función llamada cuando se presiona el botón de "Cargar Juego"
    /// </summary>
    private void _onLoadGameButtonPressed()
    {
        GD.Print("Cargando juego...");
        guardarEscena.LoadGame();
    }

    /// <summary>
    /// Función llamada cuando se presiona el botón de "Configuración"
    /// </summary>
    private void _onSettingsButtonPressed()
    {
        GD.Print("Abriendo configuración...");
        GetTree().ChangeSceneToFile("escenas/MenuOpciones/menu_de_opciones.tscn");
    }

    /// <summary>
    /// Función llamada cuando se presiona el botón de "Salir"
    /// </summary>
    private void _onExitButtonPressed()
    {
        GetTree().Quit();
    }
}
