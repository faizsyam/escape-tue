using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Chalk, Chair, Chair2}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;

    [SerializeField] PuzzleChalk puzzlechalk;
    [SerializeField] ExitChalk exitchalk;
    [SerializeField] PuzzleChair puzzlechair;
    [SerializeField] ExitChair exitchair;
    [SerializeField] PuzzleChair2 puzzlechair2;
    [SerializeField] ExitChair2 exitchair2;
    

    GameState state;

    private void Start()
    {
        puzzlechalk.OpenChalk += SolveChalk;
        exitchalk.EndChalk += StopChalk;

        puzzlechair.OpenChair += SolveChair;
        exitchair.EndChair += StopChair;

        puzzlechair2.OpenChair2 += SolveChair2;
        exitchair2.EndChair2 += StopChair2;
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
   
    void SolveChair()
    {
        state = GameState.Chair;
        exitchair.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    
    void StopChair()
    {
        state = GameState.FreeRoam;
        exitchair.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    
    void SolveChair2()
    {
        state = GameState.Chair2;
        exitchair2.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    
    void StopChair2()
    {
        state = GameState.FreeRoam;
        exitchair2.gameObject.SetActive(false);
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
        else if (state == GameState.Chair)
        {
            exitchair.HandleUpdate();
        }
        else if (state == GameState.Chair2)
        {
            exitchair2.HandleUpdate();
        }
    }
}
