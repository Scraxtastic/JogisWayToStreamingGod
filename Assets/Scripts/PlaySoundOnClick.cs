using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnClick : MonoBehaviour
{
    private AudioSource _clickSound;
    // Start is called before the first frame update
    void Start()
    {
        _clickSound = GetComponent<AudioSource>();
        Button button = GetComponent<Button>();
        if (button) button.onClick.AddListener(OnMouseDown);
    }
    private void OnMouseDown()
    {
        if (_clickSound == null) return;
        _clickSound.Play();
    }
}
