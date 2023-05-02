using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MenuPref = "MenuPref";
    private static readonly string InGamePref = "InGamePref";
    private static readonly string PopPref = "PopPref";
    private static readonly string GameOverPref = "GameOverPref";
    private int firstPlayInt;
    private float menuFloat, ingameFloat, popFloat, gameoverFloat;

    public Slider menuSlider, ingameSlider, popSlider, gameoverSlider;
    public AudioSource menuAudio;
    public AudioSource ingameAudio;
    public AudioSource popAudio;
    public AudioSource gameoverAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            menuFloat = .25f;
            ingameFloat = .25f;
            popFloat = .5f;
            gameoverFloat = .5f;
            menuSlider.value = menuFloat;
            ingameSlider.value = ingameFloat;
            popSlider.value = popFloat;
            gameoverSlider.value = gameoverFloat;
            PlayerPrefs.SetFloat(MenuPref, menuFloat);
            PlayerPrefs.SetFloat(InGamePref, ingameFloat);
            PlayerPrefs.SetFloat(PopPref, popFloat);
            PlayerPrefs.SetFloat(GameOverPref, gameoverFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            menuFloat = PlayerPrefs.GetFloat(MenuPref);
            menuSlider.value = menuFloat;
            ingameFloat = PlayerPrefs.GetFloat(InGamePref);
            ingameSlider.value = ingameFloat;
            popFloat = PlayerPrefs.GetFloat(PopPref);
            popSlider.value = popFloat;
            gameoverFloat = PlayerPrefs.GetFloat(GameOverPref);
            gameoverSlider.value = gameoverFloat;
        }
    }

    public void SaveSoundSettings()
        {
            PlayerPrefs.SetFloat(MenuPref, menuSlider.value);
            PlayerPrefs.SetFloat(InGamePref, ingameSlider.value);
            PlayerPrefs.SetFloat(PopPref, popSlider.value);
            PlayerPrefs.SetFloat(GameOverPref, gameoverSlider.value);
        }

    void OnApplicationFocus(bool inFocus)
        {
            if (!inFocus)
            {
                SaveSoundSettings();
            }
        }

    public void UpdateSound()
    {
        menuAudio.volume = menuSlider.value;
        ingameAudio.volume = ingameSlider.value;
        popAudio.volume = popSlider.value;
        gameoverAudio.volume = gameoverSlider.value;
    }

}
