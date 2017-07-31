using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 catPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		Debug.Log("image catPos pos.x = " + catPos.x + "pos.y = " + catPos.y
			+ "pos.z = " + catPos.z);
		//get the screen pos
		Vector3 screenPos = Camera.main.WorldToScreenPoint(catPos);
		Debug.Log("image screenPos pos.x = " + screenPos.x + "pos.y = " + screenPos.y
			+ "pos.z = " + screenPos.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
