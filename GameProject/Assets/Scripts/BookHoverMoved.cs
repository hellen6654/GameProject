using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class BookHoverMoved : MonoBehaviour
{
    public GameObject book;
    static public bool isHover = false;
    static public string hoverBookName = "";
    // Use this for initialization

    private Vector3 originalPosition;
    private Quaternion originalQuaternion;
    private Vector3 bookSize;
    void Start()
    {
        //記住書本起始的座標位置
        originalPosition = book.transform.position;
        //記住書本起始的旋轉角度
        originalQuaternion = book.transform.rotation;
        //把 EventHandler 加到 VRTK_InteractableObject腳本底下的Event
        GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += new InteractableObjectEventHandler(bookhovermoved_InteractableObjectTouched);
        GetComponent<VRTK_InteractableObject>().InteractableObjectUntouched += new InteractableObjectEventHandler(bookhovermoved_InteractableObjectUntouched);
    }
    private void bookhovermoved_InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
    {
        book.transform.position += new Vector3(0, 0.05f, -0.05f);
        book.transform.rotation = Quaternion.Euler(-120,0,180);
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
        book.transform.position = originalPosition;
        book.transform.rotation = originalQuaternion;
        isHover = false;
        hoverBookName = "";
    }
    // Update is called once per frame
    void Update()
    {

    }
}
