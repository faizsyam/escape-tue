using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChair2 : MonoBehaviour, Interactibles
{
    public event Action OpenChair2;

    public void Interact()
    {
        OpenChair2();
    }
}