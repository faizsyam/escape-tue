using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public enum GameState {FreeRoam, Dialog, Door}
public class GameController : MonoBehaviour
{ 
    [SerializeField] PlayerController playerController;
    [SerializeField] FindDoor findDoor;
    [SerializeField] DoorInput doorInput;
    [SerializeField] Camera worldCamera;

    public Timecounter tc;
    bool endGame = false;
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
        doorInput.FinishRoomandEnd += StopInputDoorandEnd;
    }
     void StartInputDoor()
    {
        if (!endGame){
            state = GameState.Door;
            doorInput.gameObject.SetActive(true);
            worldCamera.gameObject.SetActive(false);
        }
        else{
            int time = tc.getTime();
            Debug.Log(time);
            PlayerPrefs.SetInt("Room1Time", time);
            PlayerPrefs.SetInt("levelEnded", 1);
            SceneManager.LoadScene("gameovermenu", LoadSceneMode.Single);
        }
    }
    void StopInputDoor()
    {
        state = GameState.FreeRoam;
        doorInput.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    void StopInputDoorandEnd()
    {
        state = GameState.FreeRoam;
        doorInput.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
        endGame = true;
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