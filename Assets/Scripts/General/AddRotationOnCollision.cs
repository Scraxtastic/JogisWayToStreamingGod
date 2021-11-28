using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRotationOnCollision : MonoBehaviour
{
    public float RotationToAdd = 1;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody.angularVelocity += RotationToAdd;
    }
}
