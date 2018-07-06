using UnityEngine;
using System.Collections;

public class PC_Cam : MonoBehaviour {
	

	public Transform target;
	static PC_Cam instance = null;

	void Awake()
	{
		if (instance != null) {
			Destroy (gameObject);
		}
	}
	
	void Update () 
	{

		transform.position  = new Vector3 (target.position.x+3.6f, transform.position.y, transform.position.z);

	}

}