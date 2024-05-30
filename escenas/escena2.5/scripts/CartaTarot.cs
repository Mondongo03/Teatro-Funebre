using Godot;
using System;

/// <summary>
/// Clase que nos permite gestionar las cartas en el mini juego del tarot
/// </summary>
public partial class CartaTarot : Area2D
{
	Sprite2D sprite;
	Timer timer;
	public static bool clickDisponible = false;

	/// <summary>
	/// Esta funcion se llama automaticamente cuando se instancia el objeto al cual esta asociado el script
	/// </summary>
	public override void _Ready()
	{
		sprite = GetChild<Sprite2D>(0);
		timer = new Timer();
		AddChild(timer);
		timer.OneShot = true;
	}

	/// <summary>
	/// Este metodo es una señal del propio godot que nos permite detectar cuando haces click sobre le objeto
	/// </summary>
	/// <param name="viewport">Nodo del objeto parte de la API</param>
	/// <param name="event">Nos permite detectar cuando se hace click</param>
	/// <param name="shape_idx">Variable que se utiliza para la API</param>
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsActionPressed("click_izquierdo") && CartasCartitas.intento == 0 && !CartasCartitas.animacionBarajarCartas && clickDisponible)
		{

			clickDisponible = false;

			if (this.IsInGroup("Sol"))
			{
				voltearCarta(0);
			}
			else if (this.IsInGroup("Estrella"))
			{
				voltearCarta(1);
			}
			else if (this.IsInGroup("Luna"))
			{
				voltearCarta(2);
			}


		}
	}

	/// <summary>
	/// Metodo que nos permite gestionar como se revelan las castas y que sprite poner a cada una cuando se revela
	/// </summary>
	/// <param name="numero">Es la variable que nos permite gestionar el numero de la array</param>
	/// <returns></returns>
	async void voltearCarta(int numero)
	{
		CartasCartitas.intento++;
		if (CartasCartitas.cartas[0] == numero)
		{
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotSol.png");
		}
		else if (CartasCartitas.cartas[1] == numero)
		{
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotEstrella.png");
			timer.Start(1);
			await ToSignal(timer, "timeout");
			CartasCartitas.victoria = true;
		}
		else if (CartasCartitas.cartas[2] == numero)
		{
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotLuna.png");
		}
		timer.Start(1);
		await ToSignal(timer, "timeout");
		if (!CartasCartitas.victoria)
		{
			this.sprite.Texture = (Texture2D)GD.Load("res://escenas/escena2.5/assets/CartaTarotGenerica.png");
		}
	}
}
