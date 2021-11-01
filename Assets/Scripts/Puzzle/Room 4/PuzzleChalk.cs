using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChalk : MonoBehaviour, Interactibles
{
    public event Action OpenChalk;

    public void Interact()
    {
        OpenChalk();
    }
}