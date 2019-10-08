using UnityEngine;
using VRTK;
public class TolietDoorMoveSound : MonoBehaviour
{
    private float z;
    private bool isGrabed = false;
    public AudioSource openDoorSource;
    // Use this for initialization
    void Start()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += TolietDoorMoveSound_InteractableObjectGrabbed;
    }

    private void TolietDoorMoveSound_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabed)
        {
            openDoorSource.Play();
            isGrabed = false;
        }
        else
        {
            //openDoorSource.Stop();
        }
    }
}
