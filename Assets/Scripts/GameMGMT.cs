using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMGMT : MonoBehaviour {

    public static GameMGMT gameManager;

    //enum Mode { classic, infinite };
    //enum Difficulty {  relaxing, challenging, hardcore };

    //player session values
    bool isFullRestart;
    bool hasShells;
    string curScene;

    /*public Scene firstScene;// = SceneManager.GetSceneByName("03"); 
    public Scene finalScene;// = SceneManager.GetSceneByName("05"); 
    public Scene wipeoutScene;// = SceneManager.GetSceneByName("wipeout");
    public Scene winScene;// = SceneManager.GetSceneByName("win");*/

    public string firstSc = "03";
    public string lastSc = "05";
    public string wipeoutSc = "wipeout";
    public string winSc = "win";

    void Awake()
    {
        //a sort of singleton:
        //put the GameMAnager prefab in all scenes and this will remove any we don't need 
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject); //the game object this script is attached to will persist over scenes
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }

        /*firstScene = SceneManager.GetSceneByName("03"); //TODO update scene naming please - requires a better solution to speed increase
        finalScene = SceneManager.GetSceneByName("05"); //TODO will be renamed when all the scenes are renamed. Don't forget to update this if more scenes are added
        wipeoutScene = SceneManager.GetSceneByName("wipeout");
        winScene = SceneManager.GetSceneByName("win");*/

        //curScene = firstScene.name; //so that it's never null and crashes the game but it can be overwritten later
        curScene = "01"; //deliberately wrong for debugging...

        //print("fs: " + firstScene.name + "ls: " + finalScene.name + "wo: " + wipeoutScene.name + "w: " + winScene.name);
        print("fs: " + firstSc + "ls: " + lastSc + "wo: " + wipeoutSc + "w: " + winSc);
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

        //SceneManager.LoadScene(firstScene.name);
    }

    public void CurrentScene(string scene)
    {
        curScene = scene;
    }

    public void Restart()
    {
        if (isFullRestart)
        {
            //SceneManager.LoadScene(firstScene.name);
        }
        else
        {
            SceneManager.LoadScene(curScene);
        }
    }

    public void QuitGame()
    {

    }

    public int GetLevelSpeed(int loadedScene)
    {
        int speed;

        Scene firstScene = SceneManager.GetSceneByName(firstSc);

        if(loadedScene == firstScene.buildIndex)
        {
            speed = 3;
        }
        else if (loadedScene == firstScene.buildIndex + 1)
        {
            speed = 4;
        }
        else if (loadedScene == firstScene.buildIndex + 2)
        {
            speed = 5;
        }
        else
        {
            speed = 3;
        }

        return speed;
    }

    /*public Scene WipeoutVarTest()
    {
        wipeoutScene = SceneManager.GetSceneByName("wipeout");

        return wipeoutScene;
    }

    public string CurSceneVarTest()
    {
        return curScene;
    }*/
}
