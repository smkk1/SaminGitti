using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider sliderInstance;

    public AudioMixer audioMixer;

    void Start()
    {
        sliderInstance.minValue = 0.0001f;
        sliderInstance.maxValue = 1f;
        sliderInstance.wholeNumbers = false;
        sliderInstance.value = 0.5f;
    }

    public void OnValueChanged(float value)
    {
        Debug.Log(Mathf.Log10(value) * 20);
        audioMixer.SetFloat("MasterVol", Mathf.Log10(value) * 20);
    }
}
