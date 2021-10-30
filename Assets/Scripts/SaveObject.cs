using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject 
{
    public Ability[] Abilities { get; set; }
    public float JogiCoins { get; set; }
    public float Volume { get; set; }
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
    public SaveObject WithVolume(float volume)
    {
        Volume = volume;
        return this;
    }
}
