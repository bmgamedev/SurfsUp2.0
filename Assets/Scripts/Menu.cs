﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Menu : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method. (include IPointerEnterHandler in this list if allowing mouse pointer)
{

    //TODO should this script get merged into GameMGMT?


    public Text descriptionField;

    //Get rid of mouse functionality - causes confusion if they move the mouse while on a menu
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	/*public void StartGame(string name){
        SceneManager.LoadScene(name);
    }*/

    //for future reference: if allowing mouse pointer, use the following function instead of/along with OnSelect:
    /*public void OnPointerEnter(PointerEventData eventData){}*/
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

