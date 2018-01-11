using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
	NONE = -1,
    PLAYER_HIT,
    MEME_TRASHED,
    MEME_FALL,
    GAME_OVER
}

public class Event
{
    public EventType type;

	public Event(EventType type)
	{
		this.type = type;
	}

}