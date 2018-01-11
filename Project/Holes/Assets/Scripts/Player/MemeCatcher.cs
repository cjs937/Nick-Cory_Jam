using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeCatcher : MonoBehaviour
{
    //position where caught memes will go
    public Transform carryPosition;

    Stack<Meme> heldMemes;
    BoxCollider2D hitBox;

    //Distance above player that memes increment by
    public float carryOffset;

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
    public void throwAwayTop()
    {
        if (heldMemes.Count == 0)
            return;

        Destroy(heldMemes.Peek().gameObject);

        heldMemes.Pop();

        updateCarryPosition();
    }

    void catchMeme(Meme _caughtMeme)
    {
        if (heldMemes.Contains(_caughtMeme))
            return;

        _caughtMeme.onCatch(this);

        _caughtMeme.transform.position = carryPosition.position;

        _caughtMeme.transform.rotation = Quaternion.Euler(Vector3.zero);

        _caughtMeme.transform.parent = transform;

        heldMemes.Push(_caughtMeme);

        updateCarryPosition();
    }

    void updateCarryPosition()
    {
        float newCarryY;

        if (heldMemes.Count == 0)
        {
            newCarryY = transform.position.y + carryOffset;
        }
        else
        {
            newCarryY = heldMemes.Peek().transform.position.y + carryOffset;
        }

        carryPosition.position = new Vector2(transform.position.x, newCarryY);
    }
}
