using System.Collections.Generic;
using System;

public class WaitFor
{
    List<Action> thens = new List<Action>();
    List<Action> thenAlwayses = new List<Action>();

    public void Then(Action action)
    {
        thens.Add(action);
    }

    public void ThenAlways(Action action)
    {
        thenAlwayses.Add(action);
    }

    public void Flush()
    {
        thens = new List<Action>();
        thenAlwayses = new List<Action>();
    }

    public void Happened()
    {
        foreach (Action action in thens)
        {
            action.Invoke();
        }

        foreach (Action action in thenAlwayses)
        {
            action.Invoke();
        }

        thens = new List<Action>();
    }
}

public class WaitFor<T>
{
    List<Action<T>> thens = new List<Action<T>>();
    List<Action<T>> thenAlwayses = new List<Action<T>>();

    public void Then(Action<T> action)
    {
        thens.Add(action);
    }

    public void ThenAlways(Action<T> action)
    {
        thenAlwayses.Add(action);
    }

    public void Happened(T arg)
    {
        foreach (Action<T> action in thens)
        {
            action.Invoke(arg);
        }

        foreach (Action<T> action in thenAlwayses)
        {
            action.Invoke(arg);
        }

        thens = new List<Action<T>>();
    }
}
