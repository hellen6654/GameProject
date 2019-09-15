using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour {

    public GameObject first;
    public GameObject second;
    public GameObject mask;
    private CanvasGroup canvasGroupFirst;
    public AudioSource startAudioSource;
    public AudioSource sadAudioSource;
    public float changeTimeSeconds = 5;
    public float stopTime = 2;
    public float startAlpha = 0;
    public float endAlpha = 1;
    float changeRate = 0;
    float timeSoFar = 0;
    bool fading = false;
    float startVolume = 0.3f;
    float endVolume = 0.8f;
    float soundRate = 0;
    private void Start()
    {
        canvasGroupFirst = first.GetComponent<CanvasGroup>();
        canvasGroupFirst.alpha = 0f;
        startAudioSource.PlayDelayed(0.8f);
        FadeIn();
        Invoke("FadeOut", changeTimeSeconds + stopTime);
        Invoke("SwitchCanvas",(changeTimeSeconds*2)+stopTime);
    }
    public void FadeIn()
    {
        startAlpha = 0;
        endAlpha = 1;
        timeSoFar = 0;
        fading = true;
        StartCoroutine(FadeCoroutine());
    }

    public void FadeOut()
    {
        startAlpha = 1;
        endAlpha = 0;
        timeSoFar = 0;
        fading = true;
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        changeRate = (endAlpha - startAlpha) / changeTimeSeconds;
        soundRate = (endVolume - startVolume) / changeTimeSeconds;
        SetAlpha(startAlpha);
        while (fading)
        {
            timeSoFar += Time.deltaTime;
            if (timeSoFar > changeTimeSeconds)
            {
                fading = false;
                SetAlpha(endAlpha);
                SetVolume(endVolume);
                yield break;
            }
            else
            {
                SetAlpha(canvasGroupFirst.alpha + (changeRate * Time.deltaTime));
                SetVolume(startAudioSource.volume + (soundRate* Time.deltaTime));
            }

            yield return null;
        }
    }

    public void SetAlpha(float alpha)
    {
        canvasGroupFirst.alpha = Mathf.Clamp(alpha, 0, 1);
    }
    public void SetVolume(float v)
    {
        startAudioSource.volume = Mathf.Clamp(v, 0, 1);
    }
    void SwitchCanvas()
    {
        first.SetActive(false);
        second.SetActive(true);
        mask.SetActive(true);
        startAudioSource.Stop();
        sadAudioSource.Play();
    }
}
