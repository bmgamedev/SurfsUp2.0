using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour {
	
    //TODO What the heck was this script supposed to be for?? Let's delete this in a bit unless I can figure out what purpose it serves...
    //ok so apparently this script is to stop the player getting slapped in the face multiple times by birds due to the wing flapping but the OnTrigger function is gonna need to specify it's based on the PC


        //TODO BIN THIS - moved the trigger disable to the actual bird script.
	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D trigger) {
        if (trigger.tag == "Player")
        {
        //    this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
