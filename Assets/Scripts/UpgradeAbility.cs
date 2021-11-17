using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DataStorage;

public class UpgradeAbility : MonoBehaviour
{
    public PossibleUpgrade UpgradeName;
    private Text _name;
    private Text _price;
    private Text _level;
    Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        if (_button) _button.onClick.AddListener(OnMouseDown);
        Text[] texts = GetComponentsInChildren<Text>();
        if (texts.Length >= 3)
        {
            _name = texts[0];
            _price = texts[1];
            _level = texts[2];
            SetTexts();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!_button) return;
        _button.enabled = DataStorage.JogiCoins > getPrice();
    }
    private void OnMouseDown()
    {
        DataStorage.Upgrade(UpgradeName);
        SetTexts();
    }

    private float getPrice()
    {
        return DataStorage.GetUpgradeCost(UpgradeName);
    }
    private string getPriceAsText()
    {
        return DataStorage.GetUpgradeCostAsText(UpgradeName);
    }
    private void SetTexts()
    {
        if (_name)
            _name.text = DataStorage.GetUpgradeName(UpgradeName);
        if (_price)
            _price.text = DataStorage.GetUpgradeCostAsText(UpgradeName);
        if (_level)
            _level.text = DataStorage.GetUpgradeLevelAsText(UpgradeName);
    }
}
