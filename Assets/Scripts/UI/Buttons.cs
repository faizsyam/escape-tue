using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void play_menu(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
