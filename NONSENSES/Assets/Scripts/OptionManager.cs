using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionManager : MonoBehaviour
{


    public AudioManager audioManager;

    public AudioMixer mixer;

    public GameObject imageSound;
    public GameObject imageMusic;

    public Slider soundSlider;
    public Slider musicSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("SoundMute"))
        {
            PlayerPrefs.SetInt("SoundMute", 0); 
        }
        else
        {
            if (PlayerPrefs.GetInt("SoundMute") == 1)
            {

                AudioListener.pause = true;
                imageSound.SetActive(true);
            }
            else
            {
                AudioListener.pause = false;
                imageSound.SetActive(false);
             
            }
        }
        if (!PlayerPrefs.HasKey("MusicMute"))
        {
            PlayerPrefs.SetInt("MusicMute", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("MusicMute") == 1)
            {
                imageMusic.SetActive(true);
                FindObjectOfType<AudioManager>().Mute("Theme");
                Debug.Log("Muzyka jest zmutowana");
            }
            else
            {
             
                imageMusic.SetActive(false);
                FindObjectOfType<AudioManager>().UnMute("Theme");
                Debug.Log("Muzyka NIE jest zmutowana");
            }
        }


        if (PlayerPrefs.HasKey("SoundValue")) 
        {
            mixer.SetFloat("volume", PlayerPrefs.GetFloat("SoundValue"));
            FindObjectOfType<AudioManager>().VolumeProcent("Theme", PlayerPrefs.GetFloat("MusicValue"));
            soundSlider.value = PlayerPrefs.GetFloat("SoundSliderValue");
            musicSlider.value = PlayerPrefs.GetFloat("MusicValue");
        }
        else
        {
            PlayerPrefs.SetFloat("SoundValue", Mathf.Log10(1) * 20);
            PlayerPrefs.SetFloat("MusicValue", 100);
        }
        
    }
    public void SetLevel(float sliderValue)
    {
         mixer.SetFloat("volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SoundValue", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SoundSliderValue", sliderValue);
    }
    public void SetVolumeOfMusic(float value)
    {
        //float _value = value * 100;
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", value);
        PlayerPrefs.SetFloat("MusicValue", value);
    }
    public void MuteSoundButton()
    {
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
            imageSound.SetActive(false);
            PlayerPrefs.SetInt("SoundMute", 0);
        }

        else
        {
            AudioListener.pause = true;
            imageSound.SetActive(true);
            PlayerPrefs.SetInt("SoundMute", 1);
        }
    }
    public void MuteMusicButton()
    {
        if (PlayerPrefs.GetInt("MusicMute") == 1)
        {
            imageMusic.SetActive(false);
            PlayerPrefs.SetInt("MusicMute", 0);
            FindObjectOfType<AudioManager>().UnMute("Theme");
            Debug.Log("Odmutowano muzykê");
        }
        else
        {
            Debug.Log("ZMUTOWANO MUZYKÊ");
            imageMusic.SetActive(true);
            PlayerPrefs.SetInt("MusicMute", 1);
            FindObjectOfType<AudioManager>().Mute("Theme");
        }
    }
}
