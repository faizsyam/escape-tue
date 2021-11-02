using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitManifesto : MonoBehaviour
{
    public event Action EndManifesto;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndManifesto();
        }
    }

}
