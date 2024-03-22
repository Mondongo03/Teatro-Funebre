using Godot;
using System;

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

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Conecta los botones a sus respectivas señales

    }

    // Función llamada cuando se presiona el botón de "Nuevo Juego"
    private void _onNewGameButtonPressed()
    {
        GD.Print("Nuevo juego iniciado.");
		GetTree().ChangeSceneToFile("res://escenas/escena1/node_2d.tscn");
    }

    // Función llamada cuando se presiona el botón de "Cargar Juego"
    private void _onLoadGameButtonPressed()
    {
        // Aquí puedes agregar la lógica para cargar un juego guardado
        GD.Print("Cargando juego...");
    }

    // Función llamada cuando se presiona el botón de "Configuración"
    private void _onSettingsButtonPressed()
    {
        // Aquí puedes agregar la lógica para abrir el menú de configuración
        GD.Print("Abriendo configuración...");
    }

    // Función llamada cuando se presiona el botón de "Salir"
    private void _onExitButtonPressed()
    {
        // Aquí puedes agregar la lógica para salir del juego
        GetTree().Quit();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.SS
    public override void _Process(double delta)
    {
        // Puedes agregar código de proceso aquí si es necesario
    }
}