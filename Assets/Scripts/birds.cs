using UnityEngine;
using System.Collections;

public class birds : MonoBehaviour {

	void Update () {
	
		float translation = Time.deltaTime * -1;
		transform.Translate(translation, 0, 0);

        //TODO if directly above a shark, temporarily raise them on the y-axis? stops collisions that the player can't avoid...

	}
}
