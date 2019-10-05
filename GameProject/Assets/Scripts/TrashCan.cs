using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
public class TrashCan : MonoBehaviour
{
    public GameObject[] paper;
    private List<bool> IsTouch = new List<bool>() { false, false, false };
    private int number = 0;
    // Use this for initialization
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(IsInList(collision.gameObject.name));
        if (IsInList(collision.gameObject.name))
        {
            collision.gameObject.SetActive(false);
            number++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CountTrueAmount());
        GetComponentInChildren<VRTK_ObjectTooltip>().displayText = CountTrueAmount().ToString() + " / " + paper.Length.ToString();
        GetComponentInChildren<Text>().text = CountTrueAmount().ToString() + " / " + paper.Length.ToString();
        
    }
    private bool IsInList(string name)
    {
        int counter = 0;
        foreach (var item in paper)
        {
            counter++;
            if (item.name == name)
            {
                IsTouch[counter] = true;
                return true;
            }
        }
        return false;
    }

    private int CountTrueAmount()
    {
        int result = 0;
        foreach (var item in IsTouch)
        {
            if (item)
            {
                result++;
            }
        }
        return result;
    }
}
