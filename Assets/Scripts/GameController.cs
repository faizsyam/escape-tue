using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Journal, ASL, Article, Books, PSV, Manifesto, Aisle, Door }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;

    [SerializeField] PuzzleASL puzzleasl;
    [SerializeField] PuzzleArticle puzzlearticle;
    [SerializeField] PuzzleBooks puzzlebooks;
    [SerializeField] PuzzleJournal puzzlejournal;
    [SerializeField] PuzzlePSV puzzlepsv;
    [SerializeField] PuzzleManifesto puzzlemanifesto;

    [SerializeField] ExitASL exitasl;
    [SerializeField] ExitArticle exitarticle;
    [SerializeField] ExitBooks exitbooks;
    [SerializeField] ExitJournal exitjournal;
    [SerializeField] ExitPSV exitpsv;
    [SerializeField] ExitManifesto exitmanifesto;

    [SerializeField] FindAisle findaisle;
    [SerializeField] FindDoor finddoor;

    [SerializeField] AisleInput aisleinput;
    [SerializeField] DoorInput doorinput;

    GameState state;

    private void Start()
    {
        puzzleasl.OpenASL += SolveASL;
        puzzlearticle.OpenArticle += SolveArticle;
        puzzlebooks.OpenBooks += SolveBooks;
        puzzlejournal.OpenJournal += SolveJournal;
        puzzlepsv.OpenPSV += SolvePSV;
        puzzlemanifesto.OpenManifesto += SolveManifesto;
        
        exitasl.EndASL += StopASL;
        exitarticle.EndArticle += StopArticle;
        exitbooks.EndBooks += StopBooks;
        exitjournal.EndJournal += StopJournal;
        exitpsv.EndPSV += StopPSV;
        exitmanifesto.EndManifesto += StopManifesto;

        findaisle.InputAisle += StartInputAisle;
        finddoor.InputDoor += StartInputDoor;

        aisleinput.EnterAisle += StopInputAisle;
        doorinput.FinishRoom += StopInputDoor;
    }

    void SolveJournal()
    {
        state = GameState.Journal;
        exitjournal.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    void SolveASL()
    {
        state = GameState.ASL;
        exitasl.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    void SolvePSV()
    {
        state = GameState.PSV;
        exitpsv.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    void SolveArticle()
    {
        state = GameState.Article;
        exitarticle.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    void SolveBooks()
    {
        state = GameState.Books;
        exitbooks.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    void SolveManifesto()
    {
        state = GameState.Manifesto;
        exitmanifesto.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }

    void StartInputAisle()
    {
        state = GameState.Aisle;
        aisleinput.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }
    void StartInputDoor()
    {
        state = GameState.Door;
        doorinput.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }

    void StopJournal()
    {
        state = GameState.FreeRoam;
        exitjournal.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    void StopASL()
    {
        state = GameState.FreeRoam;
        exitasl.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    void StopPSV()
    {
        state = GameState.FreeRoam;
        exitpsv.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    void StopArticle()
    {
        state = GameState.FreeRoam;
        exitarticle.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    void StopBooks()
    {
        state = GameState.FreeRoam;
        exitbooks.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    void StopManifesto()
    {
        state = GameState.FreeRoam;
        exitmanifesto.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }

    void StopInputAisle()
    {
        state = GameState.FreeRoam;
        aisleinput.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    void StopInputDoor()
    {
        state = GameState.FreeRoam;
        doorinput.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Journal)
        {
            exitjournal.HandleUpdate();
        }
        else if (state == GameState.ASL)
        {
            exitasl.HandleUpdate();
        }
        else if (state == GameState.Article)
        {
            exitarticle.HandleUpdate();
        }
        else if (state == GameState.Books)
        {
            exitbooks.HandleUpdate();
        }
        else if (state == GameState.PSV)
        {
            exitpsv.HandleUpdate();
        }
        else if (state == GameState.Manifesto)
        {
            exitmanifesto.HandleUpdate();
        }
        else if (state == GameState.Aisle)
        {
            aisleinput.HandleUpdate();
        }
        else if (state == GameState.Door)
        {
            doorinput.HandleUpdate();
        }
    }
}
