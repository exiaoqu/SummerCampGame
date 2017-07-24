using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour {

	//PlayInventory playInventory;
	public GameObject eatMush;

	void Start(){
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//gameObject.SetActive (false);
			Debug.Log("audio play");
			GetComponent<AudioSource>().Play ();
			Debug.Log("destory mush");
			Destroy(gameObject, 0.1f);
			Instantiate(eatMush, other.transform.position, other.transform.rotation); 


		}
	}

}
