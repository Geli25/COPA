using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;
using VRTK;

public class attachToLeftController : MonoBehaviour
{
    public VRTK_StraightPointerRenderer controller;

    VRTK_StraightPointerRenderer controllerOrigin;
    Transform rayOrigin;
    // Start is called before the first frame update
    void Start()
    {
        controllerOrigin=controller.GetComponent<VRTK_StraightPointerRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        transform.eulerAngles = controllerOrigin.accessOrigin.position;
    }
}
