using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public MemeCatcher player;
    public int trashedCount;

    bool playerInRange = false;

	// Use this for initialization
	void Start ()
    {
        trashedCount = 0;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerInRange && Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.throwAwayTop();
            trashedCount++;
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
