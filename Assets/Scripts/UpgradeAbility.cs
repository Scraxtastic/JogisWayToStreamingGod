using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DataStorage;

public class UpgradeAbility : MonoBehaviour
{
    public PossibleUpgrade UpgradeName;
    private Text _text;
    private Text _price;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button) button.onClick.AddListener(OnMouseDown);
        _text = GetComponentInChildren<Text>();
        _price = GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        DataStorage.Upgrade(UpgradeName);
        if (_text)
            _text.text = DataStorage.GetUpgradeLevel(UpgradeName);
    }
}
