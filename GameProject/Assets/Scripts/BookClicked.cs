using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
public class BookClicked : MonoBehaviour
{

    // Use this for initialization
    public GameObject BookFollower;
    void Start()
    {
        GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(bookclicked_GripPress);
    }

    private void bookclicked_GripPress(object sender, ControllerInteractionEventArgs e)
    {
        BookFollower.SetActive(true);
		BookFollower.GetComponentInChildren<Animator>().speed = 0.3f;
		Invoke("switchedSence",3f);
    }
    private void switchedSence()
    {
        if (BookHoverMoved.isHover)
            SceneManager.LoadScene(BookHoverMoved.hoverBookName);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
