using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleArticle : MonoBehaviour, Interactibles
{
    public event Action OpenArticle;

    public void Interact()
    {
        OpenArticle();
    }
}
