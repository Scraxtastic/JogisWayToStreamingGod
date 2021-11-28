using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class LimitSpeed : MonoBehaviour
{
    public float MaxSpeed = 10;
    public float MaxRotationSpeed = 180;

    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_rigidbody.velocity.magnitude > MaxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized* MaxSpeed;
        }
        if(_rigidbody.angularVelocity > MaxRotationSpeed)
        {
            _rigidbody.angularVelocity = MaxRotationSpeed;
        }
        if(_rigidbody.angularVelocity < -MaxRotationSpeed)
        {
            _rigidbody.angularVelocity = -MaxRotationSpeed;
        }
    }
}
