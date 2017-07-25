using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour {

	PlayerInventory playerInventory;
	public GameObject getEnergy;

	public float destryTime = 0.1f;
	public float energy_step = 0.05f;

	public float maxChangeSize = 4.0f;
	public float minChangeSize = 1.0f;

	private static string CAT = "Player";
	private static string ENERGY_SMALL_FLOWER = "smallFlower";
	private static string ENERGY_BIG_FLOWER = "bigFlower";
	private static string ENERGY_TOADSTOOL = "toadsTool";
	private static string ENERGY_BUTTERFLY = "butterflyObj";
	private float playerScale;
	private bool changeFlag = false;

	private Transform playerTransform;


	void Start(){
		playerInventory = GameObject.FindGameObjectWithTag (CAT).GetComponent<PlayerInventory>();
		playerTransform = GameObject.FindGameObjectWithTag (CAT).GetComponent<Transform>();
	}

	void activeEffects(Collider other) {
		Debug.Log("audio play");
		GetComponent<AudioSource>().Play ();
		Debug.Log("destory mush");
		Destroy(gameObject, destryTime);
		//gameObject.SetActive (false);
		Instantiate(getEnergy, other.transform.position, other.transform.rotation); 
	}

	void updatePlayerScale() {
		if (playerInventory.collectedEnergy % 2 == 0) {			
			if (playerInventory.playerScale < maxChangeSize) {				
				Debug.Log(" updatePlayerScale: playerScale:" + playerScale);
				playerTransform.localScale = new Vector3(playerInventory.playerScale, 
					playerInventory.playerScale, 
					playerInventory.playerScale);

				/*
				    playerTransform.localScale = new Vector3(playerTransform.localScale.x*playerScale, 
					playerTransform.localScale.y*playerScale, 
					playerTransform.localScale.z*playerScale);
					*/
			}
		}
	}

	void addEnergy() {
		if (gameObject.tag.Equals (ENERGY_SMALL_FLOWER) || gameObject.tag.Equals (ENERGY_TOADSTOOL) ) {
			playerInventory.playerScale = playerInventory.playerScale + energy_step;
			Debug.Log("current playerScale:" + playerScale);
			playerInventory.collectedEnergy++;
			Debug.Log("collectedEnergy: " + playerInventory.collectedEnergy + " playerScale:" + playerInventory.playerScale);
		}


		if (gameObject.tag.Equals (ENERGY_BIG_FLOWER) || gameObject.tag.Equals (ENERGY_BUTTERFLY)) {
			playerInventory.playerScale = playerInventory.playerScale + energy_step;
			Debug.Log("current playerScale:" + playerScale);
			playerInventory.collectedEnergy++;
			Debug.Log("collectedEnergy: " + playerInventory.collectedEnergy + " playerScale:" + playerInventory.playerScale);
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.tag.Equals(CAT)) {
			
			activeEffects (other);

			updatePlayerScale ();

			addEnergy ();



		}

	}

}
