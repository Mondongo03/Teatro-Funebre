using Godot;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public partial class MenuOpciones : Node
{
	[Export] public AnimatedSprite2D animatedSprite2D;
	[Export] public Button button;
	private int master,vfx,music;
	[Export] private HSlider master_slider,vfx_slider,music_slider;
	[Export] private Label master_porcentual,vfx_porcentual,music_porcentual;
	private static GameData gameData = new GameData();
	[ExportGroup("resolucion")]
	[Export] private OptionButton optionButton;
	private static bool pantalla = false;
	public override void _Ready()
	{
		AddResolutionToButton();
		animatedSprite2D.Play("abrir");
		master_slider.Value = gameData.masterVolume;
		vfx_slider.Value = gameData.sfxVolume;
		music_slider.Value = gameData.musicVolume;

		master_porcentual.Text = (int)gameData.masterVolume  + "%";
		vfx_porcentual.Text = (int)gameData.sfxVolume  + "%";
		music_porcentual.Text = (int)gameData.musicVolume  + "%";

		master = AudioServer.GetBusIndex("Master");
		vfx = AudioServer.GetBusIndex("Ejecftos de sonido");
		music = AudioServer.GetBusIndex("Musica");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_color_rect_animation_finished()
	{
		if (animatedSprite2D.Animation.ToString().Equals("cerrar"))
		{
			GetTree().ChangeSceneToFile("escenas/menuInicio/node_2d.tscn");
		}
	}

	private void _on_exit_pressed()
	{
		animatedSprite2D.Play("cerrar");
	}

	/// <summary>
	/// Metodo que nos permite cambiar el porcentaje de sonido del buffer master
	/// </summary>
	/// <param name="volumen">Parametro de volumen deseado</param>
	public void _on_volumen_master_value_changed(float volumen)
	{
		master_porcentual.Text = (int)volumen + "%";
		AudioServer.SetBusVolumeDb(master, Mathf.LinearToDb(volumen));
		gameData.masterVolume = volumen;
	}

	/// <summary>
	/// Metodo que nos permite cambiar el porcentaje de sonido del buffer efectos de sonido
	/// </summary>
	/// <param name="volumen">Parametro de volumen deseado</param>
	public void _on_volumen_vfx_value_changed(float volumen)
	{
		vfx_porcentual.Text = (int)volumen + "%";
		AudioServer.SetBusVolumeDb(vfx, Mathf.LinearToDb(volumen));
		gameData.sfxVolume = volumen;
	}

	/// <summary>
	/// Metodo que nos permite cambiar el porcentaje de sonido del buffer musica
	/// </summary>
	/// <param name="volumen">Parametro de volumen deseado</param>
	public void _on_volumen_musica_value_changed(float volumen)
	{
		music_porcentual.Text = (int)volumen + "%";
		AudioServer.SetBusVolumeDb(music, Mathf.LinearToDb(volumen));
		gameData.musicVolume = volumen;
	}

	/// <summary>
	/// Setter de pantalla
	/// </summary>
	/// <param name="s">Cambia el bool de pantalla</param>
	public static void setPantalla(bool s)
	{
		pantalla = s;
	}

	/// <summary>
	/// Metodo que nos permite gestionar el cambio de resolucion
	/// </summary>
	private void AddResolutionToButton()
	{
		foreach(var item in gameData.windowResolutions){
			string myString = item.Key + "x" + item.Value;
			optionButton.AddItem(myString);
		}
	}

	/// <summary>
	/// Metodo que guarda las opciones elegidas por el usuario
	/// </summary>
	private void Save()
	{
    	string userDataDir = OS.GetUserDataDir();
    	string configFolderPath = Path.Combine(userDataDir, "config");

    	try
    	{
    	    if (!Directory.Exists(configFolderPath))
    	    {
    	        Directory.CreateDirectory(configFolderPath);
    	    }
    	    XElement xmlData = new XElement("Settings", new XElement("Resolution", optionButton.Selected));
    	    string filePath = Path.Combine(configFolderPath, "settings.xml");
        	xmlData.Save(filePath);
    	}
    	catch (IOException ex)
    	{
    	    GD.Print("Error al guardar la configuración: " + ex.Message);
   		}
	}

	/// <summary>
	/// Señal de godot que se activa sola cuando haces click en el boton vinculado
	/// </summary>
	public void _on_button_pressed()
	{
		ApplyGameDataVideoSettings();
		Save();
	}

	/// <summary>
	/// Metodo que gestiona el desplegable de resoluciones y aplica la resolucion seleccionada
	/// </summary>
	/// <param name="mySelectedRez">Cambia la resolucion actual</param>
	public void _on_option_button_item_selected(int mySelectedRez)
	{
		gameData.resolutionIndex = mySelectedRez;
	}

	/// <summary>
	/// Metodo que aplica todos los cambios en el juego
	/// </summary>
	public static void ApplyGameDataVideoSettings() 
	{
        if (gameData.windowResolutions.Count > 0) {
        	int key = gameData.windowResolutions.Keys.ElementAt(gameData.resolutionIndex);
        	int value = gameData.windowResolutions[key];
			GD.Print(key + "," + value);
        	DisplayServer.WindowSetSize(new Vector2I(key, value));

			Vector2I screenSize = DisplayServer.WindowGetSize();
        	Vector2I windowSize = new Vector2I(key, value);
        	Vector2I newPosition = (screenSize - windowSize) / 2;

			DisplayServer.WindowSetPosition(newPosition);
        } else {
        	DisplayServer.WindowSetSize(new Vector2I(1280, 720));

			DisplayServer.WindowSetPosition((DisplayServer.WindowGetSize() - new Vector2I(1280, 720)) / 2);
        }
    }
}
