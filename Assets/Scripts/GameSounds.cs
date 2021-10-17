using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public static AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        DeathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlayDeathSound()
    {
        if (DeathSound && !DeathSound.isPlaying)
            DeathSound.Play();
    }
}
