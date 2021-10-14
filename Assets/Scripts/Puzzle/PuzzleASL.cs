using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleASL : MonoBehaviour, Interactibles
{
    public event Action OpenASL;

    public void Interact()
    {
        OpenASL();
    }
}
