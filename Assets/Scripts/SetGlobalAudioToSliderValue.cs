using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SetGlobalAudioToSliderValue : MonoBehaviour
{
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        if (_slider != null)
            _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        AudioListener.volume = _slider.value;
    }
}
