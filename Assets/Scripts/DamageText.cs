using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class DamageText : MonoBehaviour 
{
	
	private Text talkText;
	RectTransform rt;

	// Use this for initialization
	void Awake () 
	{
		
		talkText = GetComponent<Text> ();
		rt = GetComponent<RectTransform>();   

	}

	// Update is called once per frame
	void Update () 
	{
		
		/*
		if (Input.GetKeyDown (KeyCode.F1)) {
			Debug.Log ("press f1");
			showKitContent ("∞Æƒ„√ª…Ã¡ø");
		}
		*/

	}


	public void showPopupContent(string content, float x, float y) {
		
		Debug.Log (content);
		rt.transform.position = new Vector2 (x, y);

		Debug.Log ("the text position: pos.x = " + (x) + "pos.y = " + (y));

		talkText.text = content;
	}

	
}
