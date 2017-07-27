﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kittenMeet : MonoBehaviour {
	public float meetDistance = 0.25f;

	private static string CAT = "Player";
	PlayerInventory playerInventory;
	AudioSource[] audioList;
	private Animation kitAnimation;
	private GameObject player;
	private Vector3 npcPosition;
	// Use this for initialization
	void Start () {
		audioList = GetComponents<AudioSource> ();
		player = GameObject.FindGameObjectWithTag (CAT);
		kitAnimation = player.GetComponent<Animation>();
		playerInventory = player.GetComponent<PlayerInventory>();
		npcPosition = GetComponent<Transform> ().localPosition;
	}

	bool isMeet(){
		//Debug.Log ("player x = "+ player.transform.localPosition.x );
		//Debug.Log ("npc x = "+ npcPosition.x );
		//Debug.Log ("player z = "+ player.transform.localPosition.z );
		//Debug.Log ("npc z = "+ npcPosition.z );
		float x = player.transform.localPosition.x - npcPosition.x;
		float z = player.transform.localPosition.z - npcPosition.z;

		return ((x * x + z*z) < meetDistance * (playerInventory.playerScale/2.0f)) ? true : false;
	}

	void audioAction(){
		float kitScale = playerInventory.playerScale;
		Debug.Log ("npc get : kit scale :" + kitScale);
		if (kitScale < 3.5f) {
			audioList [1].Play ();
			audioList [2].PlayDelayed (2.0f);
		}
		else if (kitScale < 5.5f) {
			audioList [0].Play ();
		}
		else {
			audioList [3].Play ();
		}
	}

	void meetAction(){
		//GetComponent<Animation>().Play("Ithcing");
		if (isMeet ()) {			
			audioAction();
		}

	}
	
	// Update is called once per frame
	void Update () {
		//0 left, 1 right, 2 middle button
		//if (Input.GetMouseButtonDown (2)) {
		if(Input.GetKeyDown(KeyCode.T)) {
			Debug.Log ("KeypadEnter 2");
			meetAction ();
		}

			
	}





	/*
	 * 
	void OnCollisionEnter(Collision collision) {
		
		Debug.Log ("OnCollisionEnter ");
		foreach (ContactPoint contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
			audioList [0].Play ();
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals (CAT)) {
			audioList [0].Play ();

			if (speakFlag) {
				audioList [1].Play ();
				audioList [2].PlayDelayed (2.0f);
				speakFlag = false;
			}

			for (int i = 0; i < 19; i++) {
				Debug.Log ("meet");
				GetComponent<Animation>().Play("Ithcing");
				kitAnimation.Play("Jump");
				kitAnimation.Play("Walk");
			}
		}
	}

	*/
}
