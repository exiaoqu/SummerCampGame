using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kittenMeet : MonoBehaviour {
	public float meetDistance = 0.25f;

    public float responseDelay = 1.0f;

	private static string CAT = "Player";
	PlayerInventory playerInventory;
	AudioSource[] audioList;
	private Animation kitAnimation;
	private GameObject player;
	private Vector3 npcPosition;

	UITextDiag textDiag;
	private GameObject textObj;
    private  int i = 0;

    private  string[] kitTalks = { "大哥! Good Morning..." ,
        "呜！呜！呜(心伤)...", };
    private  string[] kitNpcTalks = {
        "小样, 滚!",
        ""};
    
    // Use this for initialization
    void Start () {
		audioList = GetComponents<AudioSource> ();
		player = GameObject.FindGameObjectWithTag (CAT);
		//kitAnimation = player.GetComponent<Animation>();
		playerInventory = player.GetComponent<PlayerInventory>();
		npcPosition = GetComponent<Transform> ().localPosition;

       


        textObj = GameObject.FindGameObjectWithTag ("DiagText");
        textObj.SetActive (false);
        textDiag = textObj.GetComponent<UITextDiag>();
        //textObj.SetActive(true);
        //textObj = GameObject.Find("Canvas/Text");
        //string aa = textObj.GetComponentInChildren(System.Text).GetComponent<UnityEngine.UI.Text> ().text;
        //Debug.Log (aa);
        //string aa = textObj.GetComponent<UnityEngine.UI.Text> ().text;
        //Debug.Log (GameObject.Find("Canvas/Text").GetComponent<UnityEngine.UI.Text>().text);
        //textDiag = textObj.GetComponent<UITextDiag> ();

       

    }

	bool isNear(){
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
			audioAction();
        

	}

    void talk ()
    {
        if(kitTalks[i] != null)
        {
            textDiag.showKitContent(kitTalks[i]);
            StartCoroutine("NpcResponse");
        }
       
    }
	
	// Update is called once per frame
	void Update () {

    // distance judgement
    if (isNear())
    {
            // near do
            if (Input.GetKeyDown(KeyCode.T))
            {
                audioAction();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (0 == i) { textObj.SetActive(true); }
                talk();
            }
        }
    else
    {
            // far do
            i = 0;
            textObj.SetActive(false);

        }





        //0 left, 1 right, 2 middle button
        //if (Input.GetMouseButtonDown (2)) {
        

        /*
		if (Input.GetKeyDown (KeyCode.R)) {
            Debug.Log("KeypadEnter 2");
            //showText ();
           
            //textDiag.showKitContent("爱你没音量111");

            textDiag.showKitContent(kitNpcTalks[i]);

            //textObj.SetActive (false);
            //textObj = GameObject.Find("C
        }

		if (Input.GetKeyDown (KeyCode.Q)) {
            Debug.Log("KeypadEnter 3");
            textObj.SetActive (false);
			textDiag = textObj.GetComponent<UITextDiag> ();
			textDiag.showNpcContent("滚滚滚滚滚！！！！");
			textObj.SetActive (true);
			//textObj = GameObject.Find("C
		}

        */


    }

	void showText(){
		
		GUI.Label (new Rect (Screen.width * 0.5f, Screen.height * 0.5f, 100, 30), "dffdf");
	}


    IEnumerator NpcResponse()
    {
        yield return new WaitForSeconds(responseDelay);
        if (kitNpcTalks[i] != null)
        {
            textDiag.showNpcContent(kitNpcTalks[i++]);
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter ");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay ");
    }

    */


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
