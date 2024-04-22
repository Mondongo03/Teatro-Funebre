using Godot;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public partial class Video_settings : CanvasLayer
{
	[ExportGroup("resolucion")]
	[Export] private OptionButton optionButton;
	[Export] private Button exit;

	private static GameData gameData = new GameData();
	private static bool pantalla = false;

	public static void setPantalla(bool s)
	{
		pantalla = s;
	}



	public override void _Ready()
    {

		AddResolutionToButton();

    }

	public override void _Process(double delta)
    {
		if(pantalla){
			exit.Hide();
		}else{
			exit.Visible = true;
		}
    }

	private void AddResolutionToButton()
	{
		foreach(var item in gameData.windowResolutions){
			string myString = item.Key + "x" + item.Value;
			optionButton.AddItem(myString);
		}
	}

	private void Save()
	{
    	// Obtener la ruta del directorio de usuario en Godot
    	string userDataDir = OS.GetUserDataDir();

    	// Crear la ruta completa del directorio de configuración
    	string configFolderPath = Path.Combine(userDataDir, "config");

    	try
    	{
    	    // Crear el directorio de configuración si no existe
    	    if (!Directory.Exists(configFolderPath))
    	    {
    	        Directory.CreateDirectory(configFolderPath);
    	    }

    	    // Crear y guardar el archivo de configuración en el directorio
    	    XElement xmlData = new XElement("Settings", new XElement("Resolution", optionButton.Selected));

    	    // Guardar el XML en un archivo dentro del directorio de configuración
    	    string filePath = Path.Combine(configFolderPath, "settings.xml");
        	xmlData.Save(filePath);
    	}
    	catch (IOException ex)
    	{
    	    GD.Print("Error al guardar la configuración: " + ex.Message);
   		}
	}


	public void _on_button_pressed()
	{
		ApplyGameDataVideoSettings();
		Save();
	}

	public void _on_option_button_item_selected(int mySelectedRez)
	{
		gameData.resolutionIndex = mySelectedRez;
	}

	public static void ApplyGameDataVideoSettings() 
	{
        // Verificar si hay resoluciones disponibles en el diccionario
        if (gameData.windowResolutions.Count > 0) {
        	// Obtener la resolución según el índice especificado en gameData.resolutionIndex
        	int key = gameData.windowResolutions.Keys.ElementAt(gameData.resolutionIndex);
        	int value = gameData.windowResolutions[key];
			GD.Print(key + "," + value);
        	DisplayServer.WindowSetSize(new Vector2I(key, value));

			Vector2I screenSize = DisplayServer.WindowGetSize();
        	Vector2I windowSize = new Vector2I(key, value);
        	Vector2I newPosition = (screenSize - windowSize) / 2;

			DisplayServer.WindowSetPosition(newPosition);
        } else {
        	// Si no hay resoluciones disponibles, usar la resolución predeterminada o alguna lógica alternativa
        	// Esto es solo un ejemplo, puedes manejarlo según tus necesidades
        	DisplayServer.WindowSetSize(new Vector2I(1280, 720));

			DisplayServer.WindowSetPosition((DisplayServer.WindowGetSize() - new Vector2I(1280, 720)) / 2);
        }
    }
	
	public void _on_exit_pressed()
	{
		GetTree().ChangeSceneToFile("escenas/menuInicio/node_2d.tscn");
	}
}
