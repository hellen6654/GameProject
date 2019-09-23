using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScencVenderMechine : MonoBehaviour {
    public GameObject floor;
    public GameObject wall;
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
            floor.SetActive(true);
            wall.SetActive(false);
            Debug.Log("floor appear!!");
        }
    }
}
