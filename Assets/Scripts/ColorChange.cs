using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (SpriteRenderer))]
public class ColorChange : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(RandomNumber(0, 255)/255, RandomNumber(0, 255) / 255, RandomNumber(0, 255) / 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float RandomNumber(int lower, int higher)
    {
        return (float)Random.Range(lower, higher);
    }
}
