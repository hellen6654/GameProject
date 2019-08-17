using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
public class SceneSwitcher : MonoBehaviour
{
    public int sceneIndex = 0;
    public GameObject controller;
    private void Start()
    {
        controller.GetComponent<VRTK_ControllerEvents>().TriggerUnclicked += new ControllerInteractionEventHandler(TriggerUnclickedChangeScene);
    }

    private void TriggerUnclickedChangeScene(object sender, ControllerInteractionEventArgs e)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

