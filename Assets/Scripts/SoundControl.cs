using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class SoundControl : MonoBehaviour
{
    AudioSource _audio;

    static float _volume = 0.1f;
    public float Volume => SoundControl._volume;
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        if (_audio)
            _audio.volume = SoundControl._volume;
    }

    public void OnChangeSlider(float newVol)
    {
        SoundControl._volume = newVol;
    }

    void Update()
    {
        if (_audio)
            _audio.volume = SoundControl._volume;

    }

}
