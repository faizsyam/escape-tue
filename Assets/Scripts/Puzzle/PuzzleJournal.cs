using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleJournal : MonoBehaviour, Interactibles
{
    public event Action OpenJournal;

    public void Interact()
    {
        OpenJournal();
    }
}
