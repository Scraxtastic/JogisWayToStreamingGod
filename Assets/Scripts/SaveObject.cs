using Assets.Scripts;

[System.Serializable]
public class SaveObject 
{
    public Ability[] Abilities { get; set; }
    public float JogiCoins { get; set; }
    public SaveObject()
    {

    }

    public SaveObject WithAbilities(Ability[] abilities)
    {
        Abilities = abilities;
        return this;
    }

    public SaveObject WithJogiCoins(float jogiCoins)
    {
        JogiCoins = jogiCoins;
        return this;
    }
}
