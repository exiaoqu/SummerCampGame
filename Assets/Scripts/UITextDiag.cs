using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UITextDiag : MonoBehaviour 
{
	//private PlayerInventory playerInventory;
	//public int playerEnergy;

	private Text talkText;
	RectTransform rt;

	public int deta_x = 0;
	public int deta_y = 200;

	public float showTime = 2.0f;



	//private Vector3 catPos;
	//private Vector3 screenPos;
	//private Vector2 textPos;

	//private Vector2 kitContentPos;
	//private Vector2 npcContentPos;




	// Use this for initialization
	void Awake () 
	{
		//playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
		talkText = GetComponent<Text> ();
		rt = GetComponent<RectTransform>();   

		//Debug.Log ("press f1");
		//showKitContent ("爱你没商量");

	

		//gameObject.SetActive (false);
		//textPos = new Vector2 (screenPos.x, screenPos.y);

		//Debug.Log ("pos.x = " + rt.transform.position.x + "pos.y = " + rt.transform.position.y);
	}

	// Update is called once per frame
	void Update () 
	{
		
		/*
		if (Input.GetKeyDown (KeyCode.F1)) {
			Debug.Log ("press f1");
			showKitContent ("爱你没商量");
		}
		*/

	}

	private Vector2 getObjectScreenPos(string tag){
		Vector3 catPos = GameObject.FindGameObjectWithTag (tag).transform.position;
		Debug.Log("catPos pos.x = " + catPos.x + "pos.y = " + catPos.y
			+ "pos.z = " + catPos.z);
		//get the screen pos
		Vector3 screenPos = Camera.main.WorldToScreenPoint(catPos);
		Debug.Log("screenPos pos.x = " + screenPos.x + "pos.y = " + screenPos.y
			+ "pos.z = " + screenPos.z);

		return new Vector2 (screenPos.x, screenPos.y);
	}

	public void showKitContent(string content) {
		
		Debug.Log (content);
		Vector2 kitPos = getObjectScreenPos ("Player");
		rt.transform.position = new Vector2 (kitPos.x + deta_x, kitPos.y + deta_y);

		Debug.Log ("the text position: pos.x = " + (kitPos.x + deta_x) + "pos.y = " + (kitPos.y + deta_y));

		talkText.text = content;

		//gameObject.SetActive (false);
	}

	public void showNpcContent(string content) {

		Debug.Log (content);
		Vector2 kitPos = getObjectScreenPos ("kitNpc");
		rt.transform.position = new Vector2 (kitPos.x + deta_x, kitPos.y + deta_y);

		Debug.Log ("the text position: pos.x = " + (kitPos.x + deta_x) + "pos.y = " + (kitPos.y + deta_y));

		talkText.text = content;

		//gameObject.SetActive (false);
	}

	
	// Update is called once per frame
	/*
	void Update () 
	{
		if (time != -1) {
			time++;
		}

		playerEnergy = playerInventory.collectedEnergy;
		//talkText.text = playerEnergy.ToString ();
		talkText.text = "大王，我错了";

		Debug.Log("pos.x = " + rt.transform.position.x + "pos.y = " + rt.transform.position.y
			+ "pos.z = " + rt.transform.position.z);
		rt.sizeDelta = new Vector2 (200, 100);
		rt.transform.position = new Vector2 (x + time* deta, y + time* deta);
		Debug.Log("pos.x = " + rt.transform.position.x + "pos.y = " + rt.transform.position.y
			+ "pos.z = " + rt.transform.position.z);
		
		if (Input.GetKeyDown (KeyCode.F1)) {
			Debug.Log("pos.x = " + rt.transform.position.x + "pos.y = " + rt.transform.position.y
				+ "pos.z = " + rt.transform.position.z);
			
			//rt.transform.position = new Vector2 (500, 200);
			Debug.Log("pos.x = " + rt.transform.position.x + "pos.y = " + rt.transform.position.y
				+ "pos.z = " + rt.transform.position.z);

			time = -1;
		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			Debug.Log("pos.x = " + rt.transform.position.x + "pos.y = " + rt.transform.position.y
				+ "pos.z = " + rt.transform.position.z);

			rt.transform.position = new Vector2 (300, 300);
			Debug.Log("pos.x = " + rt.transform.position.x + "pos.y = " + rt.transform.position.y
				+ "pos.z = " + rt.transform.position.z);
			time = 0;
		}



	}
	*/
}
