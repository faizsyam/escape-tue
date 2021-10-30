using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitChalk : MonoBehaviour
{
    public event Action EndChalk;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndChalk();
        }
    }

}
