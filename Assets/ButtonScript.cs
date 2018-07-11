using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    private GameMGMT gameManager;

    void Start()
    {
        gameManager = GameMGMT.gameManager;
    }

    public void LoadMainMenu()
    {
        gameManager.LoadMainMenu();
    }

    public void Restart()
    {
        gameManager.Restart();
    }

    public void LoadClassicGame(string difficulty)
    {
        gameManager.LoadClassicGame(difficulty);
    }

    public void LoadDifficultySelect()
    {
        //load the difficulty select menu, not the actual game
        gameManager.LoadDifficultySelect();
    }

    public void StartInfiniteGame()
    {
        gameManager.StartInfiniteGame();
    }

}