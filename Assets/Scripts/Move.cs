using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 0.01f;
    public float leftBoundary = -5;
    public float rightBoundary = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        float x = transform.position.x;
        if (x < leftBoundary || x > rightBoundary)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }

    }
}
