using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Shells : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D trigger) {

        string triggerTag = trigger.tag;

        if (triggerTag == "Player") {
			Destroy (gameObject);
		} 
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 shellPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        Vector2 dir = shellPos - playerPos;
        //print(dir.normalized);

        if (dir.normalized.x < -0.8)
        {
            Destroy(gameObject);
            GameMGMT.gameManager.SetLevelSpeed(GameMGMT.gameManager.GetLevelSpeed() - 1);
            GameMGMT.gameManager.CurrentScene(SceneManager.GetActiveScene().name);
            print("missed a shell - Game over");
            SceneManager.LoadScene(GameMGMT.gameManager.GetMissedShellScreen());
        }
    }

}
