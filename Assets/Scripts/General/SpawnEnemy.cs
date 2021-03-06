using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject ToSpawnObject;
    public float SecondsBetweenSpawn = 5;
    public bool SpawnAtStart = true;
    public float InitialHealth = 1;
    public int MaxSpawn = -1;

    private float LastSpawnTime = 0;
    private int SpawnedCount = 0;

    // Start is called before the first frame update
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
        if(MaxSpawn >= 0 && SpawnedCount > MaxSpawn)
        {
            Destroy(this);
        }
        if (LastSpawnTime + SecondsBetweenSpawn < Time.time)
        {
            var x = Instantiate(ToSpawnObject);
            x.transform.position = transform.position;
            Rigidbody2D rigidbody2D = x.GetComponent<Rigidbody2D>();
            rigidbody2D.angularVelocity = Random.Range(-500, 500);
            HealthSystem healthSystem = x.GetComponent<HealthSystem>();
            if (healthSystem)
                healthSystem.initialHealth = InitialHealth + InitialHealth * SpawnedCount * 0.01f;
            SpawnedCount++;
            LastSpawnTime = Time.time;
        }
    }
}
