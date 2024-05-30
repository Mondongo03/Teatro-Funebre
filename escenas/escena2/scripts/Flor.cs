using Godot;
using System;

/// <summary>
/// Gestion de las flores de la segunda pantalla
/// </summary>
public partial class Flor : Area2D
{
	static bool puedoMover = false;
	static Flor objetoEnMovimiento = null;
	public Node2D node2D;
	public static bool metidoEnCaldero = false;
	
	/// <summary>
    /// Esta función se llama automáticamente cuando se instancia el objeto al cual está asociado el script
    /// </summary>
	public override void _Ready() {
	}

	/// <summary>
    /// Este método está siempre en ejecución mientras el objeto que tiene asociado el script esté en pantalla
    /// </summary>
    /// <param name="delta">Es una variable generada por Godot que almacena la posición del objeto</param>
	public override void _Process(double delta) {
		if (puedoMover && objetoEnMovimiento == this) this.GlobalPosition = GetGlobalMousePosition();
	}
		private void _on_input_event(Node viewport, InputEvent @event, long shape_idx) {

		if (@event.IsActionPressed("click_izquierdo")) {
			puedoMover = true;
			objetoEnMovimiento = this;
		}
		if (@event.IsActionReleased("click_izquierdo")) {
			puedoMover = false;
			objetoEnMovimiento = null;
		}
	}

	/// <summary>
	/// Señal de godot que nos permite saber cuando el raton entra en contacto con la colisionbox de la flor
	/// </summary>
	private void _on_mouse_entered(){
		Escena2.node2D.Visible = true;
	}

	/// <summary>
	/// Señal de godot que nos permite saber cuando el raton sale del contacto con la colisionbox de la flor
	/// </summary>
	private void _on_mouse_exited(){
		Escena2.node2D.Visible = false;
	}
}
