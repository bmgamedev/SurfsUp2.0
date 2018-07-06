using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PC : MonoBehaviour {
	
	private Animator m_Animator;

	private bool isJumping;
	private bool isDucking;
	
	private float jumpHeight = 0.3f;
	private float stdHeight = -0.6f;

	private int levelSpeed;
	private string levelName;

	//private Transform m_GroundCheck;
	//public LayerMask GroundLayer;

	private int shellCount;
	private int maxShells;
	public Text countText;

	
	void Start () {
		m_Animator = GetComponent<Animator>();

		//m_GroundCheck = transform.FindChild("GroundCheck");

		countText = GetComponent<Text>();
		shellCount = 0;
		maxShells = 13;
		//SetCountText ();

		levelName = Application.loadedLevelName;
		int. TryParse(levelName, out levelSpeed);

	}

	void Update () {

		//Time.timeScale = 0.2F;
		//float translation = Time.deltaTime * 3;
		float translation = Time.deltaTime * levelSpeed;
		transform.Translate(translation, 0, 0);

	}

	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.GetComponent<Collider2D>().tag == "Finish") {
			//print ("Winner");
			if (shellCount < maxShells){
				Application.LoadLevel ("noshells");
			} else if (Application.loadedLevelName != "5"){
				Application.LoadLevel(Application.loadedLevel + 1);
			} else {
				Application.LoadLevel ("win");//load win screen;
			}
		} else if (trigger.GetComponent<Collider2D>().tag == "obstacle") {
			print ("TRIGGERED!!!!"); //move player backwards;
			this.transform.position = new Vector3 (transform.position.x-1.0f, this.transform.position.y, this.transform.position.z);
			
			//SlowDown();
			//Invoke("SpeedUp",2);
		} else if (trigger.GetComponent<Collider2D>().tag == "tsunami") {
			print ("Game Over");
			Application.LoadLevel ("wipeout");//load lose screen;
		} else if (trigger.GetComponent<Collider2D>().tag == "shell"){
			shellCount = shellCount + 1;
			print (shellCount);
			//SetCountText ();
		}
	} 

	//CONTROLS:
	//up - jump - avoid sharks
	//nothing - neutral stance
	//down - duck - avoid birds


	void FixedUpdate () 
	{

		m_Animator.SetBool("isJumping", isJumping);
		m_Animator.SetBool("isDucking", isDucking);


//		//****EXPERIMENTAL JUMP STUFF BELOW:*****
//		bool isGrounded = Physics2D.OverlapPoint (m_GroundCheck.position, GroundLayer);
//		if(Input.GetButton("Jump")){
//			print ("jump pressed");
//			Animator animator = GetComponent<Animator>() as Animator;
//
//			if(isGrounded){
//				print ("jump successful");
//				animator.SetTrigger("isJumping");
//				rigidbody2D.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
//			}
//		}


		//****WORKING JUMP CODE BELOW******

		if(Input.GetButton("Jump")){
			Animator animator = GetComponent<Animator>() as Animator;
			animator.SetTrigger("isJumping");

			this.transform.position = new Vector3 (this.transform.position.x, jumpHeight, this.transform.position.z);
		}

		if(Input.GetButtonUp("Jump")){
			this.transform.position = new Vector3 (this.transform.position.x, stdHeight, this.transform.position.z);
		}

		if(Input.GetButton("Duck")){
			Animator animator = GetComponent<Animator>() as Animator;
			animator.SetTrigger("isDucking");
		}

	}

	//void SetCountText()
	//{
	//	countText.text = "x " + shellCount.ToString ();
	//}
	
//	void SlowDown()
//	{
//		Time.timeScale = 0.3F;
//		float translation = Time.deltaTime * 1;
//		transform.Translate(translation, 0, 0);
//
//	}

//	void SpeedUp()
//	{
//		Time.timeScale = 1.0F;
//		float translation = Time.deltaTime * 2;
//		transform.Translate(translation, 0, 0);
//		
//	}

}
