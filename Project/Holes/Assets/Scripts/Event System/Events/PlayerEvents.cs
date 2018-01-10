using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public class PlayerHit : Event
    {
        public float damage;

        public PlayerHit(float _damage, bool wasDark):base(wasDark ? EventType.PLAYER_HIT_DARK : EventType.PLAYER_HIT_LIGHT)
        {
            damage = _damage;
        }
    }

    public class KnockBackPlayer : Event
    {
        public KnockBackType type;
       // public Vector2 force;
        public Vector2 position;

        public KnockBackPlayer(KnockBackType _type, Vector3 _position):base(EventType.KNOCKBACK_PLAYER)
        {
            type = _type;
            position = _position;

            //SEND KNOCKBACK TYPE & DIRECTION INSTEAD
            //LET PLAYER HANDLE CALCULATIONS


            //Vector2 direction = (GameManager.instance.player.transform.position - _position);
            ////Vector2 force = new Vector2(_force.x * direction.x, _force.y);

            //float sign = Mathf.Sign(Vector2.Dot(Vector2.right, direction));
            //force = new Vector2(_force.x * sign, _force.y);

            //force = Utility.mutliplyVectors(_force, direction);
        }

        //public KnockBackPlayer(Vector3 _position):base(EventType.KNOCKBACK_PLAYER)
        //{
        //    Vector2 direction = ( GameManager.instance.player.transform.position - _position ).normalized;
        //    force = GameManager.instance.player.calcKnockbackForce(direction, _position);
        //}
    }

    //public class PlayerHealthZero : Event
    //{
    //    public PlayerHealthZero() : base(EventType.PLAYER_HEALTH_0)
    //    {}
    //}

}
