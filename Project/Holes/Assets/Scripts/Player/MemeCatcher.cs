using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeCatcher : MonoBehaviour
{
    //position where caught memes will go
    public Transform carryPosition;

    BoxCollider2D hitBox;

    //Distance above player that memes increment by
    public float carryOffset;

    private void Start()
    {
        hitBox = GetComponent<BoxCollider2D>();

        carryPosition.position = new Vector2(transform.position.x, hitBox.bounds.max.y + carryOffset);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Meme caughtMeme = other.GetComponent<Meme>();

        if (caughtMeme == null)
            return;

        catchMeme(caughtMeme);
    }

    void catchMeme(Meme _caughtMeme)
    {
        _caughtMeme.onCatch(this);

        _caughtMeme.transform.position = carryPosition.position;

        _caughtMeme.transform.rotation = Quaternion.Euler(Vector3.zero);

        _caughtMeme.transform.parent = transform;

        //increment carry position
        carryPosition.position = new Vector2(transform.position.x, carryPosition.position.y + carryOffset);
    }
}
