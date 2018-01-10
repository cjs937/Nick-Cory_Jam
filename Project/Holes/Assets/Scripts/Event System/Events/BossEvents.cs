using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitEvent : Event
{
    public float damageDealt;

    public BossHitEvent(float _damage): base(EventType.BOSS_HIT)
    {
        damageDealt = _damage;
    }
}

public class InitBossEvent : Event
{
    public Boss boss;

    public InitBossEvent(Boss _boss) : base(EventType.INIT_BOSS)
    {
        boss = _boss;
    }
}

