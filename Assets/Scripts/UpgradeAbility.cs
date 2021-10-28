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
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button) button.onClick.AddListener(OnMouseDown);
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

    }
    private void OnMouseDown()
    {
        DataStorage.Upgrade(UpgradeName);
        SetTexts();
    }
    private void SetTexts()
    {
        if (_name)
            _name.text = DataStorage.GetUpgradeName(UpgradeName);
        if (_price)
            _price.text = DataStorage.GetUpgradeCost(UpgradeName);
        if (_level)
            _level.text = DataStorage.GetUpgradeLevel(UpgradeName);
    }
}
