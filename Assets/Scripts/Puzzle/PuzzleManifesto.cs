using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManifesto : MonoBehaviour, Interactibles
{
    public event Action OpenManifesto;

    public void Interact()
    {
        OpenManifesto();
    }
}
