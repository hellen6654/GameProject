using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandFloorUIAppear : MonoBehaviour {
    public GameObject camera;
    public GameObject canvas;
    public GameObject floor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //floor center 0.1 ,0 ,-2 size 1 ,0.1 ,1
        //if (floor.active)
        //{
        //    Debug.Log(camera.transform.position.ToString());
        //}

        if (floor.active && camera.transform.position.x < 2 && camera.transform.position.x > -2 &&
            camera.transform.position.z < 0 && camera.transform.position.z > -3)
        {
            canvas.GetComponent<CanvasGroup>().alpha = 1;
            canvas.GetComponent<CanvasGroup>().interactable = true;
            canvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            canvas.GetComponent<CanvasGroup>().alpha = 0;
            canvas.GetComponent<CanvasGroup>().interactable = false;
            canvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }


    }
}
