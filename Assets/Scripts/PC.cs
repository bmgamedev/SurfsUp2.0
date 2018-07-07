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
	private int levelSpeed = 0;
    private int lives = 3;

    private void Awake()
    {
        levelSpeed = GameMGMT.gameManager.GetLevelSpeed(SceneManager.GetActiveScene().buildIndex);
        print("speed: " + levelSpeed);
    }

    void Start ()
    {
		m_Animator = GetComponent<Animator>();
	}

    void FixedUpdate () 
    //void Update()
    {
		//float translation = Time.deltaTime * levelSpeed;
		//transform.Translate(translation, 0, 0);

	}

	void OnTriggerEnter2D (Collider2D trigger)
    {
		if (trigger.GetComponent<Collider2D>().tag == "Finish")
        {
            Scene curScene = SceneManager.GetActiveScene();
			//if (shellCount < maxShells){
			//	Application.LoadLevel ("noshells");
			//} else if (Application.loadedLevelName != "5"){
            /*if (curScene != GameMGMT.gameManager.finalScene)
            { 
                SceneManager.LoadScene(curScene.buildIndex + 1);
			}
            else
            {
                SceneManager.LoadScene(GameMGMT.gameManager.winScene.name);
			}*/
		}
        else if (trigger.GetComponent<Collider2D>().tag == "obstacle")
        {
            //remove a life
            if (lives == 0)
            {
                GameMGMT.gameManager.CurrentScene(SceneManager.GetActiveScene().name);
                print("wipeout scene: " + GameMGMT.gameManager.wipeoutSc);
                //print("did cur level transfer?: " + GameMGMT.gameManager.CurSceneVarTest());
                //SceneManager.LoadScene(GameMGMT.gameManager.wipeoutScene.name);
            }
            else
            {
                lives -= lives;
            }
		}
	} 

	void Update ()
    //void FixedUpdate () 
    {
        float translation = Time.deltaTime * levelSpeed;
        transform.Translate(translation, 0, 0);

        m_Animator.SetBool("isJumping", isJumping);
		m_Animator.SetBool("isDucking", isDucking);

		/*if(Input.GetButton("Jump"))
        {
			Animator animator = GetComponent<Animator>() as Animator;
			animator.SetTrigger("isJumping");

			transform.position = new Vector3 (transform.position.x, jumpHeight, transform.position.z);
		}*/

		if(Input.GetButtonUp("Jump"))
        {
			transform.position = new Vector3 (transform.position.x, stdHeight, transform.position.z);
		}

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
