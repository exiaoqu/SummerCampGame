using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour {

	//PlayInventory playInventory;

	void Start(){
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			gameObject.SetActive (false);
		}
	}

}
