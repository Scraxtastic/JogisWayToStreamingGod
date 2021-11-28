using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterSceneAfterTime : MonoBehaviour
{
    public string SceneName = "";
    public float TimeToWait = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > TimeToWait)
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
