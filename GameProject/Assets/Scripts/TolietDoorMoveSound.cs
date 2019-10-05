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
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += TolietDoorMoveSound_InteractableObjectUngrabbed;
        
    }

    private void TolietDoorMoveSound_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabed = false;
    }

    private void TolietDoorMoveSound_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        z = transform.rotation.z;
        isGrabed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabed && !openDoorSource.isPlaying && transform.rotation.z != z)
        {
            openDoorSource.Play();
        }
        else
        {
            //openDoorSource.Stop();
        }
    }
}
