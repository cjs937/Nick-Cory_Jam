using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
	NONE = -1,
    PAUSE,
    RESUME,
    PLAYER_ENTER_ROOM,
    LOAD_NEW_ROOM,
    INIT_ROOM,
    ROOM_INIT_COMPLETE,
    CAMERA_INIT_COMPLETE,
    TRANSITION_COMPLETE,
    INIT_BOSS,
    BOSS_HEALTH_FILLED,
    BEGIN_BOSS_FIGHT,
    BOSS_HEALTH_0,
    BOSS_HEALTH_HALF,
    BOSS_DEATH,
    DAMAGE_DEALT,
    BOSS_HIT,
    PLAYER_HIT_LIGHT,
    PLAYER_HIT_DARK,
    PLAYER_HEALTH_0,
    PLAYER_DEATH,
    KNOCKBACK_PLAYER
}

public class Event
{
    public EventType type;

	public Event(EventType type)
	{
		this.type = type;
	}

}