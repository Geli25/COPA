using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class keepScale : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject parent;

    public float fixedScale = 0.75f;
    public float fixedGrabbedScale = 0.1f;

    VRTK_InteractableObject grabbingMechanic;
    bool isGrabbed;

    void Start()
    {
        parent = transform.parent.gameObject;
        grabbingMechanic = parent.GetComponent<VRTK_InteractableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrabbed = grabbingMechanic.IsGrabbed();

        Debug.Log(isGrabbed);

        if (parent != null)
        {
            if (isGrabbed == true)
            {
                transform.localScale = new Vector3(fixedGrabbedScale / parent.transform.localScale.x, fixedGrabbedScale / parent.transform.localScale.y, fixedGrabbedScale / parent.transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(fixedScale / parent.transform.localScale.x, fixedScale / parent.transform.localScale.y, fixedScale / parent.transform.localScale.z);
            }
        }
    }
}
