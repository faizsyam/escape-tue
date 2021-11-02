using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSVInput : MonoBehaviour
{
    public event Action GetPSV;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetPSV();
        }
    }
}
