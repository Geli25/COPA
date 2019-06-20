using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class adjustHeight : MonoBehaviour
{
    public GameObject LeftPointer;
    VRTK_Pointer pointer;

    // Start is called before the first frame update
    void Start()
    {
        pointer = LeftPointer.GetComponent<VRTK_Pointer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
