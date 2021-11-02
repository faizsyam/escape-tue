using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDoor : MonoBehaviour, Interactable
{
    public event Action InputDoor;

    public void Interact()
    {
        InputDoor();
    }
}