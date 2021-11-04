using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChair : MonoBehaviour, Interactibles
{
    public event Action OpenChair;

    public void Interact()
    {
        OpenChair();
    }
}