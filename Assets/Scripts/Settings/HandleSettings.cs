using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.ResolutionOption;
using static UnityEngine.UI.Dropdown;

public class HandleSettings : MonoBehaviour
{
    /**
     * KNOWN ISSUES:
     * - Too many Resolutions - Dropdown shows every Resolution with the different amount of targetFrameRate, but fps is set with another option...
     * - Wrong chosen Resolution - The default chosen Resolution seems to be the Screen Resolution. 
     */
    public ISettingsOption type;

    public static DataStorage Data;
    public enum ISettingsOption
    {
        None,
        Framelimit,
        Fullscreen,
        Resolution,
        Volume,
        Vsync,
    }

    private int _currentResolutionIndex = 0;
    private bool _fullScreen = true;

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
                _fullScreen = Screen.fullScreen;
                toggle.isOn = _fullScreen;
                toggle.onValueChanged.AddListener(ValueChange);
                break;
            case ISettingsOption.Resolution:
                if (dropdown == null) break;
                if (dropdown.options == null || dropdown.options.Count == 0)
                    SetResolutionOptionData(dropdown);
                dropdown.value = _currentResolutionIndex;
                dropdown.onValueChanged.AddListener(ValueChange);
                break;
        }
    }


    private void SetResolutionOptionData(Dropdown dropdown)
    {
        dropdown.options = new List<OptionData>();
        _currentResolutionIndex = Screen.resolutions.Length - 1;
        Resolution resolution = Screen.currentResolution;
        Resolution[] options = Screen.resolutions;
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            string optionText = options[i].width + "x" + options[i].height;
            if (resolution.width == options[i].width && resolution.height == options[i].height)
                _currentResolutionIndex = i;
            dropdown.options.Add(new OptionData(optionText));
        }

    }

    private void _SaveSetting()
    {
        if (!Data) return;
        Data.SaveSettings();
    }

    public void ValueChange(bool b)
    {
        switch (type)
        {
            case ISettingsOption.Vsync:
                QualitySettings.vSyncCount = b ? 1 : 0;
                break;
            case ISettingsOption.Fullscreen:
                Resolution res = Screen.currentResolution;
                _fullScreen = b;
                FullScreenMode mode = _fullScreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
                Screen.SetResolution(res.width, res.height, mode);
                break;
        }
        _SaveSetting();
    }

    public void ValueChange(float f)
    {
        switch (type)
        {
            case ISettingsOption.Volume:
                AudioListener.volume = f;
                break;
        }
        _SaveSetting();
    }

    public void ValueChange(int i)
    {
        switch (type)
        {
            case ISettingsOption.Framelimit:
                Application.targetFrameRate = i;
                break;
            case ISettingsOption.Resolution:
                _currentResolutionIndex = i;
                Resolution res = Screen.resolutions[_currentResolutionIndex];
                FullScreenMode mode = Screen.fullScreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
                Screen.SetResolution(res.width, res.height, mode);
                break;
        }
        _SaveSetting();
    }
    public void ValueChange(InputField inputField)
    {
        switch (type)
        {
            case ISettingsOption.Framelimit:
                int frameRate;
                if (int.TryParse(inputField.text, out frameRate))
                    Application.targetFrameRate = frameRate;
                break;
        }
        _SaveSetting();
    }
    public void ValueChange(Toggle toggle)
    {
        ValueChange(toggle.isOn);
        _SaveSetting();
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
        _SaveSetting();
    }
}
