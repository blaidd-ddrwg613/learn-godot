namespace LearnGodot.Event;

public class PlayerEvents
{
    public record PlayerDamageEvent(int amount) : IEvent;

    public record PlayerHealEvent(int amount) : IEvent;

    public record PlayerDeathEvent() : IEvent;

}