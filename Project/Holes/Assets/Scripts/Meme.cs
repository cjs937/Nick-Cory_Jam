﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meme : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onCatch(MemeCatcher _catcher)
    {
        ProjectileMover mover = GetComponent<ProjectileMover>();

        if(mover != null)
        {
            Destroy(mover);
        }
    }
}