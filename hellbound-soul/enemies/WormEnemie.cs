using Godot;
using System;

public partial class WormEnemie : CharacterBody2D
{
	// Logica animación
	public override void _Ready()
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite2D.Animation = "idle";
		animatedSprite2D.Play();
	}
}
