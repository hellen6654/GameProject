using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using VRTK;
public class PackageItem : MonoBehaviour
{

    //private bool isInBag;
    private bool timeLocker = false;
    private int counter = 0; //計數器
    private bool isTouching = false;
    // Use this for initialization
    void Start()
    {
        TimerCallback callback = new TimerCallback(AddCounter);
        Timer timer = new Timer(callback, null, 250, 500);

    }

    private void AddCounter(object state)
    {
        counter++;
        timeLocker = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        isTouching = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isTouching = false;
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(gameObject.ToString() + "Item is touching!");
        //Debug.Log(other.name);
        //手把按下Grib

        if (PackageSystem.isGrib)
        {
            Debug.Log("Controller is Gribed!");
            if (!timeLocker)
            {
                //isInBag = true;
                gameObject.transform.parent = other.gameObject.transform;
                PackageSystem.bag.Add(gameObject);
                PackageSystem.index = PackageSystem.bag.Count - 1;
                Debug.Log("Add " + gameObject.name.ToString() + "!");
                timeLocker = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {

        }
        else
        {

        }
    }
}
