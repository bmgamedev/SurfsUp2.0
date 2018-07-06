using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Menu : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
{

    public Text descriptionField;

	public void StartGame(string name){
        SceneManager.LoadScene(name);
    }

    public void OnSelect(BaseEventData eventData)
    {
        string button = this.name;
        string text;

        switch (button)
        {
            case "Relaxed":
                text = "Relaxed Mode:$ $For those who just want to enjoy the game. There are no shells to collect. Wipeouts will only require restarting the current level.";
                descriptionField.text = text.Replace('$', '\n');
                break;
            case "Challenging":
                text = "Challenging Mode:$ $For those who like to be frustrated. All shells need to be collected to progress to the next level. Wipeouts or failure to collect all the shells will only require restarting from the start of your current level.";
                descriptionField.text = text.Replace('$', '\n');
                break;
            case "Hardcore":
                text = "Hardcore Mode:$ $For those who like to be frustrated. All shells need to be collected to progress to the next level. Wipeouts or failure to collect all the shells requires restarting from level 1 again, regardless of progress.";
                descriptionField.text = text.Replace('$', '\n');
                break;
            default:
                descriptionField.text = "";
                break;
        }
    }

}


/*
 for future use:



    string text = "Relaxed Mode:$ $For those who just want to enjoy the game. There are no shells to collect. Wipeouts will only require restarting the current level."
    text = text.Replace('$','\n');

    string text = "Challenging Mode:$ $For those who like to be frustrated. All shells need to be collected to progress to the next level. Wipeouts or failure to collect all the shells will only require restarting from the start of your current level."
    text = text.Replace('$','\n');

     string text = "Hardcore Mode:$ $For those who like to be frustrated. All shells need to be collected to progress to the next level. Wipeouts or failure to collect all the shells requires restarting from level 1 again, regardless of progress."
    text = text.Replace('$','\n');
     
     */

