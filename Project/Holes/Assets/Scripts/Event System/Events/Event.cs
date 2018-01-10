using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
	NONE = -1
}

public class Event
{
    public EventType type;

	public Event(EventType type)
	{
		this.type = type;
	}

}