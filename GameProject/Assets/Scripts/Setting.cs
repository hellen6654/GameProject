using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting: MonoBehaviour {
    static public float BGMVolume = 0.5f;       //BGM音量預設50%
    static public float EffectVolume = 0.5f;    //音效音量預設50%
    static public float Gramma = 0.5f;          //亮度預設50%

    private AudioSource BGMAudioSource;
    private GameObject[] effectAudioSource;
    private GameObject[] grammaLight;
    public void BGMVolumeChanged(float v)
    {
        BGMAudioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>(); ;
        Debug.Log("BGMVolume:"+v.ToString());
        BGMVolume = v;
        BGMAudioSource.volume = v;
    }
    public void EffectVolumeChanged(float v)
    {
        Debug.Log("EffectVolume:" + v.ToString());
        EffectVolume = v;
        effectAudioSource = GameObject.FindGameObjectsWithTag("Effect");
        foreach (var item in effectAudioSource)
            item.GetComponent<AudioSource>().volume = v; //把所有音效的volume都改成v
    }
    public void GrammaChanged(float v)
    {
        Debug.Log("Gramma:" + v.ToString());
        Gramma = v;
        grammaLight = GameObject.FindGameObjectsWithTag("Light");
        foreach (var item in grammaLight)
        {
            item.GetComponent<Light>().intensity = v; //把所有燈光的intensity都改成v
        }
    }
}
