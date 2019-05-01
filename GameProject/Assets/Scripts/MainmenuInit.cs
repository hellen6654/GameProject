using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuInit : MonoBehaviour {
    private AudioSource BGMAudioSource;
    private GameObject[] effectAudioSource;
    // Use this for initialization
    void Start () {
        BGMAudioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        effectAudioSource = GameObject.FindGameObjectsWithTag("Effect");
        BGMAudioSource.volume = Setting.BGMVolume;
        foreach (var e in effectAudioSource)
            e.GetComponent<AudioSource>().volume = Setting.EffectVolume;
    }
	
}
