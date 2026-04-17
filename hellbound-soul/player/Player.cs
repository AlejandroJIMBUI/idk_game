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

	// Var para configurar el radial blur
	private Camera2D _camera;
    private ColorRect _colorRect;
    private ShaderMaterial _shaderMaterial;

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		_camera = GetNode<Camera2D>("Camera2D");
		_colorRect = GetNode<ColorRect>("CanvasLayer/ColorRect");
		_shaderMaterial = (ShaderMaterial)_colorRect.Material;

		var canvasLayer = GetNode<CanvasLayer>("CanvasLayer");
		canvasLayer.FollowViewportEnabled = false;
		canvasLayer.Layer = 10;
		canvasLayer.Offset = Vector2.Zero;
		canvasLayer.Transform = Transform2D.Identity;

		// Ajustar el ColorRect al área visible real según el zoom
		Vector2 visibleSize = ScreenSize / _camera.Zoom;
		_colorRect.Position = Vector2.Zero;
		_colorRect.Size = visibleSize;

		_shaderMaterial.SetShaderParameter("focus_center", new Vector2(0.5f, 0.5f));
		_shaderMaterial.SetShaderParameter("focus_radius", 0.1f);
		_shaderMaterial.SetShaderParameter("blur_strength", 10.0f);
		_shaderMaterial.SetShaderParameter("softness", 0.6f);

		// Escalar el CanvasLayer para que el ColorRect ocupe toda la pantalla
		canvasLayer.Transform = new Transform2D(
			_camera.Zoom.X, 0,
			0, _camera.Zoom.Y,
			0, 0
		);
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

		/*
		// Clamp to screen bounds
        Vector2 visibleArea = ScreenSize / _camera.Zoom;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, visibleArea.X / 2, ScreenSize.X - visibleArea.X / 2),
            y: Mathf.Clamp(Position.Y, visibleArea.Y / 2, ScreenSize.Y - visibleArea.Y / 2)
        );

        // Shader siempre centrado en el jugador (centro de pantalla)
        // Con FollowViewportEnabled el jugador siempre está en el centro
        _shaderMaterial.SetShaderParameter("focus_center", new Vector2(0.5f, 0.5f));
		*/

		// Clamp solo para situaciones especificas
	}
}
