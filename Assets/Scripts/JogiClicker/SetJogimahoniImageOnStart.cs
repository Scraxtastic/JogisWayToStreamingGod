using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetJogimahoniImageOnStart : MonoBehaviour
{
    public Sprite[] ImageSprite;
    // Start is called before the first frame update
    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        if (images != null && images[1] != null)
        {
            images[1].sprite = ImageSprite[Random.Range(0, ImageSprite.Length)];
        }
    }
}
