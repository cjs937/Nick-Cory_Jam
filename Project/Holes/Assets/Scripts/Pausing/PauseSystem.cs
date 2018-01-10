using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour, IListener
{
    public List<Pausable> pausableObjects;
    public bool systemPaused = false;
    public static PauseSystem instance = null;

    void Awake()
    {
        if (PauseSystem.instance == null)
            PauseSystem.instance = this;
        else
        {
            Destroy(gameObject);

            return;
        }

        pausableObjects = new List<Pausable>();
    }

	// Use this for initialization
	void Start ()
    {
        EventSystem.addListener(this, EventType.PAUSE);
        EventSystem.addListener(this, EventType.RESUME);
    }
	
    void Update()
    {
    }

    public void handleEvent(Event _event)
    {
        switch (_event.type)
        {
            case (EventType.PAUSE):
                {
                    pauseSystem(_event as PauseGameEvent);
                    break;
                }
            case (EventType.RESUME):
                {
                    if (!systemPaused)
                        break;

                    UnpauseGameEvent pauseEvent = _event as UnpauseGameEvent;

                    if (pauseEvent.dontUnpause != null)
                    {
                        unpauseObjects(pauseEvent.dontUnpause);
                    }
                    else if (pauseEvent.dontUnpauseList != null)
                    {
                        unpauseObjects(pauseEvent.dontUnpauseList);
                    }
                    else
                        unpauseObjects();

                    systemPaused = false;

                    break;
                }
        }

    }

    public void pauseSystem(PauseGameEvent _pauseEvent)
    {
        if (systemPaused)
            return;

        if (_pauseEvent.dontPause != null)
        {
            pauseObjects(_pauseEvent.dontPause, true);
        }
        else if (_pauseEvent.dontPauseList != null)
        {
            pauseObjects(_pauseEvent.dontPauseList, true);
        }
        else
            pauseObjects(true);

        systemPaused = true;
    }

    public static void pauseObjects(bool systemPause = false)
    {

        foreach (Pausable pausableObj in instance.pausableObjects)
        {
            pausableObj.pause(systemPause);
        }
    }

    public static void pauseObjects(Pausable _dontPause, bool systemPause = false)
    {
        bool foundObj = false;

        foreach (Pausable pausableObj in instance.pausableObjects)
        {
            if (!foundObj && pausableObj == _dontPause)
            {
                foundObj = true;

                continue;
            }

            pausableObj.pause(systemPause);
        }
    }

    public static void pauseObjects(List<Pausable> _dontPause, bool systemPause = false)
    {

        foreach (Pausable pausableObj in instance.pausableObjects)
        {
            if (_dontPause.Contains(pausableObj))
            {
                _dontPause.Remove(pausableObj);

                continue;
            }

            pausableObj.pause(systemPause);
        }
    }

    public static void unpauseObjects()
    {

        foreach (Pausable pausableObj in instance.pausableObjects)
        {
            pausableObj.unpause();
        }
    }

    public static void unpauseObjects(Pausable _dontUnpause)
    {
        bool foundObj = false;

        foreach (Pausable pausableObj in instance.pausableObjects)
        {
            if (!foundObj && pausableObj == _dontUnpause)
            {
                foundObj = true;

                continue;
            }

            pausableObj.unpause();
        }
    }

    public static void unpauseObjects(List<Pausable> _dontUnpause)
    {
        foreach (Pausable pausableObj in instance.pausableObjects)
        {

            if (_dontUnpause.Contains(pausableObj))
            {
                _dontUnpause.Remove(pausableObj);

                continue;
            }

            pausableObj.unpause();
        }
    }

    public static void addObject(Pausable _obj)
    {
        if (instance == null)
            return;

        if (instance.pausableObjects.Contains(_obj))
            return;
        instance.pausableObjects.Add(_obj);
    }

    public static void removeObject(Pausable _obj)
    {
        instance.pausableObjects.Remove(_obj);
    }
}
