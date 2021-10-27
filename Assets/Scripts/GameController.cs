using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState {FreeRoam, Dialog, Door}
public class GameController : MonoBehaviour
{ 
    [SerializeField] PlayerController playerController;
    [SerializeField] FindDoor findDoor;
    [SerializeField] DoorInput doorInput;
    [SerializeField] Camera worldCamera;

    GameState state;
    // Start is called before the first frame update
    void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
            
        };

        findDoor.InputDoor += StartInputDoor;
        doorInput.FinishRoom += StopInputDoor;
    }
     void StartInputDoor()
    {
        state = GameState.Door;
        doorInput.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    void StopInputDoor()
    {
        state = GameState.FreeRoam;
        doorInput.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }   
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Door)
        {
            doorInput.HandleUpdate();
        }
    }
}