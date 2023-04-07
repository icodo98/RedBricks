using System;
using System.Collections.Generic;
using UnityEngine;

public enum myEventType
{
    GameEnd,
    GameStart, 
    GamePause, 
    GameResume,
    GameOver,
    StageClear,
    HealthChange
}
public interface IListener
{
    void OnEvent(myEventType eventType, Component Sender, object Param = null);
    int priority
    {
        get; 
        set;
    }
}
public class ListenerComparer : IComparer<IListener>
{
    public int Compare(IListener x, IListener y)
    {
        return x.priority.CompareTo(y.priority);
    }
}