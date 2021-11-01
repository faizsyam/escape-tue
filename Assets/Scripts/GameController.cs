using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Chalk}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;

    [SerializeField] PuzzleChalk puzzlechalk;
    [SerializeField] ExitChalk exitchalk;
    

    GameState state;

    private void Start()
    {
        puzzlechalk.OpenChalk += SolveChalk;
        exitchalk.EndChalk += StopChalk;
    }
    
    void SolveChalk()
    {
        state = GameState.Chalk;
        exitchalk.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    
    void StopChalk()
    {
        state = GameState.FreeRoam;
        exitchalk.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
   

    private void Update()
    {

        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
		else if (state == GameState.Chalk)
        {
            exitchalk.HandleUpdate();
        }
       
    }
}
