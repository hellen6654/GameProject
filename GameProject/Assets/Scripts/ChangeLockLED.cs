﻿using UnityEngine;

public class ChangeLockLED : MonoBehaviour
{
    public GameObject Card;
    public GameObject Door;
    public AudioSource BeeSound;
    public AudioSource MoveSound;
    public float moveDistance;
    private bool isDoorMoving = false;
    private bool isDoorOpened = false;
    private bool isDoorClosed = false;
    private bool isDoorShouldOpen = false;
    private bool isDoorShouldClose = false;
    private const int DoorMoveDirect = -1;
    private Vector3 ClosedPos;
    private Vector3 OpenedPos;
    // Use this for initialization
    void Start()
    {
        GetComponentInChildren<Light>().color = new Color(1, 0, 0);
        OpenedPos = new Vector3(Door.transform.position.x + moveDistance * DoorMoveDirect, Door.transform.position.y, Door.transform.position.z);
        ClosedPos = Door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorShouldOpen)
        {
            if (Door.transform.position.x - OpenedPos.x > 0)
            {
                Door.transform.position = new Vector3(Door.transform.position.x+ Time.deltaTime*0.5f * DoorMoveDirect, Door.transform.position.y, Door.transform.position.z );
                isDoorMoving = true;
                
                if (!MoveSound.isPlaying && BeeSound.isPlaying)
                {
                    MoveSound.PlayDelayed(0.2f);     
                }
            }
            else
            {
                isDoorClosed = false;
                isDoorShouldOpen = false;
                isDoorOpened = true;
                BeeSound.Stop();
                MoveSound.Stop();
                Invoke("SetCloseDoor", 2f);
            }
            Debug.Log("door moving");
        }
        else if (isDoorShouldClose)
        {
            if (ClosedPos.x - Door.transform.position.x > 0)
            {
                Door.transform.position = new Vector3(Door.transform.position.x+ Time.deltaTime*0.5f, Door.transform.position.y, Door.transform.position.z );
                if (!MoveSound.isPlaying)
                {
                    MoveSound.Play();
                }
            }
            else
            {
                isDoorMoving = false;
                isDoorOpened = false;
                isDoorShouldClose = false;
                isDoorClosed = true;
                if (MoveSound.isPlaying)
                {
                    MoveSound.Stop();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Debug.Log("collision!!" + other.gameObject.name);
        if (other.name == Card.name)
        {
            Debug.Log(Card.name);
            GetComponentInChildren<Light>().color = new Color(0, 1, 0);
            if (!BeeSound.isPlaying)
            {
                BeeSound.Play();
            }
            if (!isDoorMoving)
                isDoorShouldOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponentInChildren<Light>().color = new Color(1, 0, 0);
        Debug.Log("Exit");
    }

    private void SetCloseDoor()
    {
        isDoorShouldClose = true;
    }
}
