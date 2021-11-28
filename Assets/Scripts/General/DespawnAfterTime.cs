using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterTime : MonoBehaviour
{
    public float DespawnAfterSeconds = 10;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > startTime + DespawnAfterSeconds)
        {
            Destroy(gameObject);
        }
    }
}
