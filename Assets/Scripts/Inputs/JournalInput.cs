using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInput : MonoBehaviour
{
    public event Action GetJournal;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetJournal();
        }
    }
}
