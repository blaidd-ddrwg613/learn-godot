using Godot;
using LearnGodot.core.Components;
using LearnGodot.Event;
using EntityStats = LearnGodot.core.resources.scripts.EntityStats;
using Logger = LearnGodot.util.Logger;

namespace LearnGodot.core;

public partial class Player : CharacterBody2D
{
	[Export] public EntityStats EntityStats;
	[Export] public HealthComponent HealthComponent;
	[Export] public InputComponent InputComponent;
	[Export] public MovementComponent MovementComponent;

	public override void _Ready()
	{
		base._Ready();
		
		EventBus.Subscribe<PlayerEvents.PlayerDamageEvent>(OnPlayerDamage);
		EventBus.Subscribe<PlayerEvents.PlayerHealEvent>(OnPlayerHeal);
		EventBus.Subscribe<PlayerEvents.PlayerDeathEvent>(OnPlayerDeath);
	}
	
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		MovementComponent.MovementDir = InputComponent.MoveDir;
		MovementComponent.IsSprinting = InputComponent.IsSprinting;

		InputComponent.Update();
		MovementComponent.Update(delta);
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		
		if (Input.IsActionJustPressed("debug_heal")) HealthComponent.Heal(1);
		if (Input.IsActionJustPressed("debug_hurt")) HealthComponent.TakeDamage(1);
	}

	private void OnPlayerDamage(PlayerEvents.PlayerDamageEvent e)
	{
		Logger.Debug($"Player Damage Event Called: Damage {e.amount}, Current Health: {EntityStats.CurrentHealth}");
	}

	private void OnPlayerHeal(PlayerEvents.PlayerHealEvent e)
	{
		Logger.Debug($"Player Heal Event: Amount: {e.amount}, Current Health: {EntityStats.CurrentHealth}");
	}

	private void OnPlayerDeath(PlayerEvents.PlayerDeathEvent e)
	{
		Logger.Debug($"Player Death Event: Current Health: {EntityStats.CurrentHealth}, Max Health: {EntityStats.MaxHealth} ");
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		
		EventBus.Unsubscribe<PlayerEvents.PlayerDamageEvent>(OnPlayerDamage);
		EventBus.Unsubscribe<PlayerEvents.PlayerHealEvent>(OnPlayerHeal);
		EventBus.Unsubscribe<PlayerEvents.PlayerDeathEvent>(OnPlayerDeath);
	}
}