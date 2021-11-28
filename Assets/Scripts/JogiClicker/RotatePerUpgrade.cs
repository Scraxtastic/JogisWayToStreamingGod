using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePerUpgrade : MonoBehaviour
{
    public float RotationPerUpdate = 5;
    private SpriteRenderer _spriteRenderer;
    private bool ShallFlip = false;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + RotationPerUpdate * Time.deltaTime);
        if (ShallFlip)
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    private void OnMouseDown()
    {
        ShallFlip = !ShallFlip;
    }
}
