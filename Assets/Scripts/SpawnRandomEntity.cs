using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEntity : MonoBehaviour
{
    public List<GameObject> ToSpawnObject;
    public float SecondsBetweenSpawn = 5;
    public bool SpawnAtStart = true;
    public int MaxSpawn = -1;
    public float AngularVelocity = 0;
    public bool RandomizeAngularVelocity = false;

    private float LastSpawnTime = 0;
    private int SpawnedCount = 0;

    void Start()
    {
        if (SpawnAtStart)
        {
            LastSpawnTime = -SecondsBetweenSpawn;
            SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        if (MaxSpawn >= 0 && SpawnedCount > MaxSpawn)
        {
            Destroy(this);
        }
        if (LastSpawnTime + SecondsBetweenSpawn < Time.time)
        {
            var x = Instantiate(ToSpawnObject[Random.Range(0, ToSpawnObject.Count)]);
            x.transform.position = transform.position;
            Rigidbody2D rigidbody2D = x.GetComponent<Rigidbody2D>();
            if (RandomizeAngularVelocity)
                rigidbody2D.angularVelocity = Random.Range(-500, 500);
            else
                rigidbody2D.angularVelocity = AngularVelocity;
            SpawnedCount++;
            LastSpawnTime = Time.time;
        }
    }
}
