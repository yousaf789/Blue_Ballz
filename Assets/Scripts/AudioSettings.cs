using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string MenuPref = "MenuPref";
    private static readonly string InGamePref = "InGamePref";
    private static readonly string PopPref = "PopPref";
    private static readonly string GameOverPref = "GameOverPref";
    private float menuFloat, ingameFloat, popFloat, gameoverFloat;

    public AudioSource menuAudio;
    public AudioSource ingameAudio;
    public AudioSource popAudio;
    public AudioSource gameoverAudio;
    
    void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    {
        menuFloat = PlayerPrefs.GetFloat(MenuPref);
        ingameFloat = PlayerPrefs.GetFloat(InGamePref);
        popFloat = PlayerPrefs.GetFloat(PopPref);
        gameoverFloat = PlayerPrefs.GetFloat(GameOverPref);

        menuAudio.volume = menuFloat;
        ingameAudio.volume = ingameFloat;
        popAudio.volume = popFloat;
        gameoverAudio.volume = gameoverFloat;
    }
}
