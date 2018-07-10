using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Shells : MonoBehaviour {

    /*private void Awake()
    {
        if (!GameMGMT.gameManager.ReturnShellRequirements())
        {
            //print("shells not allowed");
            //GameObject.Find("countText").SetActive(false);
            //GameObject.Find("shellIcon").SetActive(false);
            //this.gameObject.SetActive(false);
        }
    }*/

    void OnTriggerEnter2D (Collider2D trigger) {

        string triggerTag = trigger.GetComponent<Collider2D>().tag;

        if (triggerTag == "Player") {
			Destroy (gameObject);
		} 
        else if (triggerTag == "GameOver")
        {
            GameMGMT.gameManager.CurrentScene(SceneManager.GetActiveScene().name);
            //print("missed a shell - Game over");
            //SceneManager.LoadScene(GameMGMT.gameManager.wipeoutScene);
        }
    }


}
