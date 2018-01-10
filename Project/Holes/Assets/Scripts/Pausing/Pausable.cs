using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausable : MonoBehaviour
{
    public bool addToPauseSystem = true;
    public bool systemPaused = false;
    public bool localPause = false;
    
    public bool paused
    {
        get
        {
            if (systemPaused || localPause)
                return true;

            return false;
        }
        set
        {
            localPause = value;
        }
    }

    //protected virtual void Awake()
    //{
    //    if (!addToPauseSystem)
    //        return;

    //    if (PauseSystem.instance == null)
    //        return;

    //    PauseSystem.addObject(this);
    //}

    protected virtual void Start()
    {
        if (!addToPauseSystem)
            return;

        PauseSystem.addObject(this);
    }

    //protected virtual void Update ()
    //   {
    //       if (paused)
    //           return;
    //}

    public virtual void pause(bool systemPause = false)
    {
        if (systemPause)
            systemPaused = true;
        else
            paused = true;
    }

    public virtual void unpause()
    {
        if (systemPaused)
            systemPaused = false;
        else
            paused = false;
    }

    public virtual bool isPaused()
    {
        return paused;
    }

    protected virtual void OnDestroy()
    {
        if(addToPauseSystem)
            PauseSystem.removeObject(this);
    }
}
