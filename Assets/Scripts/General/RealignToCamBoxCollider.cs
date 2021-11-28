using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealignToCamBoxCollider : MonoBehaviour
{
    public Camera Camera;



    BoxCollider2D oldCamBoxCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            print("For loop: " + transform.GetChild(i));
            Vector3 currentPos = transform.position;
            transform.position = new Vector3(cam.transform.position.x + width / 2, currentPos.y, currentPos.z);
        }
    }
}
