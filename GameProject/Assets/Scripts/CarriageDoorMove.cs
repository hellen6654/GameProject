using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageDoorMove : MonoBehaviour {
    public GameObject[] Card;
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
        OpenedPos = new Vector3(Door.transform.position.x , Door.transform.position.y, Door.transform.position.z + moveDistance);
        ClosedPos = Door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorShouldOpen)
        {
            if (Door.transform.position.z - OpenedPos.z * -1 > 0)
            {
                Door.transform.position = new Vector3(Door.transform.position.x , Door.transform.position.y, Door.transform.position.z + Time.deltaTime * 0.5f * DoorMoveDirect);
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
            if (ClosedPos.z - Door.transform.position.z > 0)
            {
                Door.transform.position = new Vector3(Door.transform.position.x , Door.transform.position.y, Door.transform.position.z + Time.deltaTime * 0.5f);
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
        Debug.Log("collision!!" + other.name);
        List<GameObject> cardList = new List<GameObject>(Card);
        if (IsInList(other.name,cardList))
        {
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

    private bool IsInList(string name,List<GameObject> list)
    {
        foreach (var item in list)
        {
            if (item.name == name)
            {
                return true;
            }
        }
        return false;
    }
}
