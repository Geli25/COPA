using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class rotateProjector : MonoBehaviour
{
    VRTK_Pointer pointer;
    bool selected = false;
    string selectedName = null;
    GameObject selectedObject;

    void Start()
    {
        pointer = GetComponent<VRTK_Pointer>();
    }

    void selectObject(GameObject chosenObject, string name)
    {
        selected = true;
        selectedName = name;
        selectedObject = chosenObject;
        selectedObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    void reSelectObject(GameObject chosenObject, string name)
    {
        selectedObject.GetComponent<Renderer>().material.color = Color.white;
        selectObject(chosenObject, name);
    }

    void Update()
    {
        if (pointer.pointerRenderer != null)
        {
            //projector selection
            if (pointer.pointerRenderer.GetDestinationHit().collider.tag == "projector")
            {
           
                if (OVRInput.GetDown(OVRInput.Button.One)&&selectedObject==null)
                {
                    selectObject(pointer.pointerRenderer.GetDestinationHit().transform.gameObject, "projector");
                }
                else if (OVRInput.GetDown(OVRInput.Button.One)&&selectedObject!=null)
                {
                    reSelectObject(pointer.pointerRenderer.GetDestinationHit().transform.gameObject, "projector");
                }
            }

            /*
            //ceiling selection
            if (pointer.pointerRenderer.GetDestinationHit().collider.gameObject.name == "Ceiling")
            {
                if (OVRInput.GetDown(OVRInput.Button.One)&&selectedObject==null)
                {
                    selectObject(pointer.pointerRenderer.GetDestinationHit().transform.gameObject, "ceiling");
                    Debug.Log("ceiling selected");
                }
                else if (OVRInput.GetDown(OVRInput.Button.One) && selectedObject != null)
                {
                    reSelectObject(pointer.pointerRenderer.GetDestinationHit().transform.gameObject, "ceiling");
                }
            }
            */
            

        }

        //deselect
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (selectedObject != null||selected==true)
            {
                selected = false;
                selectedName = null;
                selectedObject.GetComponent<Renderer>().material.color = Color.white;
                selectedObject = null;
            }
            else
            {
                return;
            }

        }


        if (selected == true && selectedObject != null)
        {
            //rotate projector
            if (selectedName == "projector")
            {
                selectedObject.GetComponent<Renderer>().material.color = Color.blue;
                if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) != null)
                {
                    float horizontalInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
                    selectedObject.transform.eulerAngles += new Vector3(0, horizontalInput, 0);
                }
            }

            /*
            //adjust ceiling height
            else if (selectedName == "ceiling")
            {
                if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) != null)
                {
                    float verticalInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
                    selectedObject.transform.position += new Vector3(selectedObject.transform.position.x, verticalInput*0.1f, selectedObject.transform.position.z);
                    if (selectedObject.transform.position.y > 10.7f)
                    {
                        selectedObject.transform.position = new Vector3(selectedObject.transform.position.x, 10.7f, selectedObject.transform.position.z);
                    }
                    else if (selectedObject.transform.position.y < 9.5f)
                    {
                        selectedObject.transform.position = new Vector3(selectedObject.transform.position.x, 7.89f, selectedObject.transform.position.z);
                    }

                }
            }
            */
            else { return; }

        }
        else
        {
            return;
        }
    }
}
