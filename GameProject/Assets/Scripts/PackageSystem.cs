using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PackageSystem : MonoBehaviour
{
    public GameObject controller;
    static public List<GameObject> bag = new List<GameObject>();
    static public bool isGrib = false;
    static public int index = 0; //目前手把上的物件
    private Vector2 startPos;// = new Vector2(-87f,-87f);
    private Vector2 endPos;// = new Vector2(-87f, -87f);
    void PreviousItem()
    {
        //切換到上一個物品
        //...
        bag[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = bag.Count - 1; // clip index (sadly, % cannot be used here, because it is NOT a modulus operator)
        }
        bag[index].SetActive(true);
    }

    void NextItem()
    {
        //切換到下一個物品
        //...
        bag[index].SetActive(false);
        index++;
        index %= bag.Count; // clip index (turns to 0 if index == items.Count)
        bag[index].SetActive(true);
    }

    void SnapObject()
    {
        //把bag裡面obgect的SnapPoint的東西黏到手把上
        foreach (var item in bag)
            item.SetActive(false);

        bag[index].SetActive(true);
        //bag[index].transform.position = controller.transform.position + new Vector3(-0.2f, 0f, 0f);
    }



    private void BagGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        isGrib = false;
        //Debug.Log("GripReleased" + isGrib.ToString());
    }

    private void BagGripPress(object sender, ControllerInteractionEventArgs e)
    {
        isGrib = true;
        //Debug.Log("GripReleased"+isGrib.ToString());
    }

    void Start()
    {
        controller.GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(BagGripPress);
        controller.GetComponent<VRTK_ControllerEvents>().GripReleased += new ControllerInteractionEventHandler(BagGripReleased);
        controller.GetComponent<VRTK_ControllerEvents>().TouchpadTouchStart += new ControllerInteractionEventHandler(BagTouchpadTouchStart);
        controller.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(BagTouchpadTouchEnd);
        InitPos(ref startPos);
        InitPos(ref endPos);
    }

    private void BagTouchpadTouchStart(object sender, ControllerInteractionEventArgs e)
    {
        startPos = e.touchpadAxis;
    }

    private void BagTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        endPos = e.touchpadAxis;
    }

    // Update is called once per frame
    void Update()
    {
        if (bag.Count > 0)
        {
            if (CheckPos(startPos) && CheckPos(endPos))
            {
                if (startPos.x - endPos.x > 0.5)
                {
                    //向左滑 - 上一個
                    PreviousItem();
                }
                else if (startPos.x - endPos.x < 0.5)
                {
                    //向右滑 - 下一個
                    NextItem();
                }
                InitPos(ref startPos);
                InitPos(ref endPos);
            }
            SnapObject();
        }
    }
    /// <summary>
    /// 檢查Vector2的x&y不為-87
    /// </summary>
    /// <param name="pos"></param>
    /// <returns>true or false</returns>
    bool CheckPos(Vector2 pos)
    {
        if (pos.x != -87f && pos.y != -87f)
            return true;

        return false;
    }
    bool InitPos(ref Vector2 pos)
    {
        try
        {
            pos = new Vector2(-87f, -87f);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}
