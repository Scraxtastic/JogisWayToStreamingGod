using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    public Text jogicoinText;
    public Text mahonicoinText;


    // VALUES
    public static float jogicoins { get; set; }
    public static float mahonicoins { get; set; }

    //
    private static bool _upgradesAreSet = false;
    private static Upgrade _attack;
    public enum PossibleUpgrade
    {
        Attack = 1,
    }




    // Start is called before the first frame update
    void Start()
    {
        SetUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        if (jogicoinText)
            jogicoinText.text = $"Jogicoins: {(Mathf.Round(jogicoins * 100) / 100).ToString()}";
        if (mahonicoinText)
            mahonicoinText.text = $"Mahonicoins: {mahonicoins}";
    }

    void SetUpgrades()
    {
        if (_upgradesAreSet) return;
        _attack = new Upgrade().WithInitialCost(1).WithLevel(1).WithCostMultiplier(1);

        _upgradesAreSet = true;
    }

    public static void Upgrade(PossibleUpgrade abilityToUpgrade)
    {
        switch (abilityToUpgrade)
        {
            case PossibleUpgrade.Attack: _attack.Level++; break;
            default: break;
        }
    }

    public static string GetUpgradeLevel(PossibleUpgrade abilityToGet)
    {
        return abilityToGet switch
        {
            PossibleUpgrade.Attack => _attack.Level + "",
            _ => "GRRR",
        };
    }

}
