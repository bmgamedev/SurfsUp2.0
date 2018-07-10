using UnityEngine;
using System.Collections;

public class birds : MonoBehaviour {

    float flightSpeed = -1.0f;

	void Update () {
	
		float translation = Time.deltaTime * flightSpeed;
		transform.Translate(translation, 0, 0);

        //TODO if directly above a shark, temporarily raise them on the y-axis? stops collisions that the player can't avoid...
        //TODO in infinite mode, where shells are optional, give flightSpeed a range (say between -1.5 and -0.5, but tweak these to be sure) so that the birds are more dynamic. 
        //If they overlap a shall then the player will just need to not get that one shell or risk it, their choice.

        //TODO some of the birds in classic mode have the script on twice which is doubling the flight speed and it looks pretty decent - 
                //leave it on twice (ideally not...), spend the time tweaking certain birds to go faster, or leave them all the same speed with the script on once?

    }

    //Disable the collider once the bird has hit the player to stop the wing flapping result in another hit from the same bird (seems unfair to slap the player repeatedly...)
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
