using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBooks : MonoBehaviour, Interactibles
{
    public event Action OpenBooks;

    public void Interact()
    {
        OpenBooks();
    }
}
