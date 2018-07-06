using UnityEngine;
using System.Collections;

public class birds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float translation = Time.deltaTime * -1;
		transform.Translate(translation, 0, 0);

	}
}
