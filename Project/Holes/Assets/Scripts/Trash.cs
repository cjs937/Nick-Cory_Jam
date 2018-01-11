using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trash : MonoBehaviour
{
    public MemeCatcher player;
    public AudioClip trashSound;
    public int trashedCount;

    AudioSource audioSource;
    bool playerInRange = false;

	public ScoreKeeperScript Score;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = trashSound;

        trashedCount = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerInRange && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(player.throwAwayTop())
			{
                audioSource.Play();

                trashedCount++;
				Score.IncrementScore();  //can add a float in the argument for a custom val
			}
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!playerInRange && collision.gameObject == player.gameObject)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerInRange && collision.gameObject == player.gameObject)
        {
            playerInRange = false;
        }
    }

}
