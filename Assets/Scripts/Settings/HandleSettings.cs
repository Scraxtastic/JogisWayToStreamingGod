using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.ResolutionOption;
using static UnityEngine.UI.Dropdown;

public class HandleSettings : MonoBehaviour
{
    public ISettingsOption type;

    public enum ISettingsOption
    {
        None,
        Framelimit,
        Fullscreen,
        Resolution,
        Volume,
        Vsync,
    }

    // Start is called before the first frame update
    void Start()
    {
        Slider slider = GetComponent<Slider>();
        Toggle toggle = GetComponent<Toggle>();
        InputField inputField = GetComponent<InputField>();
        Dropdown dropdown = GetComponent<Dropdown>();
        switch (type)
        {
            case ISettingsOption.Volume:
                if (slider == null) break;
                slider.value = AudioListener.volume;
                slider.onValueChanged.AddListener(ValueChange);
                break;
            case ISettingsOption.Framelimit:
                if (inputField == null) break;
                inputField.text = Application.targetFrameRate + "";
                inputField.onValueChanged.AddListener(ValueChange);
                break;
            case ISettingsOption.Vsync:
                if (toggle == null) break;
                toggle.isOn = QualitySettings.vSyncCount > 0;
                toggle.onValueChanged.AddListener(ValueChange);
                break;
            case ISettingsOption.Fullscreen:
                if (toggle == null) break;
                toggle.isOn = Screen.fullScreen;
                toggle.onValueChanged.AddListener(ValueChange);
                break;
            case ISettingsOption.Resolution:
                if (dropdown == null) break;
                SetResolutionOptionData(dropdown);
                dropdown.onValueChanged.AddListener(ValueChange);
                break;
        }
    }


    private void SetResolutionOptionData(Dropdown dropdown)
    {
        Debug.Log(Screen.currentResolution.width + "" + Screen.currentResolution.height);
        dropdown.options = new List<OptionData>();
        foreach (Resolution option in Screen.resolutions)
        {
            string optionText = option.width + "x" + option.height;
            dropdown.options.Add(new OptionData(optionText));
        }
    }

    public void ValueChange(bool b)
    {
        switch (type)
        {
            case ISettingsOption.Vsync:
                Debug.Log("Vsync" + b);
                QualitySettings.vSyncCount = b ? 1 : 0;
                break;
            case ISettingsOption.Fullscreen:
                Screen.SetResolution(640, 480, FullScreenMode.Windowed, 60);
                Debug.Log("Changed " + b);
                break;
        }
    }

    public void ValueChange(float f)
    {
        switch (type)
        {
            case ISettingsOption.Volume:
                AudioListener.volume = f;
                break;
        }
    }

    public void ValueChange(int i)
    {
        switch (type)
        {
            case ISettingsOption.Framelimit:
                Application.targetFrameRate = i;
                break;
            case ISettingsOption.Resolution:
                Debug.Log(i);
                break;
        }
    }
    public void ValueChange(InputField inputField)
    {
        Debug.Log("inpufield" + inputField.text);
        switch (type)
        {
            case ISettingsOption.Framelimit:
                int frameRate;
                if (int.TryParse(inputField.text, out frameRate))
                    Application.targetFrameRate = frameRate;
                break;
        }
    }
    public void ValueChange(Toggle toggle)
    {
        Debug.Log("toggle: " + toggle.isOn);
        ValueChange(toggle.isOn);
    }

    public void ValueChange(string s)
    {
        switch (type)
        {
            case ISettingsOption.Framelimit:
                int parsedNumber;
                if (int.TryParse(s, out parsedNumber))
                {
                    ValueChange(parsedNumber);
                }
                else
                {
                    Debug.LogError("parsing failed" + s);
                }
                break;
        }
    }
}
