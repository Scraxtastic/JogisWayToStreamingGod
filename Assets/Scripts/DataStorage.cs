using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    public Text jogicoinText;
    public Text mahonicoinText;


    // VALUES
    public static float jogicoins = 0;
    public static float mahonicoins = 0;

    //




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (jogicoinText)
            jogicoinText.text = $"Jogicoins: {(Mathf.Round(jogicoins*100)/100).ToString()}";
        if (mahonicoinText)
            mahonicoinText.text = $"Mahonicoins: {mahonicoins}";
    }
}
