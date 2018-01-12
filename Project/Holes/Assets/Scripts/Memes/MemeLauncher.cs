using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeLauncher : MonoBehaviour
{
    public bool dewit;

    public float difficultyIncreaseDelay;
    public int maxDifficulty;

    public float fireRate;
    public float fireSpeed;
    public float projectileGravity;

    public GameObject memePrefab;
    public GameObject obstaclePrefab;

    public int difficultyLevel = 1;

    BoxCollider2D hitBox;
    string difficultyDelayTag = "diffDelay";
    string launchTimerTag = "launch";
    Timer timer;
    

    void Start ()
    {

        hitBox = GetComponent<BoxCollider2D>();
        timer = new Timer();

        timer.startTimer(launchTimerTag, fireRate);
        timer.startTimer(difficultyDelayTag, difficultyIncreaseDelay);
	}
	
	void Update ()
    {
        timer.update(Time.deltaTime);

        //if firerate delay is up
        if(timer.checkIfCompleted(launchTimerTag))
        {
            fire();

            //start next delay
            timer.startTimer(launchTimerTag, fireRate);
        }

        //increment difficulty
        if(difficultyLevel < maxDifficulty && timer.checkIfCompleted(difficultyDelayTag))
        {
            ++difficultyLevel;

            if(difficultyLevel != maxDifficulty)
            {
                timer.startTimer(difficultyDelayTag, difficultyIncreaseDelay);
            }
        }
	}

    void fire()
    {
        int obstacleCheck = Random.Range(1, 11);

        Debug.Log(obstacleCheck);

        if(obstacleCheck <= difficultyLevel)
            fireObstacle();
        else
            fireMeme();
    }

    void fireMeme()
    {
        Vector2 firePos = getPointAlongHitbox();//new Vector2(transform.position.x, getPointAlongHitbox().y);

        GameObject newMeme = Instantiate(memePrefab, transform.parent);

        newMeme.transform.rotation = transform.rotation;

        ProjectileMover newMover = newMeme.AddComponent<ProjectileMover>();

        float angleOfElevation = transform.rotation.eulerAngles.z;

        newMover.init(firePos, fireSpeed, projectileGravity, angleOfElevation);
    }

    void fireObstacle()
    {
        Vector2 firePos = getPointAlongHitbox();//new Vector2(transform.position.x, getPointAlongHitbox().y);

        GameObject newMeme = Instantiate(obstaclePrefab, transform.parent);

        newMeme.transform.rotation = transform.rotation;

        ProjectileMover newMover = newMeme.AddComponent<ProjectileMover>();

        float angleOfElevation = transform.rotation.eulerAngles.z;

        newMover.init(firePos, fireSpeed, projectileGravity, angleOfElevation);
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

        //randT = .1f;

        return A + (B - A) * randT;
    }
}
