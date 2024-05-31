using Godot;
using System;

public partial class PistasEscenaCandado : Node2D
{
	public static Sprite2D candado1, candado2, candado3;
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


	// Called every frame. 'delta' is the elapsed time since the previous frame.
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
