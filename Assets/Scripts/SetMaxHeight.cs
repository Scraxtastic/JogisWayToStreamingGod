using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxHeight : MonoBehaviour
{
    public float MaxHeight = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.localPosition;
        if(position.y > MaxHeight)
        {
            transform.localPosition = new Vector3(position.x, MaxHeight, position.z);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
}
