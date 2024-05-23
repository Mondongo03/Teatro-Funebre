using Godot;
using System;
using System.Collections.Generic;

public partial class Cofre : Area2D {
    public static List<String> objetosGuardados = new List<String>();
    public static List<String> scrptsGuardados = new List<String>();
    static Node2D instanciaActual;
    PackedScene escena;
    static int spawnX = -690;
    static int spawnY = 120;
    static int contadorFilasObjetos = 0;
    Script script;
    public static List<Node2D> nodosCreados = new List<Node2D>();
    public static bool abierto = false;

    public override void _Ready() {
    }

    public override void _Process(double delta) {
        if(CartasCartitas.victoria){
            this.Visible = true;
        }
    }

    private void _on_area_entered(CollisionObject2D collisionObject2D){
        if(this.IsInGroup("Cofre") && !abierto && !collisionObject2D.IsInGroup("FondoNegro")&& !collisionObject2D.IsInGroup("CajonZoomeado")){
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
        if (@event.IsActionPressed("click_izquierdo") && this.IsInGroup("Cofre") ) { //&& CartasCartitas.victoria
            if(!abierto){
                abrirCofre();
                }
             else {
                cerrarCofre();
            }
        }
    }
    private void abrirCofre(){
        // Crear el fondo del cofre
                escena = (PackedScene)ResourceLoader.Load("res://escenas/escena2/objetos/fondoCofre.tscn");
                instanciaActual = escena.Instantiate() as Node2D;
                instanciaActual.Position = new Vector2I(-450, 200); //-200 -300
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
                            spawnX = -690;
                        }
                        contadorFilasObjetos++;
                    }
                  abierto = true;  
    }
    public static void cerrarCofre(){
        if (nodosCreados != null){
                foreach (Node2D nodo in nodosCreados) {
                    nodo.QueueFree();
                }
                }
                spawnX = -690;
                spawnY = 120;
                contadorFilasObjetos = 0; 
                nodosCreados.Clear();
                abierto = false;
    }
}

