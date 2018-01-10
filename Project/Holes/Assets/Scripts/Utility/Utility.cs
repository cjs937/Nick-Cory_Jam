using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static float DEFAULT_GRAVITY
    {
        get { return -25.0f; }
        private set { }
    }
        

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static float calcJumpForce(float _height, float _length)
    {
        return ((2 * _height) / _length);
    }

    public static float calcJumpGravity(float _height, float _length)
    {
        return (-2 * _height) / (_length * _length);
    }

    public static Vector2 getMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static Vector2 getScreenMin(Camera _camera = null)
    {
        Camera screen;

        if (_camera == null)
            screen = Camera.main;
        else
            screen = _camera;

        return screen.ScreenToWorldPoint(Vector2.zero);
    }

    public static Vector2 getScreenMax(Camera _camera = null)
    {
        Camera screen;

        if (_camera == null)
            screen = Camera.main;
        else
            screen = _camera;

        return screen.ScreenToWorldPoint(new Vector2(screen.pixelWidth, screen.pixelHeight));
    }

    public static Vector2 convertToCameraSpace(Camera _camera, Vector2 _position)
    {
        float x = _camera.transform.position.x + _position.x; //+ (_camera.transform.position.x - _position.x);

        float y = _camera.transform.position.y + _position.y; //+ (_camera.transform.position.y - _position.y);

        return new Vector2(x, y);
    }

    public static bool isOffScreen(Vector2 _position)
    {
        Vector2 screenMin = getScreenMin();
        Vector2 screenMax = getScreenMax();

        if (_position.x < screenMin.x || screenMax.x < _position.x)
        {
            return true;
        }

        if (_position.y < screenMin.y || screenMax.y < _position.y)
        {
            return true;
        }

        return false;
    }

    public static Vector2 mutliplyVectors(Vector2 _vectorA, Vector2 _vectorB)
    {
        return new Vector2(_vectorA.x * _vectorB.x, _vectorA.y * _vectorB.y);
    }
}

public struct Tuple3<A, B, C>
{

    public A first
    {
        get;
        private set;
    }

    public B second
    {
        get;
        private set;
    }

    public C third
    {
        get;
        private set;
    }

    public Tuple3(A first, B second, C third)
    {
        this.first = first;
        this.second = second;
        this.third = third;
    }

}