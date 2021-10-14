using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDoor : MonoBehaviour, Interactibles
{
    public event Action InputDoor;

    public void Interact()
    {
        InputDoor();
    }
}
