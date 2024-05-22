using Godot;
using System;
using System.Collections.Generic;

public partial class Cofre : Area2D {
    public static List<String> objetosGuardados = new List<String>();
    public static List<String> scrptsGuardados = new List<String>();
    static Node2D instanciaActual;
    PackedScene escena;
    int spawnX = -440;
    int spawnY = -420;
    int contadorFilasObjetos = 0;
    Script script;
    public static List<Node2D> nodosCreados = new List<Node2D>();
    public static bool abierto = false;

    public override void _Ready() {
    }

    public override void _Process(double delta) {
    }

    private void _on_area_entered(CollisionObject2D collisionObject2D){
        if(this.IsInGroup("Cofre") && !abierto){
            objetosGuardados.Add(collisionObject2D.SceneFilePath);
            script = (Script)collisionObject2D.GetScript();
            GD.Print(script.ResourcePath);
            scrptsGuardados.Add(script.ResourcePath);
            collisionObject2D.QueueFree();
            GD.Print("Entra");
            GD.Print(objetosGuardados[0]);
            GD.Print(scrptsGuardados[0]);
        }
    }

    private void _on_area_exited(CollisionObject2D collisionObject2D) {
        if(!this.IsInGroup("Cofre") && abierto){
            string collisionPath = collisionObject2D.SceneFilePath;
            objetosGuardados.RemoveAll((slot) => slot == collisionPath);
            nodosCreados.RemoveAll((node) => node.SceneFilePath == collisionPath);
            GD.Print("Sale");
        }
    }

    void _on_input_event(Node viewport, InputEvent @event, long shape_idx){
        if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Cofre")) {
            if(!abierto){
                GD.Print("Hola");

                // Crear el fondo del cofre
                escena = (PackedScene)ResourceLoader.Load("res://escenas/escena2/objetos/fondoCofre.tscn");
                instanciaActual = escena.Instantiate() as Node2D;
                instanciaActual.Position = new Vector2I(-200, -300);
                AddChild(instanciaActual);
                nodosCreados.Add(instanciaActual);

                // Crear los objetos guardados
                foreach(String objeto in objetosGuardados){
                        escena = (PackedScene)ResourceLoader.Load(objeto);
                        instanciaActual = escena.Instantiate() as Node2D;
                        instanciaActual.GlobalPosition = new Vector2I(spawnX, spawnY);
                        AddChild(instanciaActual);
                        nodosCreados.Add(instanciaActual);
                        spawnX+=120;
                        if(contadorFilasObjetos%4==0 && contadorFilasObjetos!=0) {
                            spawnY+=120;
                            spawnX = -440;
                        }
                        contadorFilasObjetos++;
                    }
                  abierto = true;  
                }
             else {
                foreach (Node2D nodo in nodosCreados) {
                    nodo.QueueFree();
                }
                spawnX = -440;
                spawnY = -420;
                contadorFilasObjetos = 0; 
                nodosCreados.Clear();
                abierto = false;
            }
        }
    }
}

