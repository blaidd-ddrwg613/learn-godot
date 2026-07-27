using System;
using Godot;
using LearnGodot.core.resources.scripts;

namespace LearnGodot.core.Components;

[GlobalClass]
public partial class MovementComponent : Node
{
	[Export] public CharacterBody2D Body { get; set; }
	
	[Export] public EntityStats PlayerStats;

	/// <summary>
	/// The movement Direction of the character.
	/// </summary>
	[Export] public Vector2 MovementDir { get; set; } = Vector2.Zero;

	/// <summary>
	/// Movement speed of the character default is 400.
	/// </summary>
	[Export] public float MovementSpeed { get; set; }

	/// <summary>
	/// Speed modifier for when the character is sprinting default is 1.5;
	/// </summary>
	[Export] public float SprintMultiplier { get; set; }
    
	[Export] public bool IsSprinting { get; set; }

	public override void _Ready()
	{
		base._Ready();

		MovementSpeed = PlayerStats.MovementSpeed;
		SprintMultiplier = PlayerStats.SprintMultiplier;
	}


	public void Update(double delta)
	{
		if (Body == null)
			throw new NullReferenceException("Body Cannot Be Null");

		var speed = IsSprinting ? MovementSpeed * SprintMultiplier : MovementSpeed;
		var velocity = MovementDir * speed;
		Body.Velocity = velocity;
        
		Body.MoveAndSlide();
	}
}