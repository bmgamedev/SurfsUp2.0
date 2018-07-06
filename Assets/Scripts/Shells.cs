using UnityEngine;
using System.Collections;

public class Shells : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.GetComponent<Collider2D>().tag == "Player") {
			Destroy (gameObject);
		} 
	}


}
