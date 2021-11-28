using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class SetStartSpeed : MonoBehaviour
{
    public Vector2 StartSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = StartSpeed;
    }
}
