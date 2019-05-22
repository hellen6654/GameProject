using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class BookHoverMoved : MonoBehaviour {
	public GameObject book;
	static public bool isHover = false;
	static public string hoverBookName = "";
	// Use this for initialization
	void Start () 
	{
		GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += new InteractableObjectEventHandler(bookhovermoved_InteractableObjectTouched);
		GetComponent<VRTK_InteractableObject>().InteractableObjectUntouched += new InteractableObjectEventHandler(bookhovermoved_InteractableObjectUntouched);
	}
	private void bookhovermoved_InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
    {
		book.transform.Translate(0,-0.05f,0);
		isHover = true;
		if (book.name == "bookOne1")
			hoverBookName = "Firstbook";
		else if (book.name == "bookOne20")
			hoverBookName = "Secondbook";
		else if (book.name == "bookOne31")
			hoverBookName = "Thirdbook";
		else if (book.name == "bookOne52")
			hoverBookName = "Fourthbook";
    }
    private void bookhovermoved_InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
    {
        book.transform.Translate(0,0.05f,0);
		isHover = false;
		hoverBookName = "";
    }

    

    // Update is called once per frame
    void Update () 
	{
		
	}
}
