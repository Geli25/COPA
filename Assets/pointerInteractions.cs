using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class pointerInteractions : MonoBehaviour
{
    VRTK_Pointer pointer;
    public GameObject person;
    public GameObject projector;

    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponent<VRTK_Pointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer.pointerRenderer != null)
        {
            //Add person
            if (pointer.pointerRenderer.GetDestinationHit().collider.gameObject.name == "floor")
            {
                if (OVRInput.GetDown(OVRInput.Button.Three))
                {
                    Instantiate(person, new Vector3(pointer.pointerRenderer.GetDestinationHit().point.x, 0.5f, pointer.pointerRenderer.GetDestinationHit().point.z), Quaternion.identity);
                }
                else
                {
                    return;
                }
            }

            //Add Projector

            else if (pointer.pointerRenderer.GetDestinationHit().collider.gameObject.name == "Ceiling")
            {
                if (OVRInput.GetDown(OVRInput.Button.Four))
                {
                    Instantiate(projector, new Vector3(pointer.pointerRenderer.GetDestinationHit().point.x, 4.38f, pointer.pointerRenderer.GetDestinationHit().point.z), Quaternion.identity);
                }
                else
                {
                    return;
                }
            }

            //Delete Person && Projector
            else if (pointer.pointerRenderer.GetDestinationHit().collider.tag == "person"||pointer.pointerRenderer.GetDestinationHit().collider.tag=="projector") {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)==1)
                {
                    Destroy(pointer.pointerRenderer.GetDestinationHit().transform.gameObject);
                }
            }
        }
    }
}
