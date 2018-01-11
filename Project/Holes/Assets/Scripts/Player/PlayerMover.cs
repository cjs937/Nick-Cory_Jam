using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //Speed when player isn't carrying any memes
    public float baseSpeed;

    //Clamps player to screen
    public Vector2[] clampPositions = new Vector2[2] { Vector2.zero, Vector2.zero };

    //% cut in speed when player cathces meme
    public float speedDecreasePercent;

    float currentSpeed;
    Rigidbody2D physics = null;

    BoxCollider2D hitBox = null;

    private void OnDrawGizmosSelected()
    {
        Vector3 cubeSize = new Vector3(1, 1, 1);

        Gizmos.DrawCube((Vector3)clampPositions[0], cubeSize);

        Gizmos.DrawCube((Vector3)clampPositions[1], cubeSize);
    }

    // Use this for initialization
    void Start ()
    {
        physics = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
        currentSpeed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKey(KeyCode.Mouse0) && Utility.checkInBounds(Utility.getMousePosition(), hitBox))
        //{
            lerpToMouse();
            //snapToMouse();
        //}
	}

    void snapToMouse()
    {
        transform.position = new Vector2(Utility.getMousePosition().x, transform.position.y);
    }

    void lerpToMouse()
    {
        Vector2 mousePos = Utility.getMousePosition();

        float newX = transform.position.x;

        newX = Mathf.Lerp(newX, mousePos.x, currentSpeed * Time.deltaTime * Time.deltaTime);

        newX = Mathf.Clamp(newX, clampPositions[0].x, clampPositions[1].x);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
