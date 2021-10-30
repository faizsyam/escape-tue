using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkInput : MonoBehaviour
{
    public event Action GetChalk;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetChalk();
        }
    }
}
