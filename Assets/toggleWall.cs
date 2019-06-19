using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWall : MonoBehaviour
{
    public GameObject MovableWall;
    bool wallActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            wallActive = !wallActive;
            MovableWall.SetActive(wallActive);
        }
    }
}
