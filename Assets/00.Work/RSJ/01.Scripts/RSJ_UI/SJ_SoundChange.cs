using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SJ_SoundChange : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider _BGMSlider;
    [SerializeField] private Slider _SFXSlider;

    public void SoundChange()
    {
        if (_BGMSlider.value > - 50)
        {
            audioMixer.SetFloat("BGM", _BGMSlider.value);
        }
        else
        {
            audioMixer.SetFloat("BGM", -80);
        }
        if (_SFXSlider.value > -50)
        {
            audioMixer.SetFloat("SFX", _SFXSlider.value);
        }
        else
        {
            audioMixer.SetFloat("SFX", -80);
        }
    }
}
