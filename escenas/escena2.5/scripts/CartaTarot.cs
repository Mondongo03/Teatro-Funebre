using Godot;
using System;

public partial class CartaTarot : Area2D {
	Sprite2D sprite;
	Timer timer;
	public static bool clickDisponible = false;
	
	public override void _Ready() {
		sprite = GetChild<Sprite2D>(0);
		timer = new Timer();
        AddChild(timer);
        timer.OneShot = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	
	}
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {
	 if(@event.IsActionPressed("click_izquierdo") && CartasCartitas.intento ==0 && !CartasCartitas.animacionBarajarCartas && clickDisponible){
		
		clickDisponible = false;

			if(this.IsInGroup("Sol")) {
				voltearCarta(0);
			}
			else if(this.IsInGroup("Estrella")) {
				voltearCarta(1);
			}
			else if(this.IsInGroup("Luna")) {
				voltearCarta(2);
			}


		}
	}
	async void voltearCarta(int numero){
		CartasCartitas.intento++;
		if(CartasCartitas.cartas[0] == numero) {	
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotSol.png");
		}
		else if(CartasCartitas.cartas[1] == numero) {
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotEstrella.png");
			timer.Start(1);
			await ToSignal(timer, "timeout");
			CartasCartitas.victoria = true;
		}
		else if(CartasCartitas.cartas[2] == numero) {
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotLuna.png");
		}
		timer.Start(1);
        await ToSignal(timer, "timeout");
		if(!CartasCartitas.victoria){
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotGenerica.png");
		}
	}
}
