using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public Transform target;

	private int levelSpeed;
	private string levelName;
	
	void Start () {
	
		levelName = Application.loadedLevelName;
		int. TryParse(levelName, out levelSpeed);

	}

	void Update () {

		float translation = Time.deltaTime * levelSpeed;
		transform.Translate(translation, 0, 0);

	}
}
