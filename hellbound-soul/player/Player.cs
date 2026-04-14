using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 200; // Que tan rapido se mueve el personaje (pixels/sec).
	public Vector2 ScreenSize; // Tamaño de la ventana.

	// Variable de clase para recordar la última dirección
	private string lastDirection = "idle"; // "idle", "up_idle", "down_idle"
	private bool lastFlipH = false;

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	/*
	Delta = tiempo transcurrido desde el frame anterior (secs)
	ej.
	if (gameFPS = 60)
		delta = 0.016

	Formula: D = 1/FPS
	*/
	public override void _Process(double delta)
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		var velocity = Vector2.Zero;

		// Lectura directa de las flechas
		if (Input.IsActionPressed("ui_right")) velocity.X += 1;
		if (Input.IsActionPressed("ui_left"))  velocity.X -= 1;
		if (Input.IsActionPressed("ui_down"))  velocity.Y += 1;
		if (Input.IsActionPressed("ui_up"))    velocity.Y -= 1;

		// Normalizar para evitar que el movimiento diagonal sea mas rapido
		if (velocity.Length() > 0)
			velocity = velocity.Normalized() * Speed;
		
		// Logica animación y estado del movimiento
		if (velocity.Length() > 0)
		{
			animatedSprite2D.Play();
			if (Mathf.Abs(velocity.X) >= Mathf.Abs(velocity.Y))
			{
				// Movimiento horizontal dominante
				animatedSprite2D.Animation = "walk";
				animatedSprite2D.FlipV = false;
				animatedSprite2D.FlipH = velocity.X < 0;

				// Guardar para el idle
				lastDirection = "idle";
				lastFlipH = velocity.X < 0;
			}
			else
			{
				// Movimiento vertical dominante
				animatedSprite2D.FlipH = false;
				animatedSprite2D.Animation = velocity.Y > 0 ? "down" : "up";

				// Guardar para el idle
				lastDirection = velocity.Y > 0 ? "down_idle" : "up_idle";
				lastFlipH = false;
			}
		}
		else
		{
			// Sin movimiento → reproducir idle según última dirección
			animatedSprite2D.FlipH = lastFlipH;
			animatedSprite2D.FlipV = false;
			animatedSprite2D.Animation = lastDirection;
			animatedSprite2D.Play();
		}

		// Apply movement
		Velocity = velocity;
		MoveAndSlide();

		// Clamp to screen bounds
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	}
}
