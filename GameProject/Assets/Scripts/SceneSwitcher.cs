using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneIndex = 0;
    public float delayTime = 0.0f;
    private void Start()
    {
        Invoke("GoScene",delayTime);
    }
    public void GoScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

