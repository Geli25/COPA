using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class addRemoveObjects : MonoBehaviour
{
    VRTK_Pointer pointer;
    public GameObject person;
    public GameObject projector;
    public GameObject parentWorld;
    public GameObject parentCeiling;

    float[] personHeights;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponent<VRTK_Pointer>();
        personHeights =new float[3];
        personHeights[0] = 0.5f;
        personHeights[1] = 0.7f;
        personHeights[2] = 0.9f;
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
                    GameObject newPerson=Instantiate(person, new Vector3(pointer.pointerRenderer.GetDestinationHit().point.x, 0.5f, pointer.pointerRenderer.GetDestinationHit().point.z), Quaternion.identity);
                    newPerson.transform.parent = parentWorld.transform;
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
                    GameObject newProjector=Instantiate(projector, new Vector3(pointer.pointerRenderer.GetDestinationHit().point.x, 4.38f, pointer.pointerRenderer.GetDestinationHit().point.z), Quaternion.Euler(0,0, -17.41f));
                    newProjector.transform.parent = parentCeiling.transform;
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

                //toggle person height
                if (pointer.pointerRenderer.GetDestinationHit().collider.tag == "person")
                {
                    if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
                    {
                        if (counter > 2)
                        {
                            counter = 0;
                        }
                        Debug.Log(counter);
                        GameObject personObject = pointer.pointerRenderer.GetDestinationHit().transform.gameObject;
                        personObject.transform.localScale = new Vector3(personObject.transform.localScale.x, personHeights[counter], personObject.transform.localScale.z);
                        counter += 1;
                    }
                }
            }

        }
    }
}
