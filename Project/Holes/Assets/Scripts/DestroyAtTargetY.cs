using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTargetY : MonoBehaviour {

	public float TargetYToDestroyAt = -10f;
	void Update () 
	{ 
		if (transform.position.y < TargetYToDestroyAt) 
		{
			print(this.name + " is destroying " + gameObject.name);
			Destroy(gameObject); 
		} 
	}
}

