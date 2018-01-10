using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    
    //Projectile arc data
    Vector2 initPosition;
    float gravity;
    float angle;
    float initSpeed;
    float initHeight;
    float currentT;

    bool initialized = false;

    public void init(Vector2 _initPosition, float _initSpeed, float _gravity, float _angle)
    {
        initPosition = transform.position = _initPosition;
        gravity = _gravity;
        angle = _angle;
        initSpeed = _initSpeed;
        initHeight = _initPosition.y;

        currentT = 0;
        initialized = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!initialized)
            return;

        transform.position = getProjectilePosition();
	}

    //2D projectile equation. Just trust me on this one
    Vector2 getProjectilePosition()
    {
        Vector2 newPos = initPosition;

        float t = currentT;

        newPos.x += (initSpeed * Mathf.Cos(angle)) * t;

        newPos.y += initHeight + (initSpeed * Mathf.Sin(angle) * t) - 0.5f * gravity * (t * t);

        currentT = getNextT();

        return newPos;
    }

    float getNextT()
    {
        return currentT + .1f;// Time.deltaTime;
    }
}
