using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateKitScale : MonoBehaviour {
	//private Vector3 scale; 
	PlayerInventory playerInventory;

	// Use this for initialization
	void Start () {
		//scale = new Vector3(transform.localScale.x,transform.localScale.y, transform.localScale.z);
		playerInventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInventory>();

	}
	
	// Update is called once per frame
	void Update () {
		/*
	add by eweilzh
	*/
		//Debug.Log("the kit scale is " + transform.localScale.x);
		/*
		transform.localScale = new Vector3(transform.localScale.x*playerInventory.playerScale, 
			transform.localScale.y*playerInventory.playerScale, 
			transform.localScale.z*playerInventory.playerScale);
			*/

	}
}
