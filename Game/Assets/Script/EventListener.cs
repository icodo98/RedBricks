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
}
