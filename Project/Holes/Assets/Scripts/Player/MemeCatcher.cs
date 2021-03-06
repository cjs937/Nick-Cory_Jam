﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeCatcher : MonoBehaviour, IListener
{
    public int memeLimit;

    //position where caught memes will go
    public Transform carryPosition;

    public Stack<Meme> heldMemes;
    BoxCollider2D hitBox;

    //Distance above player that memes increment by
    public float carryOffset;

    public void handleEvent(Event _event)
    {
        if(_event.type == EventType.PLAYER_HIT)
        {
            dropAllMemes();
        }
    }


    private void Start()
    {
        heldMemes = new Stack<Meme>();

        hitBox = GetComponent<BoxCollider2D>();

        updateCarryPosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Meme caughtMeme = other.GetComponent<Meme>();

        if (caughtMeme == null)
            return;

        catchMeme(caughtMeme);
    }

    //throw away meme on top
    public bool throwAwayTop()
    {
        if (heldMemes.Count == 0)
            return false;

        Destroy(heldMemes.Peek().gameObject);

        heldMemes.Pop();

        updateCarryPosition();

        return true;
    }

    void catchMeme(Meme _caughtMeme)
    {
        if (heldMemes.Contains(_caughtMeme))
            return;

        //onCatch will return false if meme is an obstacle
        if (_caughtMeme.onCatch(this))
        {
            if (heldMemes.Count >= memeLimit)
                return;

            _caughtMeme.transform.position = carryPosition.position;

            _caughtMeme.transform.rotation = Quaternion.Euler(Vector3.zero);

            _caughtMeme.transform.parent = transform;

            if(heldMemes.Count > 0)
                _caughtMeme.spriteRenderer.sortingOrder = heldMemes.Peek().spriteRenderer.sortingOrder + 1;

            heldMemes.Push(_caughtMeme);

            updateCarryPosition();
        }
        else
        {
            AudioSystem.playLocalAudio(AudioType.PLAYER_HIT, transform.position, 100);

            dropAllMemes();
        }
    }

    void updateCarryPosition()
    {
        float newCarryY;

        if (heldMemes.Count == 0)
        {
            newCarryY = hitBox.bounds.max.y + carryOffset;
        }
        else
        {
            newCarryY = heldMemes.Peek().hitBox.bounds.max.y + carryOffset;
        }

        carryPosition.position = new Vector2(transform.position.x, newCarryY);
    }

    void dropAllMemes()
    {
        while(heldMemes.Count > 0)
        {
            Meme droppedMemeScript = heldMemes.Pop();
            GameObject memeObject = droppedMemeScript.gameObject;

            Destroy(droppedMemeScript);

            Rigidbody2D newRB = memeObject.AddComponent<Rigidbody2D>();

            memeObject.transform.SetParent(null);
        }

        updateCarryPosition();
    }
}
