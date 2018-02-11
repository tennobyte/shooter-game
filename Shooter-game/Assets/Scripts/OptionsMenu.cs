using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public float volume;
    public Toggle muteToggle;
    public Slider volumeSlider;

	public void SetVolume(float value)
    {
        audioMixer.SetFloat("volume", value);
    }

    void OnEnable()
    {
        audioMixer.GetFloat("volume", out volume);
        volumeSlider.value = volume;
        if (volume <= 0)
        {
            muteToggle.isOn = false;
        }
        else
        {
            muteToggle.isOn = true;
        }
    }

    public void SetMute(bool isMuted)
    {
        if (isMuted)
        {
            audioMixer.SetFloat("volume", -80);
        }
        else
        {
            volume = volumeSlider.value;
            audioMixer.SetFloat("volume", volume);
        }
    }
}
