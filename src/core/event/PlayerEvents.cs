using LearnGodot.Event;

namespace LearnGodot.core.@event;

public abstract class PlayerEvents
{
    /// <summary>
    /// This event is called when the player takes damage.
    /// </summary>
    /// <param name="amount"> The amount of damage taken.</param>
    public record PlayerDamageEvent(int amount) : IEvent;

    /// <summary>
    /// This event is called when the player restores health.
    /// </summary>
    /// <param name="amount">The amount of health restored.</param>
    public record PlayerHealEvent(int amount) : IEvent;

    /// <summary>
    /// This event is called when the player dies.
    /// </summary>
    public record PlayerDeathEvent() : IEvent;

}