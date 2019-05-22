using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
public class BookClicked : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(bookclicked_GripPress);
	}

    private void bookclicked_GripPress(object sender, ControllerInteractionEventArgs e)
    {
        if (BookHoverMoved.isHover)
			SceneManager.LoadScene(BookHoverMoved.hoverBookName);
    }

    // Update is called once per frame
    void Update () 
	{
		
	}
}
