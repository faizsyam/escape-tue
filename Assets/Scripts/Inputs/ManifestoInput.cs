using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManifestoInput : MonoBehaviour
{
    public event Action GetManifesto;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetManifesto();
        }
    }
}
