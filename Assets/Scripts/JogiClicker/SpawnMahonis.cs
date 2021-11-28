using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMahonis : MonoBehaviour
{
    public GameObject JogiMahoni;
    public Vector2 XRange = new Vector2(4, 7);
    public Vector2 YRange = new Vector2(3, 6);
    public bool XRangeBoth = true;
    public bool YRangeBoth = true;
    public float Speed = 1;
    public float SpeedDifferencePerc = 10;

    private float _lastSpawnedTime = 0;
    private float _minWaitTime = 0.3f;
    private float _lastSpeed;
    private int _amountSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_amountSpawned < DataStorage.MahoniCount && JogiMahoni != null && Time.time > _lastSpawnedTime + _minWaitTime)
        {
            GameObject jogiMahoni = Instantiate(JogiMahoni);
            jogiMahoni.transform.SetParent(transform);
            jogiMahoni.transform.position = new Vector2(-2000, -2000);
            MoveInCircle circularMovement = jogiMahoni.GetComponent<MoveInCircle>();
            float speedDifference = Speed * (SpeedDifferencePerc / 100);
            circularMovement.Speed = -Speed + Random.Range(-speedDifference, speedDifference);
            circularMovement.ShallCalculateAngle = false;
            circularMovement.Angle = Random.Range(0, 360);
            _amountSpawned++;
            _lastSpawnedTime = Time.time;
        }
        if (Speed != DataStorage.MahoniSpeed)
            Speed = DataStorage.MahoniSpeed;

        if (_lastSpeed != Speed)
        {
            MoveInCircle[] circularMovements = GetComponentsInChildren<MoveInCircle>();
            foreach (MoveInCircle circle in circularMovements)
            {
                float speedDifference = Speed * (SpeedDifferencePerc / 100);
                circle.Speed = -Speed + Random.Range(-speedDifference, speedDifference);
            }
            _lastSpeed = Speed;
        }
    }

    private Vector2 GetPosition()
    {
        float x = Random.Range(XRange.x, XRange.y);
        float y = Random.Range(YRange.x, YRange.y);
        if (XRangeBoth)
        {
            x = Mathf.RoundToInt(Random.Range(0, 1)) == 1 ? x : -x;
        }
        if (YRangeBoth)
        {
            y = Mathf.RoundToInt(Random.Range(0, 1)) == 1 ? y : -y;
        }
        return new Vector2(x, y);
    }
}
