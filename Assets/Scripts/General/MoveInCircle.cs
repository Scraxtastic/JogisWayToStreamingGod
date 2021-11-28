using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    public float Speed = 0;
    public float xDistance = 1, yDistance = 1;
    public bool ShallCalculateAngle = true;

    public float Angle { get; set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (ShallCalculateAngle)
            Angle = -GetAngle(transform.position) + 90;
    }

    // Update is called once per frame
    void Update()
    {
        Angle += Speed * Time.deltaTime;
        float radAngle = Mathf.Deg2Rad * Angle;
        float mx = (float)(xDistance * Mathf.Cos(radAngle));
        float my = (float)(yDistance * Mathf.Sin(radAngle));
        transform.position = new Vector3(mx, my, 0);
    }
    private float GetAngle(Vector2 p_vector2)
    {
        if (p_vector2.x < 0)
        {
            return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
        }
    }
}
