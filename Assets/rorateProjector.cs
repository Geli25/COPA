using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class rorateProjector : MonoBehaviour
{
    VRTK_Pointer pointer;
    public GameObject LeftPointer;

    void Start()
    {
        pointer = LeftPointer.GetComponent<VRTK_Pointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer.pointerRenderer != null)
        {
            if (pointer.pointerRenderer.GetDestinationHit().collider.tag == "projector")
            {
                if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) != null)
                {
                    Debug.Log("OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick");

                    float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
                    transform.eulerAngles += new Vector3(0, horizontalInput, 0);
                }
            }
        }
    }
}
