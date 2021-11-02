using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePSV : MonoBehaviour, Interactibles
{
    public event Action OpenPSV;

    public void Interact()
    {
        OpenPSV();
    }
}
