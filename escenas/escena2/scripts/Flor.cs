using Godot;
using System;

public partial class Flor : Area2D
{
	static bool puedoMover = false;
	static Flor objetoEnMovimiento = null;
	public Node2D node2D;
	public static bool metidoEnCaldero = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (puedoMover && objetoEnMovimiento == this) this.GlobalPosition = GetGlobalMousePosition();
	}
	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{

		if (@event.IsActionPressed("click_izquierdo"))
		{
			puedoMover = true;
			objetoEnMovimiento = this;
		}
		if (@event.IsActionReleased("click_izquierdo"))
		{
			puedoMover = false;
			objetoEnMovimiento = null;
		}
	}
	private void _on_mouse_entered()
	{
		Escena2.node2D.Visible = true;
	}
	private void _on_mouse_exited()
	{
		Escena2.node2D.Visible = false;
	}


}
