using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get { return _instance; } }
    private static EventManager _instance = null;

    private Dictionary<myEventType, List<IListener>> Listeners =
        new Dictionary<myEventType, List<IListener>>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    /*
     * �̺�Ʈ �����ʸ� �߰�. Listeners ����Ʈ�� eventType�� listener�о �ִ��� �˻��ϰ� ���ٸ� ���� �߰�, �ִٸ� ����Ʈ�� add
     */
    public void AddListener(myEventType eventType, IListener listener)
    {
        List<IListener> ListenerList = null;
        if (Listeners.TryGetValue(eventType, out ListenerList))
        {
            ListenerList.Add(listener);
            return;
        }
        ListenerList = new List<IListener>();
        ListenerList.Add(listener);
        Listeners.Add(eventType, ListenerList);
    }
    /*
     �̺�Ʈ�� �߻�������� �̺�Ʈ �Ŵ������� �˷���.     
     */
    public void PostNotification(myEventType eventType, Component Sender, object param = null)
    {
        List<IListener> ListenerList = null;
        if(!Listeners.TryGetValue(eventType, out ListenerList))
        {
            return;
        }
        for (int i = 0; i < ListenerList.Count; i++)
            ListenerList?[i].OnEvent(eventType, Sender, param);
    }

    public void RemoveEvent(myEventType eventType) => Listeners.Remove(eventType);
    public void RemoveRedundancies()
    {
        Dictionary<myEventType,List<IListener>> ListenerList = new Dictionary<myEventType, List<IListener>>();
        foreach (KeyValuePair<myEventType, List<IListener>> Item in Listeners)
        {
            for (int i = Item.Value.Count - 1; i >= 0; i--)
            {
                if (Item.Value[i].Equals(null))
                {
                    Item.Value.RemoveAt(i);
                }
            }
            if(Item.Value.Count > 0) {
            ListenerList.Add(Item.Key, Item.Value);
            }

        }
        Listeners = ListenerList;
    }

    void OnSecenLoaded(Scene scene, LoadSceneMode level)
    {
        RemoveRedundancies();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSecenLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSecenLoaded;
    }
}
