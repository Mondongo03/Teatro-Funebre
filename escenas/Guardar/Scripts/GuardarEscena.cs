using Godot;
using System;

/// <summary>
/// Clase que nos permite guardar la artida
/// </summary>
public partial class GuardarEscena : Node
{
	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	public override void _Ready()
	{
	}

	/// <summary>
	/// Called every frame. 'delta' is the elapsed time since the previous frame.
	/// </summary>
	/// <param name="delta"></param>
	public override void _Process(double delta)
	{
	}

	/// <summary>
	/// Metodo que nos permite guardar las escenas
	/// </summary>
	/// <param name="tree">Esta variable es el tree de las escenas</param>
	public void SaveGame(Node tree)
	{
	    using var saveGame = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);

	    var saveNodes = tree.GetTree().GetNodesInGroup("Persist");
	    foreach (Node saveNode in saveNodes)
	    {
	        // Check the node is an instanced scene so it can be instanced again during load.
	        if (string.IsNullOrEmpty(saveNode.SceneFilePath))
	        {
	            GD.Print($"persistent node '{saveNode.Name}' is not an instanced scene, skipped");
	            continue;
	        }

	        // Check the node has a save function.
	        if (!saveNode.HasMethod("Save"))
	        {
	            GD.Print($"persistent node '{saveNode.Name}' is missing a Save() function, skipped");
	            continue;
	        }

	        // Call the node's save function.
	        var nodeData = saveNode.Call("Save");

	        // Json provides a static method to serialized JSON string.
	        var jsonString = Json.Stringify(nodeData);

	        // Store the save dictionary as a new line in the save file.
	        saveGame.StoreLine(jsonString);
	    }
	}

	/// <summary>
	/// Note: This can be called from anywhere inside the tree. This function is
	/// path independent.
	/// </summary>
	public void LoadGame()
	{
	    if (!FileAccess.FileExists("user://savegame.save"))
	    {
	        return; // Error! We don't have a save to load.
	    }

	    // We need to revert the game state so we're not cloning objects during loading.
	    // This will vary wildly depending on the needs of a project, so take care with
	    // this step.
	    // For our example, we will accomplish this by deleting saveable objects.
	    var saveNodes = GetTree().GetNodesInGroup("Persist");
	    foreach (Node saveNode in saveNodes)
	    {
	        saveNode.QueueFree();
	    }

	    // Load the file line by line and process that dictionary to restore the object
	    // it represents.
	    using var saveGame = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);

	    while (saveGame.GetPosition() < saveGame.GetLength())
	    {
	        var jsonString = saveGame.GetLine();

	        // Creates the helper class to interact with JSON
	        var json = new Json();
	        var parseResult = json.Parse(jsonString);
	        if (parseResult != Error.Ok)
	        {
	            GD.Print($"JSON Parse Error: {json.GetErrorMessage()} in {jsonString} at line {json.GetErrorLine()}");
	            continue;
	        }

	        // Get the data from the JSON object
	        var nodeData = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);

	        // Firstly, we need to create the object and add it to the tree and set its position.
	        var newObjectScene = GD.Load<PackedScene>(nodeData["Filename"].ToString());
	        var newObject = newObjectScene.Instantiate<Node>();
	        GetNode(nodeData["Parent"].ToString()).AddChild(newObject);
	        newObject.Set(Node2D.PropertyName.Position, new Vector2((float)nodeData["PosX"], (float)nodeData["PosY"]));

	        // Now we set the remaining variables.
	        foreach (var (key, value) in nodeData)
	        {
	            if (key == "Filename" || key == "Parent" || key == "PosX" || key == "PosY")
	            {
	                continue;
	            }
	            newObject.Set(key, value);
	        }
	    }
	}
}