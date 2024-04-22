using Godot;
using System;

public partial class Volumen_settings : CanvasLayer
{
	private int master,vfx,music;

	[Export] private HSlider master_slider,vfx_slider,music_slider;

	[Export] private Label master_porcentual,vfx_porcentual,music_porcentual;

	private static GameData gameData = new GameData();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		master_slider.Value = gameData.masterVolume;
		vfx_slider.Value = gameData.sfxVolume;
		music_slider.Value = gameData.musicVolume;

		master_porcentual.Text = (int)gameData.masterVolume  + "%";
		vfx_porcentual.Text = (int)gameData.sfxVolume  + "%";
		music_porcentual.Text = (int)gameData.musicVolume  + "%";

		master = AudioServer.GetBusIndex("Master");
		vfx = AudioServer.GetBusIndex("Ejecftos de sonido");
		music = AudioServer.GetBusIndex("Musica");
	}

	public void _on_volumen_master_value_changed(float volumen)
	{
		master_porcentual.Text = (int)volumen + "%";
		AudioServer.SetBusVolumeDb(master, Mathf.LinearToDb(volumen));
		gameData.masterVolume = volumen;
	}

	public void _on_volumen_vfx_value_changed(float volumen)
	{
		vfx_porcentual.Text = (int)volumen + "%";
		AudioServer.SetBusVolumeDb(vfx, Mathf.LinearToDb(volumen));
		gameData.sfxVolume = volumen;
	}

	public void _on_volumen_musica_value_changed(float volumen)
	{
		music_porcentual.Text = (int)volumen + "%";
		AudioServer.SetBusVolumeDb(music, Mathf.LinearToDb(volumen));
		gameData.musicVolume = volumen;
	}
}
