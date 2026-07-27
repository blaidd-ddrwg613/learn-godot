using Godot;
using LearnGodot.core.resources.scripts;
using LearnGodot.Event;

namespace LearnGodot.core.Components;

[GlobalClass]
public partial class HealthComponent : Node
{
	[Export] public EntityStats EntityStats;

	public bool IsDead { get; private set; }

	private int _health;
	private int _maxHealth;
	
	public override void _Ready()
	{
		_health = EntityStats.CurrentHealth;
		_maxHealth = EntityStats.MaxHealth;
	}

	public override void _Process(double delta)
	{
		
	}

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

	public void Heal(int amount)
	{
		if (_health >= _maxHealth) return;

		_health += amount;
		EntityStats.CurrentHealth = _health;
		EventBus.Publish(new PlayerEvents.PlayerHealEvent(amount));
	}

	public void Death()
	{
		EventBus.Publish(new PlayerEvents.PlayerDeathEvent());
	}
}