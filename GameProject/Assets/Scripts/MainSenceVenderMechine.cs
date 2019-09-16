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
        if (other.name == "ticket")
        {
            canvas.SetActive(true);
            Debug.Log("canvas appear!!");
        }
    }
}
