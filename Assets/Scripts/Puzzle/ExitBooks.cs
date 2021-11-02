using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBooks : MonoBehaviour
{
    public event Action EndBooks;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndBooks();
        }
    }

}
