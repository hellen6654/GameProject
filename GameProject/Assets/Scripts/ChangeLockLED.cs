using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLockLED : MonoBehaviour {
    public GameObject Card;
    public AudioSource bee;
    // Use this for initialization
    void Start () {
        gameObject.AddComponent<BoxCollider>();
        GetComponentInChildren<Light>().color = new Color(1, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(Card.name);
        Debug.Log("collision!!" + other.name);
        if (other.name == Card.name)
        {
            bee.Play();
            GetComponentInChildren<Light>().color = new Color(0, 1, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponentInChildren<Light>().color = new Color(1, 0, 0);
    }
}
