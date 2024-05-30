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
    [Export] public AnimatedSprite2D animatedSprite2D;
    public static GuardarEscena guardarEscena = new GuardarEscena();
    bool opcion = false;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// </summary>
    public override void _Ready()
    {
        audioStreamPlayer2D.Play();
        animatedSprite2D.Play("abrir");
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
        animatedSprite2D.Play("cerrar");
        opcion = true;
    }

    /// <summary>
    /// Función llamada cuando se presiona el botón de "Salir"
    /// </summary>
    private void _onExitButtonPressed()
    {
        animatedSprite2D.Play("cerrar");
        opcion = false;
    }

    /// <summary>
    /// Senal de godot que nos permite saber cuando una animacion a finalizado
    /// </summary>
    private void _on_color_rect_animation_finished()
    {
        if(animatedSprite2D.Animation.ToString().Equals("cerrar") && opcion)
        {
            GetTree().ChangeSceneToFile("escenas/MenuOpciones/menu_de_opciones.tscn");
        }else if (animatedSprite2D.Animation.ToString().Equals("cerrar") && !opcion)
        {
            GetTree().Quit();
        }
    }
}
