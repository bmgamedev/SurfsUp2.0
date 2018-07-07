using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMGMT : MonoBehaviour {

    public static GameMGMT gameManager;

    //enum Mode { classic, infinite }; //TODO delete these if never used
    //enum Difficulty {  relaxing, challenging, hardcore };

    //player session values
    bool isFullRestart;
    bool hasShells;
    string curScene;

    public string firstScene = "03";
    public string finalScene = "05";
    public string wipeoutScene = "wipeout";
    public string winScene = "win";

    void Awake()
    {
        //Singleton...ish...
        //put the GameManager prefab in all scenes and this will remove any we don't need 
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
        
        curScene = "01"; //deliberately wrong for debugging... 
        //TODO: change curScene to firstScene when everything is working to ensure it can't crash the game if something goes wrong, it'll just enforce a full game restart instead which is less jarring
    }

    public void LoadClassicGame(string difficulty)
    {
        if (difficulty == "relaxing")
        {
            isFullRestart = false;
            hasShells = false;
        }
        else if (difficulty == "challenging")
        {
            isFullRestart = false;
            hasShells = true;
        }
        else if (difficulty == "hardcore")
        {
            isFullRestart = true;
            hasShells = true;
        }
        else
        {
            print("we got a problem - fix the difficulty selection process. Properties have been set to relaxing by default");
            isFullRestart = false;
            hasShells = false;
        }

        SceneManager.LoadScene(firstScene);
    }

    public void CurrentScene(string scene)
    {
        curScene = scene;
    }

    public void Restart()
    {
        if (isFullRestart)
        {
            SceneManager.LoadScene(firstScene);
        }
        else
        {
            SceneManager.LoadScene(curScene);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public int GetLevelSpeed(int loadedScene)
    {
        int speed;

        int firstSceneBI = SceneManager.GetSceneByName(firstScene).buildIndex;

        if(loadedScene == firstSceneBI)
        {
            speed = 3;
        }
        else if (loadedScene == firstSceneBI + 1)
        {
            speed = 4;
        }
        else if (loadedScene == firstSceneBI + 2)
        {
            speed = 5;
        }
        else
        {
            speed = 3;
        }

        return speed;
    }
}
