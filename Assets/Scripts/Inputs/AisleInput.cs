using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AisleInput : MonoBehaviour
{
    public event Action EnterAisle;
    public string inputText;
    public GameObject inputField;
    public GameObject question;

    public GameObject journal;
    public GameObject psv;
    public GameObject manifesto;

    public bool aisle;

    private void Start()
    {
        question.GetComponent<Text>().text = "Which Aisle are you going to?";
        aisle = true;
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputText = inputField.GetComponent<Text>()?.text;

            if (aisle)
            {
                if (inputText == "r9" | inputText == "R9")
                {
                    question.GetComponent<Text>().text = "What Book do you want?";
                    aisle = false;
                }
            }
            else
            {
                if (inputText == "534")
                {
                    journal.gameObject.SetActive(true);
                }
                else if (inputText == "47")
                {
                    psv.gameObject.SetActive(true);
                }
                else if (inputText == "91")
                {
                    manifesto.gameObject.SetActive(true);
                }
            }
            
            EnterAisle();
        }
    }
}
