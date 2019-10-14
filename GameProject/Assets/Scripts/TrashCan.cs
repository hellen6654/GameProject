using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
using UnityEngine.SceneManagement;
public class TrashCan : MonoBehaviour
{
    public AudioSource audio;
    public GameObject[] paper;
    private bool change = false;
    public GameObject Card;
    private int number = 0;
    // Use this for initialization
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colllllision");
        if (IsInList(collision.gameObject.tag))
        {
            collision.gameObject.SetActive(false);
            number++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(number);
        GetComponentInChildren<VRTK_ObjectTooltip>().displayText = number.ToString() + " / " + paper.Length.ToString();
        GetComponentInChildren<Text>().text = number.ToString() + " / " + paper.Length.ToString();
        if (number == 3)
        {
            if (!change)
            {
                Card.SetActive(true);
            }
            audio.volume = audio.volume * 0.3f;
        }
        
    }
    private bool IsInList(string tag)
    {
        foreach (var item in paper)
        {       
            if (item.tag == tag)
            {
                Debug.Log(item.tag + " / " + tag);
                return true;
            }
        }
        return false;
    }
    private void changeScence()
    {
        SceneManager.LoadScene("LastBook");
    }
}
