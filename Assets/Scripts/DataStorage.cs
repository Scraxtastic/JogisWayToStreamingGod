using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    public Text jogicoinText;
    public Text mahonicoinText;
    public GameObject JogiButton;


    // VALUES
    public static float JogiCoins { get; set; } = 0;
    public static float MahoniCoins { get; set; } = 0;
    //
    public static int MahoniCount { get; set; } = 0;
    public static float MahoniSpeed { get; set; } = 1;
    //
    private static bool _abilitiesAreSet = false;
    private static bool _fileLoaded = false;
    private static float _rotationToAdd = 0;
    private double _moneyToAdd;
    private static Ability _attack;
    private static Ability _jogiSize;
    private static Ability _mahonis;
    private static Ability _mahoniSpeed;
    private float _textUpdateTime = 0.1f;
    private float _lastTextUpdate;
    private float _lastSaveTime;
    private float _savePeriod = 5;
    private string _relativePath = "/save.dat";
    private string _relativeSettingsPath = "/settings.dat";
    private FileManager<SaveObject> _saveFileManager;
    private FileManager<SettingsSaveObject> _settingsSaveFileManager;
    public enum PossibleUpgrade
    {
        Attack = 1,
        JogiSize = 2,
        MahoniAmount = 3,
        Mahonispeed = 4,
    }



    private void Awake()
    {
        _saveFileManager = new FileManager<SaveObject>(_relativePath);
        _settingsSaveFileManager = new FileManager<SettingsSaveObject>(_relativeSettingsPath);
        _lastTextUpdate = -_textUpdateTime;
        SetUpgrades();
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _lastTextUpdate + _textUpdateTime)
        {
            if (jogicoinText)
                jogicoinText.text = $"Jogicoins: {Mathf.Round(JogiCoins * 100) / 100}";
            if (mahonicoinText)
                mahonicoinText.text = $"Mahonicoins: {MahoniCoins}";
            _lastTextUpdate = Time.time;
        }
        if (SceneManager.GetActiveScene().name.ToLower() == "maingame")
            UpdateMainGame();
        UpdatePassiveMoneyIncome();
        if (Time.time > _lastSaveTime + _savePeriod)
        {
            _lastSaveTime = Time.time;
            SaveData();
        }
    }

    private void UpdatePassiveMoneyIncome()
    {
        if (_mahonis == null || _mahoniSpeed == null) return;
        _moneyToAdd += _mahonis.Level * _mahoniSpeed.Power * Time.deltaTime;
        if (_moneyToAdd >= 0.1)
        {

            float moneyToAdd = (float)_moneyToAdd;
            JogiCoins += moneyToAdd;
            _moneyToAdd -= moneyToAdd;
        }
    }

    private void UpdateMainGame()
    {
        if (MahoniCount != _mahonis.Level)
            MahoniCount = _mahonis.Level;
        if (MahoniSpeed != _mahoniSpeed.Power)
            MahoniSpeed = _mahoniSpeed.Power;
        SetJogiButtonSize(_jogiSize.Power);
        _moneyToAdd += _rotationToAdd * 10;
        _rotationToAdd += (_mahonis.Level * _mahoniSpeed.Power / 10) * Time.deltaTime;
        RotateJogiButton(_rotationToAdd);

        _rotationToAdd = 0;
    }

    private void SetJogiButtonSize(float size)
    {
        if (JogiButton != null)
            JogiButton.transform.localScale = new Vector3(size, size);
    }

    private void RotateJogiButton(float angle)
    {
        if (JogiButton == null)
            return;
        JogiButton.transform.rotation = Quaternion.Euler(0, 0, JogiButton.transform.rotation.eulerAngles.z - angle);
    }

    public static void AddClickRotationOnJogiButton()
    {
        _rotationToAdd += (_attack.Power / 10);
    }

    static void SetUpgrades()
    {
        if (_abilitiesAreSet) return;
        _attack = new Ability().WithInitialCost(20).WithLevel(1).WithCostMultiplier(1.5f).WithName("Attack").WithCostMultiplierType(Ability.MultiplierTypes.SoftLogarithmic);
        _attack.WithInitialPower(1).WithPowerMultiplier(1.1f).WithPowerMultiplierType(Ability.MultiplierTypes.SoftLogarithmic);
        _jogiSize = new Ability().WithInitialCost(300).WithLevel(1).WithCostMultiplier(1.06f).WithName("Jogi size").WithCostMultiplierType(Ability.MultiplierTypes.SoftLogarithmic);
        _jogiSize.WithInitialPower(1).WithPowerMultiplier(0.02f).WithPowerMultiplierType(Ability.MultiplierTypes.LinearMultiplier);
        _mahonis = new Ability().WithInitialCost(200).WithLevel(0).WithCostMultiplier(1.2f).WithName("Mahoni amount").WithCostMultiplierType(Ability.MultiplierTypes.SoftLogarithmic);
        _mahoniSpeed = new Ability().WithInitialCost(202).WithLevel(1).WithCostMultiplier(1.7f).WithName("Mahoni speed").WithCostMultiplierType(Ability.MultiplierTypes.SoftLogarithmic);
        _mahoniSpeed.WithInitialPower(1).WithPowerMultiplier(1.08f).WithPowerMultiplierType(Ability.MultiplierTypes.SoftLogarithmic);
        _abilitiesAreSet = true;
    }

    public static void Upgrade(PossibleUpgrade abilityToUpgrade)
    {
        switch (abilityToUpgrade)
        {
            case PossibleUpgrade.Attack:
                UpgradeAbility(_attack);
                break;
            case PossibleUpgrade.JogiSize:
                UpgradeAbility(_jogiSize);
                break;
            case PossibleUpgrade.MahoniAmount:
                UpgradeAbility(_mahonis);
                break;
            case PossibleUpgrade.Mahonispeed:
                UpgradeAbility(_mahoniSpeed);
                break;
            default: break;
        }
    }
    private static void UpgradeAbility(Ability upgrade)
    {
        if (upgrade.IsEnoughMoneyToBuy(JogiCoins))
        {
            JogiCoins -= upgrade.Cost;
            upgrade.UpgradeLevel();
        }
    }

    public static string GetUpgradeLevelAsText(PossibleUpgrade abilityToGet)
    {
        return abilityToGet switch
        {
            PossibleUpgrade.Attack => _attack.Level + "",
            PossibleUpgrade.JogiSize => _jogiSize.Level + "",
            PossibleUpgrade.MahoniAmount => _mahonis.Level + "",
            PossibleUpgrade.Mahonispeed => _mahoniSpeed.Level + "",
            _ => "GRRR Level",
        };
    }

    public static string GetUpgradeName(PossibleUpgrade abilityToGet)
    {
        return abilityToGet switch
        {
            PossibleUpgrade.Attack => _attack.Name,
            PossibleUpgrade.JogiSize => _jogiSize.Name,
            PossibleUpgrade.MahoniAmount => _mahonis.Name,
            PossibleUpgrade.Mahonispeed => _mahoniSpeed.Name,
            _ => "GRRR Name",
        };
    }

    public static string GetUpgradeCostAsText(PossibleUpgrade abilityToGet)
    {
        return abilityToGet switch
        {
            PossibleUpgrade.Attack => _attack.GetCostRounded(),
            PossibleUpgrade.JogiSize => _jogiSize.GetCostRounded(),
            PossibleUpgrade.MahoniAmount => _mahonis.GetCostRounded(),
            PossibleUpgrade.Mahonispeed => _mahoniSpeed.GetCostRounded(),
            _ => "GRRR Cost",
        };
    }
    public static float GetUpgradeCost(PossibleUpgrade abilityToGet)
    {
        return abilityToGet switch
        {
            PossibleUpgrade.Attack => _attack.Cost,
            PossibleUpgrade.JogiSize => _jogiSize.Cost,
            PossibleUpgrade.MahoniAmount => _mahonis.Cost,
            PossibleUpgrade.Mahonispeed => _mahoniSpeed.Cost,
            _ => -1,
        };
    }

    public void SaveData()
    {
        Ability[] abilities = new Ability[] { _attack, _jogiSize, _mahonis, _mahoniSpeed };
        SaveObject saveObject = new SaveObject().WithAbilities(abilities).WithJogiCoins(JogiCoins);
        //saveObject.WithVolume(AudioListener.volume);
        _saveFileManager.SaveFile(saveObject);
        SaveSettings();
    }

    public void SaveSettings()
    {
        SettingsSaveObject settingsSaveObject = new SettingsSaveObject();
        settingsSaveObject.withVolume(AudioListener.volume);
        _settingsSaveFileManager.SaveFile(settingsSaveObject);
    }

    public void LoadData()
    {
        if (_fileLoaded) return;
        _fileLoaded = true;
        SaveObject saveObject = _saveFileManager.LoadFile();
        if (saveObject == default(SaveObject))
            return;
        JogiCoins = saveObject.JogiCoins;
        Ability[] abilities = saveObject.Abilities;
        _attack = abilities[0];
        _jogiSize = abilities[1];
        _mahonis = abilities[2];
        _mahoniSpeed = abilities[3];
        LoadSettings();
    }

    public void LoadSettings()
    {
        SettingsSaveObject settingsSaveObject = _settingsSaveFileManager.LoadFile();
        if (settingsSaveObject == default(SettingsSaveObject))
            return;
        AudioListener.volume = settingsSaveObject.Volume;
    }


}
