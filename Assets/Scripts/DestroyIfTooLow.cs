using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfTooLow : MonoBehaviour
{
    public float lowestAcceptablePosition = -50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < lowestAcceptablePosition)
        {
            Destroy(gameObject);
        }
    }
}
