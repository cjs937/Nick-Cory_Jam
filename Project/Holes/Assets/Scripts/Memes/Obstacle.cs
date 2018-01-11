using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Meme
{
    public override bool onCatch(MemeCatcher _catcher)
    {
        base.onCatch(_catcher);

        EventSystem.dispatchEvent(new Event(EventType.PLAYER_HIT));

        Destroy(gameObject);

        return false;
    }
}
