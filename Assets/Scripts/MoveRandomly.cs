using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRandomly : MonoBehaviour
{
    public Vector2 TopLeftPoint;
    public Vector2 BottomRightPoint;
    public float StartSpeed = 10;
    public float MaxSpeed = 100;
    public float HoldTime = 5;

    private Rigidbody2D _rigidbody;
    private bool _firstCollision = true;
    private float _waitStartTime;
    // Start is called before the first frame update
    void Start()
    {
        _waitStartTime = -HoldTime;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(StartSpeed, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_firstCollision && HoldButton())
            return;

        Vector2 pos = transform.position;
        Vector2 vel = _rigidbody.velocity;
        if (TopLeftPoint.x > pos.x)
        {
            _rigidbody.velocity = new Vector2(Mathf.Abs(vel.x), vel.y);
            CollidesWall();
        }
        if (BottomRightPoint.x < pos.x)
        {
            _rigidbody.velocity = new Vector2(-Mathf.Abs(vel.x), vel.y);
            CollidesWall();
        }
        if (TopLeftPoint.y < pos.y)
        {
            _rigidbody.velocity = new Vector2(vel.x, -Mathf.Abs(vel.y));
            CollidesWall();
        }
        if (BottomRightPoint.y > pos.y)
        {
            _rigidbody.velocity = new Vector2(vel.x, Mathf.Abs(vel.y));
            CollidesWall();
        }
    }

    private bool HoldButton()
    {
        Vector2 pos = transform.position;
        if (pos.x >= 0 && _waitStartTime == -HoldTime)
        {
            _waitStartTime = Time.time;
        }
        if (Time.time < _waitStartTime + HoldTime)
        {
            _rigidbody.velocity = new Vector2(0, 0);
            return true;
        }
        _rigidbody.velocity = new Vector2(StartSpeed, 0);
        if (_waitStartTime == -HoldTime)
            return true;
        return false;
    }
    private void CollidesWall()
    {
        if (_firstCollision)
        {
            float xVel = _rigidbody.velocity.x;
            _rigidbody.velocity = new Vector2(xVel, xVel);
            _firstCollision = false;
        }
        _rigidbody.velocity *= 1.2f;
        if (_rigidbody.velocity.magnitude > MaxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * MaxSpeed;
        }
        _rigidbody.angularVelocity -= 1;
    }
}
