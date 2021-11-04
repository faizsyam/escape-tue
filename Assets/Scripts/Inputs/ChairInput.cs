using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairInput : MonoBehaviour
{
    public event Action GetChair;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetChair();
        }
    }
}
