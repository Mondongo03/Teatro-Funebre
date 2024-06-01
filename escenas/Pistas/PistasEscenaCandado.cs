using Godot;
using System;

/// <summary>
/// Clase que nso permite gestionar las pistas de todas las pantallas
/// </summary>
public partial class PistasEscenaCandado : Node2D
{
	public static Sprite2D candado1, candado2, candado3;

	/// <summary>
    /// Esta función se llama automáticamente cuando se instancia el objeto al cual está asociado el script
    /// </summary>
	public override void _Ready() {

		 Node parent = GetParent();

		candado1 = GetSpriteInGroup("Candado1");
		candado2 = GetSpriteInGroup("Candado2");
		candado3 = GetSpriteInGroup("Candado3");

		if(Main.pista1POP && parent.IsInGroup("Escena1") || Escena2.pista1POP && parent.IsInGroup("Escena2") || MainDesvan.pista1POP && parent.IsInGroup("Escena3")){
				candado1.Visible = false;
				GD.Print("Robo sprite1");
			}
		
		if(Main.pista2POP && parent.IsInGroup("Escena1") || Escena2.pista2POP && parent.IsInGroup("Escena2") || MainDesvan.pista2POP && parent.IsInGroup("Escena3")){
			candado2.Visible = false;
			GD.Print("Robo sprite1");
			}
		if(Main.pista3POP && parent.IsInGroup("Escena1") || Escena2.pista3POP && parent.IsInGroup("Escena2") || MainDesvan.pista3POP && parent.IsInGroup("Escena3")){
			candado3.Visible = false;
			GD.Print("Robo sprite1");
			}
	}

	/// <summary>
    /// Este método está siempre en ejecución mientras el objeto que tiene asociado el script esté en pantalla
    /// </summary>
    /// <param name="delta">Es una variable generada por Godot que almacena la posición del objeto</param>
	public override void _Process(double delta) {
	}

	private Sprite2D GetSpriteInGroup(string groupName)
    {
        var nodesInGroup = GetTree().GetNodesInGroup(groupName);

        foreach (Node node in nodesInGroup)
        {
            if (node is Sprite2D sprite)
            {
                return sprite;
            }
        }
		return null; 
	}
}
