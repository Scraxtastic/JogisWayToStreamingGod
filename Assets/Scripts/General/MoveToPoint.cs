using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    public Vector2 DistanceVector;
    public float TimeToReach = 5;
    private Vector3 _velocity;
    private float _startTime;
    private Vector2 _destination;
    // Start is called before the first frame update
    void Start()
    {
        _destination = transform.position;
        _velocity = -(DistanceVector.normalized * (DistanceVector.magnitude / TimeToReach));
        _startTime = Time.time;
        transform.position = new Vector2(_destination.x + DistanceVector.x, _destination.y + DistanceVector.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _velocity * Time.deltaTime;
        if (Time.time > _startTime + TimeToReach)
        {
            transform.position = _destination;
            Destroy(this);
        }
    }
}
