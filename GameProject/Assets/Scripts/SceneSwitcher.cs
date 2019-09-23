using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
public class SceneSwitcher : MonoBehaviour
{
    public int sceneIndex = 0;
    private void Start()
    {
        
    }
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

