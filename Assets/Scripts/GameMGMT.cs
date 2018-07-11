using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMGMT : MonoBehaviour {

    //TODO this has nothing to do with GameMGMT but so I don't forget:
    //Redo the win screen image because the shadows are wrong and it's super annoying to look at

    public static GameMGMT gameManager;

    //player session values
    bool isFullRestart;
    bool hasShells;
    string curScene;
    int speed;

    //Scene names here to make updating easier if any scenes/scene names change - using Get...() methods for anything that needs these scene names outside of this script (e.g. PC script)
    private string startScene = "Start";
    private string firstScene = "3";
    private string finalScene = "5";
    private string wipeoutScene = "wipeout";
    private string noShellsScene = "noshells";
    private string winScene = "win";
    private string difficultySelect = "DifficultySelect";
    private string infiniteMode = "Infinite";

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

        //required for setting and updating speed of game as it goes along. SceneManager will call OnSceneLoaded() when the sceneLoaded event happens
        speed = 2;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadDifficultySelect()
    {
        //load the difficulty select menu, not the actual game
        SceneManager.LoadScene(difficultySelect);
    }

    public void StartInfiniteGame()
    {
        SceneManager.LoadScene(infiniteMode);
    }

    public void LoadClassicGame(string difficulty) //function called by the buttons on the difficulty select menu
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

    public void CurrentScene(string scene) //called by PC and Shells script to store the level that was just failed so that the player can restart just that level if applicable
    {
        curScene = scene;
    }

    public void Restart() //determine whether the player gets to restart the level or the full game
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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(startScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //used to increase the speed each time a new scene is loaded
    {
        speed++;
        print("Scene " + scene.name + " speed: " + speed);
    }

    //public int GetLevelSpeed(int loadedScene) //called by PC script to set the player speed
    public int GetLevelSpeed()
    {
        return speed;
    }

    public void SetLevelSpeed(int curSpeed)
    {
        speed = curSpeed;
    }

    public bool GetShellRequirements() //called by the DisableShells script to check if shells are required in this session
    {
        return hasShells;
    }

    public string GetFinalScene() //called by PC script
    {
        return finalScene;
    }

    public string GetWinScene() //called by PC script
    {
        return winScene;
    }

    public string GetWipeoutScene() //called by PC script
    {
        return wipeoutScene;
    }

    public string GetMissedShellScreen() //called by Shells script
    {
        return noShellsScene;
    }

    //TODO this is possibly only useful in debugging so maybe bin later - not used by any real game functionality
    public string ReturnPlayerPrefs()
    {
        return ("Shells? " + hasShells + ", Full restart? " + isFullRestart);
    }

}
