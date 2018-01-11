using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodThing : Meme
{
    public override void onCatch(MemeCatcher _catcher)
    {
        base.onCatch(_catcher);

        EventSystem.dispatchEvent(new Event(EventType.PLAYER_HIT));
    }
}
