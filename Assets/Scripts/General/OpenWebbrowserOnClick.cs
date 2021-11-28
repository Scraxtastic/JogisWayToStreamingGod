using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenWebbrowserOnClick : MonoBehaviour
{
    public string WebURL = "";
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button) button.onClick.AddListener(OnMouseDown);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Application.OpenURL(WebURL);
    }
}
