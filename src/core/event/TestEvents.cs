namespace LearnGodot.Event;

public class TestEvents
{
    public record TestEvent(params object[] message) : IEvent;
}