﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meme : MonoBehaviour
{
    public string spriteFolderPath;

    [HideInInspector]
    public BoxCollider2D hitBox;

    SpriteRenderer spriteRenderer;

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

    public virtual void onCatch(MemeCatcher _catcher)
    {
        ProjectileMover mover = GetComponent<ProjectileMover>();

        if(mover != null)
        {
            Destroy(mover);
        }
    }
}