using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderValue : MonoBehaviour
{
    public Slider vSlider;
    private AudioSlider volumeAudioSlider;
    public Slider mSlider;
    // Start is called before the first frame update
    void Awake()
    {
        volumeAudioSlider = GetComponent<AudioSlider>();
        Slider();
    }

 
    public void Slider()
    {
      //  vSlider.value = volumeAudioSlider.CurrentValue; // I want to access the value from Audio Slider so it can save the value and reapply it per restart
      //  mSlider.value = volumeAudioSlider.CurrentValue; // I want to access the value from Audio Slider so it can save the value and reapply it per restart
        Debug.Log("Volume Slider value: " + vSlider.ToString());
        Debug.Log("Music Slider value: " + mSlider.ToString());
    }
}
