using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start ()
    {

        anim = GetComponent<Animator>();

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            anim.SetTrigger("DoorOpen");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            anim.enabled = true;
        }
    }

    //Pause animation
    void pauseAnimationEvent()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
