using System;
using System.Collections.Generic;

namespace LearnGodot.Event;

public interface IEvent { }

public static class EventBus
{
    private static readonly Dictionary<Type, List<Delegate>> _subscribers = new();

    public static void Subscribe<T>(Action<T> handler) where T : IEvent
    {
        ArgumentNullException.ThrowIfNull(handler);

        var type = typeof(T);

        if (!_subscribers.TryGetValue(type, out var handlers))
        {
            handlers = new List<Delegate>();
            _subscribers[type] = handlers;
        }

        if (!handlers.Contains(handler))
        {
            handlers.Add(handler);
        }
    }

    public static void Unsubscribe<T>(Action<T> handler) where T : IEvent
    {
        ArgumentNullException.ThrowIfNull(handler);

        var type = typeof(T);

        if (!_subscribers.TryGetValue(type, out var handlers))
        {
            return;
        }

        handlers.Remove(handler);

        if (handlers.Count == 0)
        {
            _subscribers.Remove(type);
        }
    }

    public static void Publish<T>(T @event) where T : IEvent
    {
        ArgumentNullException.ThrowIfNull(@event);

        var type = typeof(T);

        if (!_subscribers.TryGetValue(type, out var handlers))
        {
            return;
        }

        var handlersSnapshot = handlers.ToArray();

        foreach (var handler in handlersSnapshot)
        {
            ((Action<T>)handler)(@event);
        }
    }
}