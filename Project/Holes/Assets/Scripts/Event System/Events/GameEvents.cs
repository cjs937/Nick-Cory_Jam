using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewRoomEvent : Event
{
    public Room room;

    public LoadNewRoomEvent(Room _newRoom):base(EventType.LOAD_NEW_ROOM)
    {
        room = _newRoom;
    }
}

public class PauseGameEvent : Event
{
    public Pausable dontPause = null;
    public List<Pausable> dontPauseList = null;

    public PauseGameEvent(): base(EventType.PAUSE)
    {}

    public PauseGameEvent(Pausable _dontPause) : base(EventType.PAUSE)
    {
        dontPause = _dontPause;
    }

    public PauseGameEvent(List<Pausable> _dontPause) : base(EventType.PAUSE)
    {
        dontPauseList = _dontPause;
    }
}

public class UnpauseGameEvent : Event
{
    public Pausable dontUnpause = null;
    public List<Pausable> dontUnpauseList = null;

    public UnpauseGameEvent(): base(EventType.RESUME)
    { }

    public UnpauseGameEvent(Pausable _dontPause) : base(EventType.RESUME)
    {
        dontUnpause = _dontPause;
    }

    public UnpauseGameEvent(List<Pausable> _dontPause) : base(EventType.RESUME)
    {
        dontUnpauseList = _dontPause;
    }
}

