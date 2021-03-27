using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    public AudioMixer m_mixer;
    public Slider m_VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        m_VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel(float sliderValue)
    {
        m_mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
