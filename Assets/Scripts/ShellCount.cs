using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShellCount : MonoBehaviour {
	
	private int shellCount;
	public Text countText;
	
	void Start () {

		shellCount = 0;
		SetCountText ();
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.GetComponent<Collider2D>().tag == "shell") {
			shellCount = shellCount + 1;
			SetCountText ();
		} 
	}
	
	void SetCountText()	{

        countText.text = "x " + shellCount.ToString () + "/13";
	}
	
}
