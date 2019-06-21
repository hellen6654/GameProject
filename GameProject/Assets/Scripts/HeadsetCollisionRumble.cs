using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class HeadsetCollisionRumble : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		GetComponent<VRTK_HeadsetCollision>().HeadsetCollisionDetect += new HeadsetCollisionEventHandler(HeadsetCollisionControllerRumble);
	}

    private void HeadsetCollisionControllerRumble(object sender, HeadsetCollisionEventArgs e)
    {
        VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left),1);
        VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right),1);
        Debug.Log("ControllerRumble!!!");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
