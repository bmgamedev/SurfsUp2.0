using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PC : MonoBehaviour {
	
	private Animator m_Animator;

	private bool isJumping; //TODO work out what's going on and why the animator code is all disjointed
	private bool isDucking;
	private float jumpHeight = 0.3f;
	private float stdHeight = -0.6f;
	private int levelSpeed;
    private int lives = 3;

    private void Awake()
    {
        levelSpeed = GameMGMT.gameManager.GetLevelSpeed(SceneManager.GetActiveScene().buildIndex);
        //print("speed: " + levelSpeed); //for debugging
        //print("lives: " + lives); //for debugging
        print(GameMGMT.gameManager.ReturnPlayerPrefs()); //for debugging
    }

    void Start ()
    {
		m_Animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D trigger)
    {
		if (trigger.GetComponent<Collider2D>().tag == "Finish")
        {
            string curScene = SceneManager.GetActiveScene().name;
            int curSceneBI = SceneManager.GetSceneByName(curScene).buildIndex;

            if (curScene != GameMGMT.gameManager.finalScene)
            { 
                SceneManager.LoadScene(curSceneBI + 1);
			}
            else
            {
                SceneManager.LoadScene(GameMGMT.gameManager.winScene);
			}
		}
        else if (trigger.GetComponent<Collider2D>().tag == "obstacle")
        {
            print("hit obstacle");

            //remove a life
            if (lives == 0)
            {
                GameMGMT.gameManager.CurrentScene(SceneManager.GetActiveScene().name);
                print("game over");
                //SceneManager.LoadScene(GameMGMT.gameManager.wipeoutScene);
            }
            else
            {
                lives--;
                print("current lives: " + lives);
            }
		}
	} 

	void Update ()
    {
        float translation = Time.deltaTime * levelSpeed;
        transform.Translate(translation, 0, 0);

        m_Animator.SetBool("isJumping", isJumping);
		m_Animator.SetBool("isDucking", isDucking);

		if(Input.GetButtonUp("Jump"))
        {
			transform.position = new Vector3 (transform.position.x, stdHeight, transform.position.z);
		}

        //TODO stop the ducking animation showing whilst jumping - has no impact on gameplay but it's annoying to look at 
		if(Input.GetButton("Duck"))
        {
			Animator animator = GetComponent<Animator>() as Animator;
			animator.SetTrigger("isDucking");
		}
        else if (Input.GetButton("Jump"))
        {
            Animator animator = GetComponent<Animator>() as Animator;
            animator.SetTrigger("isJumping");

            transform.position = new Vector3(transform.position.x, jumpHeight, transform.position.z);
        }
    }

}
