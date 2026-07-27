using Godot;
using System;
using LearnGodot.core.resources.scripts;

[GlobalClass]
public partial class InputComponent : Node
{
	[Export] public EntityStats PlayerStats;

	public Vector2 MoveDir { get; set; } = Vector2.Zero;

	public bool IsSprinting { get; set; }

	public void Update()
	{
		MoveDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		IsSprinting = Input.IsActionPressed("sprint");
	}
}
