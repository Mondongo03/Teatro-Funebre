using Godot;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Menu de las opciones de video del juego
/// </summary>
public partial class Video_settings : CanvasLayer
{
	[ExportGroup("resolucion")]
	[Export] private OptionButton optionButton;

	private static GameData gameData = new GameData();
	private static bool pantalla = false;

	/// <summary>
	/// Setter de pantalla
	/// </summary>
	/// <param name="s">Cambia el bool de pantalla</param>
	public static void setPantalla(bool s)
	{
		pantalla = s;
	}

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
    {
		AddResolutionToButton();
    }

	/// <summary>
	/// Este metodo esta siempre en ejecucion mientras el objeto que tiene asociado el script este en pantalla
	/// </summary>
	/// <param name="delta">Es una varibale generada por Godot que almacena la posicion del objeto</param>
	public override void _Process(double delta)
    {
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
	
	/// <summary>
	/// Metodo que nos permite gestionar cuando alguien le da al boton de exit
	/// </summary>
	public void _on_exit_pressed()
	{
		GetTree().ChangeSceneToFile("escenas/menuInicio/node_2d.tscn");
	}
}
