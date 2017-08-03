using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kittenMeet : MonoBehaviour {
	public float meetDistance = 0.25f;

    public float responseDelay = 3.5f;
    public int changeTalkLevel = 4;

	private static string CAT = "Player";
	PlayerInventory playerInventory;
	AudioSource[] audioList;
	private Animation kitAnimation;
	private GameObject player;
	private Vector3 npcPosition;

	UITextDiag textDiag;
	private GameObject textObj;
    private  int i = 0;

    private  string[] kitTalks = { "猫哥， Good Morning..." ,
        "呜呜呜...！走看瞧！" };
    private  string[] kitNpcTalks = {
        "小东西，走开！",
        ""};

    private string[] kitTalks2 = { "小东西，又见面了" ,
        "哼，小样! 哥的世界你不懂..."};
    private string[] kitNpcTalks2 = {
        "哟，我的天，你吃什么长这么快！" ,
        ""};
    /*

猫哥， Good Morning
小东西，走开！
哟，瞧不起我，走看瞧

小东西，又见面了
哟，我的天，你吃什么长这么快
哼，小样。哥的世界你不懂的 
 

     */

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
        //float kitScale = playerInventory.playerScale;
        //Debug.Log ("npc get : kit scale :" + kitScale);
        //if (kitScale < 3.5f) {
        if (playerInventory.getCurrentLevel() < changeTalkLevel)
        {
            audioList[0].Play();
            //audioList[2].PlayDelayed(2.0f);
        }
		else {
			audioList[1].Play();
		}
       
	}

	void meetAction(){
			audioAction();
        

	}

    void talk ()
    {
        StartCoroutine("NpcResponse");
        /*
        if (playerInventory.getCurrentLevel() < changeTalkLevel)
        {
            if (kitTalks[i] != null)
            {
                textDiag.showKitContent(kitTalks[i]);
                StartCoroutine("NpcResponse");
            }
        }
        else
        {
            if (kitTalks2[i] != null)
            {
                textDiag.showKitContent(kitTalks2[i]);
                StartCoroutine("NpcResponse");
            }
        }
       */
       
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
                if (0 == i) { textObj.SetActive(true); }
                talk();

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
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            
            if (playerInventory.getCurrentLevel() < changeTalkLevel)
            {
                if (kitTalks[i] == null || kitNpcTalks[i] == null)
                {
                    break;
                }

                textDiag.showKitContent(kitTalks[i]);            
                yield return new WaitForSeconds(responseDelay);
                textDiag.showNpcContent(kitNpcTalks[i++]);
                yield return new WaitForSeconds(1f);

            }
            else
            {
                if (kitTalks2[i] == null || kitNpcTalks2[i] == null)
                {
                    break;
                }

                textDiag.showKitContent(kitTalks2[i]);
                yield return new WaitForSeconds(responseDelay);
                textDiag.showNpcContent(kitNpcTalks2[i++]);
                yield return new WaitForSeconds(1f);

            }
            yield return new WaitForSeconds(responseDelay);
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
