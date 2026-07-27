using Godot;
using LearnGodot.core.@event;
using LearnGodot.core.resources.scripts;
using LearnGodot.Event;

namespace LearnGodot.core.Components;

[GlobalClass]
public partial class HealthComponent : Node
{
	[Export] public EntityStats EntityStats;

	/// <summary>
	/// Get if the attached entity is dead.
	/// </summary>
	public bool IsDead { get; private set; }

	private int _health;
	private int _maxHealth;
	
	public override void _Ready()
	{
		_health = EntityStats.CurrentHealth;
		_maxHealth = EntityStats.MaxHealth;
	}

	/// <summary>
	/// Damage the attached entity.
	/// </summary>
	/// <param name="amount">Amount of damage.</param>
	public void TakeDamage(int amount)
	{
		_health -= amount;
		EntityStats.CurrentHealth = _health;
		EventBus.Publish(new PlayerEvents.PlayerDamageEvent(amount));

		if (_health <= 0)
		{
			IsDead = true;
			Death();
		}
	}

	/// <summary>
	/// Heal the attached entity.
	/// </summary>
	/// <param name="amount">Amount of Health to restore.</param>
	public void Heal(int amount)
	{
		if (_health >= _maxHealth) return;

		_health += amount;
		EntityStats.CurrentHealth = _health;
		EventBus.Publish(new PlayerEvents.PlayerHealEvent(amount));
	}

	/// <summary>
	/// Publish the PlayerDeathEvent().
	/// </summary>
	public void Death()
	{
		EventBus.Publish(new PlayerEvents.PlayerDeathEvent());
	}
}