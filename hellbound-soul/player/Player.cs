using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 300; // How fast the player will move (pixels/sec).
	public Vector2 ScreenSize; // Size of the game window.

	private Vector2 _targetPosition;
	private bool _isMovingToTarget = false;
	private const float ARRIVAL_THRESHOLD = 5.0f; // Distancia a la que se considera "llegado" (5.0"f" --> se define como f para evitar errores de compilacion [f = float])

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		_targetPosition = Position; // Inicializa el objetivo en la posicion actual
	}

	public override void _Input(InputEvent @event)
	{
		// Detecta si se hizo click o se mantuvo el boton izq del mouse
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left && mouseButton.Pressed)
			{
				// Convierte el click en la posicin de la pantalla a la posicion en el mundo
				// screen(1920*1080) --> gameCamera(same to the screen)
				_targetPosition = GetGlobalMousePosition();
				_isMovingToTarget = true;
			}
		}

		// Mientras se mantiene el click izq, se sigue actualizando el objetivo en la posicion del mouse
		if (@event is InputEventMouseMotion && Input.IsMouseButtonPressed(MouseButton.Left))
		{
			_targetPosition = GetGlobalMousePosition();
			_isMovingToTarget = true;
		}
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

		if (_isMovingToTarget)
		{
			Vector2 direction = _targetPosition - Position;
			float distance = direction.Length();

			if (distance > ARRIVAL_THRESHOLD)
			{
				// Cuando se avanza hacia el objetivo
				velocity = direction.Normalized() * Speed;
			}
			else
			{
				// Cuando se llega al objetivo
				_isMovingToTarget = false;
				Position = _targetPosition; // Se ajusta a la posicion exacta
			}
		}

		// --- Animation logic ---
		if (velocity.Length() > 0)
		{
			animatedSprite2D.Play();

			if (Mathf.Abs(velocity.X) >= Mathf.Abs(velocity.Y))
			{
				// Horizontal movement dominates
				animatedSprite2D.Animation = "walk";
				animatedSprite2D.FlipV = false;
				animatedSprite2D.FlipH = velocity.X < 0;
			}
			else
			{
				// Vertical movement dominates
				animatedSprite2D.FlipH = false;
				animatedSprite2D.Animation = velocity.Y > 0 ? "down" : "up";
			}
		}
		else
		{
			animatedSprite2D.Stop();
		}

		// Apply movement
		Position += velocity * (float)delta;

		// Clamp to screen bounds
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	}
}
