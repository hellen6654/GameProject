using UnityEngine;
using VRTK;
public class MainScencVenderMechine : MonoBehaviour
{
    public GameObject floor;
    public GameObject wall;
    private bool wasHaptics = false;
    private int counter = 50;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision!!" + other.name);
        if (other.name == "ticket")
        {
            if (!wasHaptics)
            {
                counter--;
                VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left), 1);
                VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right), 1);
                Debug.Log("ControllerRumble!!!");
                if (counter < 0)
                {
                    wasHaptics = true;
                }
            }
            floor.SetActive(true);
            wall.SetActive(false);
            Debug.Log("floor appear!!");
        }
    }
}
