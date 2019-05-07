using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting: MonoBehaviour {
    static public float BGMVolume = 0.5f;       //BGM音量預設50%
    static public float EffectVolume = 0.5f;    //音效音量預設50%
    static public float Gramma = 0.25f;         //亮度預設50%
    private AudioSource BGMAudioSource;
    private GameObject[] effectAudioSource;
    private GameObject livingCamera;
    public void BGMVolumeChanged(float v)
    {
        BGMAudioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>(); 
        Debug.Log("BGMVolume:"+v.ToString());
        BGMVolume = v;
        BGMAudioSource.volume = BGMVolume; 
        //把BGM的volume都改成BGMVolume
    }
    public void EffectVolumeChanged(float v)
    {
        Debug.Log("EffectVolume:" + v.ToString());
        EffectVolume = v;
        effectAudioSource = GameObject.FindGameObjectsWithTag("Effect");
        foreach (var item in effectAudioSource)
            item.GetComponent<AudioSource>().volume = EffectVolume; 
        //把所有音效的volume都改成EffectVolume
    }
    public void GrammaChanged(float v)
    {
        Debug.Log("Gramma:" + v.ToString());
        Gramma = v ;
        livingCamera = GameObject.FindGameObjectWithTag("MainCamera");
        livingCamera.GetComponent<ColorAdjustEffect>().brightness = Gramma; 
        //把攝影機底下的ColorAdjustEffect的亮度改成Gramma
    }
    
    public void ExitGame()
    {
        #if UNITY_EDITOR // 如果是編輯模式 退出遊玩
            UnityEditor.EditorApplication.isPlaying = false;
        #else //如果是遊玩模式 關閉程式
            Application.Quit();
        #endif
    }
}
