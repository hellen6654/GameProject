using UnityEngine;

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
        OpenedPos = new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z + moveDistance * DoorMoveDirect);
        ClosedPos = Door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorShouldOpen)
        {
            if (Door.transform.position.z - OpenedPos.z > 0)
            {
                Door.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z + Time.deltaTime*DoorMoveDirect);
                isDoorMoving = true;
                //MoveSound.Play();
            }
            else
            {
                isDoorClosed = false;
                isDoorShouldOpen = false;
                isDoorOpened = true;
                Invoke("SetCloseDoor", 3f);
            }
            Debug.Log("door moving");
        }
        else if (isDoorShouldClose)
        {
            if (ClosedPos.z - Door.transform.position.z > 0)
            {
                Door.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z + Time.deltaTime);
                //MoveSound.Play();
            }
            else
            {
                isDoorMoving = false;
                isDoorOpened = false;
                isDoorShouldClose = false;
                isDoorClosed = true;
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
            //BeeSound.Play();
            GetComponentInChildren<Light>().color = new Color(0, 1, 0);
            if(!isDoorMoving)
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
