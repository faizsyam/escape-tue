using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAisle : MonoBehaviour, Interactibles
{
    public event Action InputAisle;

    public void Interact()
    {
        InputAisle();
    }
}
