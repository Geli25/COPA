﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class worldReset : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
