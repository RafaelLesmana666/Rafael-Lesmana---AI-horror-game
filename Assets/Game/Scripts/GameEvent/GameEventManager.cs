using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    private static GameEventManager _instance;
    private Dictionary<string, GameEventBase> _gameEvent = new Dictionary<string, GameEventBase>();

    public static GameEventManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Register(GameEventBase gameEvent)
    {
        if (!_gameEvent.ContainsKey(gameEvent.ID))
        {
            _gameEvent.Add(gameEvent.ID, gameEvent);
        }
    }

    public void Unregister(GameEventBase gameEvent)
    {
        if (_gameEvent.ContainsKey(gameEvent.ID))
        {
            _gameEvent.Remove(gameEvent.ID);
        }
    }

    public void TriggerEvent(string id)
    {
        bool isExisted = _gameEvent.TryGetValue(id, out GameEventBase gameEvent);
        if (isExisted)
        {
            gameEvent.Trigger();
        }
    }

    public void FinishEvent(string id)
    {
        bool isExisted = _gameEvent.TryGetValue(id, out GameEventBase gameEvent);
        if (isExisted)
        {
            gameEvent.Finish();
        }
    }

    // Update is called once per frame
    void Update() { }
}
