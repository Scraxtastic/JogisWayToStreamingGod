using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterScene : MonoBehaviour
{
    public string SceneName = "";
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
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
