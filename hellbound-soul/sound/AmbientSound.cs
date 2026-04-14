using Godot;
using System;

public partial class BackgroundMusic : Node
{
	public override void _Ready()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		audioPlayer.Play();
	}
}
