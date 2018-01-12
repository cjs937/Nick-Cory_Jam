using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meme : MonoBehaviour
{
    public string spriteFolderPath;

    [HideInInspector]
    public BoxCollider2D hitBox;

    public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitBox = GetComponent<BoxCollider2D>();

        loadRandomSprite();
	}
	
    void loadRandomSprite()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteFolderPath);

        if (sprites.Length == 0)
            return;

        int randSpriteIndex = Random.Range(0, sprites.Length - 1);

        spriteRenderer.sprite = sprites[randSpriteIndex];
    }

    public virtual bool onCatch(MemeCatcher _catcher)
    {
        if (_catcher.heldMemes.Count >= _catcher.memeLimit)
            return true;

        ProjectileMover mover = GetComponent<ProjectileMover>();

        if(mover != null)
        {
            Destroy(mover);
        }

        return true;
    }
}
