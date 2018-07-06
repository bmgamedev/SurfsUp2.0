using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void DifficultyMenu()
    {
        //disable first menu
        //show difficulty menu
    }

	public void StartGame(string name){
        SceneManager.LoadScene(name);
	}

}

