using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScencVenderMechine : MonoBehaviour {
    public GameObject canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("collision!!" + other.name);
        if (other.name == "ticket(1)" || other.name == "ticket")
        {
            canvas.SetActive(true);
            Debug.Log("canvas appear!!");
        }
    }
    private void O(Collision collision)
    {
        Debug.Log("collision!!"+ collision.gameObject.name);
        if (collision.gameObject.name == "ticket(1)"|| collision.gameObject.name == "ticket")
        {
            canvas.SetActive(true);
            Debug.Log("canvas appear!!");
        }
    }
}
