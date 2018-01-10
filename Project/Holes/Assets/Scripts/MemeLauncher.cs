using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeLauncher : MonoBehaviour
{ 
    public float fireRate;
    public GameObject meme;

    BoxCollider2D hitBox;
    string timerTag = "launch";
    Timer launchTimer;
    

    void Start ()
    {

        hitBox = GetComponent<BoxCollider2D>();
        launchTimer = new Timer();

        launchTimer.startTimer(timerTag, fireRate);
	}
	
	void Update ()
    {
        launchTimer.update(Time.deltaTime);

        //if firerate delay is up
        if(launchTimer.checkIfCompleted(timerTag))
        {
            fireMeme();

            //start next delay
            launchTimer.startTimer(timerTag, fireRate);
        }
	}

    void fireMeme()
    {
        Vector2 firePos = getPointAlongHitbox();

        GameObject newMeme = Instantiate(meme, transform.parent);

        newMeme.transform.position = firePos;

        newMeme.transform.rotation = transform.rotation;
    }

    Vector2 getPointAlongHitbox()
    {
        // Ray/Line equation: R(t) = A + (B-A) * t 
        // t = point opon line (between 0 & 1),  A = beginning of line (vector), B = ending of line (vector)

        //Bottom left of hitbox
        Vector2 A = hitBox.bounds.min;

        //Upper left
        Vector2 B = new Vector2(hitBox.bounds.min.x, hitBox.bounds.max.y);

        float randT = Random.Range(0.0f, 1.0f);

        return A + (B - A) * randT;
    }
}
