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
    int speed;

    public string firstScene = "3";
    public string finalScene = "5";
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

        //TODO the following are just to assist whilst building the game, should probably delete once game is finished:
        isFullRestart = false;
        hasShells = true;

        speed = 2;
        SceneManager.sceneLoaded += OnSceneLoaded;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //print("OnSceneLoaded: " + scene.name);
        speed++;
    }

    public int GetLevelSpeed(int loadedScene)
    {
        /*int speed;

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
        }*/

        //int firstLevel = int.Parse(firstScene); //TODO need a better system than using level names for speed. Also why does using Build Index result in -1 for the first level once you reach levels 4 and 5??

        //int speed = 3 + (loadedScene - firstLevel);
        //print("speed 3 + (" + loadedScene + " - " + firstLevel + ")");
        //print("so total GM speed = " + speed);

        return speed;
    }

    public bool ReturnShellRequirements()
    {
        return hasShells;
    }

    //TODO this is possibly only useful in debugging so maybe bin later
    public string ReturnPlayerPrefs()
    {
        return ("Shells? " + hasShells + ", Full restart? " + isFullRestart);
    }

}
