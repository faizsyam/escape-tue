using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInput : MonoBehaviour
{
    public event Action FinishRoom;
    public string inputText;
    public GameObject inputField;
    public GameObject door;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputText = inputField.GetComponent<Text>()?.text;
            if (inputText == "1234")
            {
                door.gameObject.SetActive(false);
            }

            FinishRoom();
        }
    }
}