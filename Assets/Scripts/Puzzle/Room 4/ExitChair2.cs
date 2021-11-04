using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitChair2 : MonoBehaviour
{
    public event Action EndChair2;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndChair2();
        }
    }

}
