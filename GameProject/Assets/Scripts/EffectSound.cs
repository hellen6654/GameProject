using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip hover;
    public AudioClip clicked;
    public void HoveredSound()
    {
        audioSource.PlayOneShot(hover);
    }
    public void Clickedsound()
    {
        audioSource.PlayOneShot(clicked);
    }
}
