using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowTo : MonoBehaviour {

    public Sprite forwardImage1;
    public Sprite forwardImage2;

    Button btnForward;
    Text txtSkip;
    Button btnBack;

    //Get All Menu Items
    GameObject playerLeft;
    GameObject playerRight;
    //GameObject playerJump;
    GameObject playerCamera;
    GameObject playerRun;
    GameObject playerShoot;
    GameObject txtJump;
    GameObject txtTurn;
    GameObject txtFire;
    GameObject txtRun;

    GameObject keyLeftRightTop;
    GameObject keySpaceBar;
    GameObject keyCamera;

    //Can use touch
    bool canUseTouch;

    // Use this for initialization
    void Start () {

        //Can Use Touch
        canUseTouch = CanUseTouch.canUseTouchM();

        //Get All Touch Game Control
        playerLeft = GameObject.Find("Canvas/playerLeft");
        playerRight = GameObject.Find("Canvas/playerRight");
        //playerJump = GameObject.Find("Canvas/playerJump");
        playerCamera = GameObject.Find("Canvas/playerCamera");
        playerRun = GameObject.Find("Canvas/playerRun");
        playerShoot = GameObject.Find("Canvas/playerShoot");
        txtJump = GameObject.Find("Canvas/txtJump");
        txtTurn = GameObject.Find("Canvas/txtTurn");
        txtFire = GameObject.Find("Canvas/txtFire");
        txtRun = GameObject.Find("Canvas/txtRun");

        keyLeftRightTop = GameObject.Find("Canvas/keyLeftRightTop");
        keySpaceBar = GameObject.Find("Canvas/keySpaceBar");
        keyCamera = GameObject.Find("Canvas/keyCamera");

        //Hide if not touch device
        if (canUseTouch)
        {
            keyLeftRightTop.SetActive(false);
            keySpaceBar.SetActive(false);
            keyCamera.SetActive(false);
        }
        else
        {
            playerLeft.SetActive(false);
            playerRight.SetActive(false);
            //playerJump.SetActive(false);
            playerCamera.SetActive(false);
            playerRun.SetActive(false);
            playerShoot.SetActive(false);
            txtJump.SetActive(false);
            txtTurn.SetActive(false);
            txtFire.SetActive(false);
            txtRun.SetActive(false);
        }

        //Get Forward Button
        btnForward = GameObject.Find("Canvas/btnForward").GetComponent<Button>();

        //Get Forward Message
        txtSkip = GameObject.Find("Canvas/txtSkip").GetComponent<Text>();

        //Get Back Button
        btnBack = GameObject.Find("Canvas/btnBack").GetComponent<Button>();

        //Coming from main screen controls
        if (PlayerPrefs.GetString("FromMainScreenControls") == "yes")
        {
            PlayerPrefs.SetString("FromMainScreenControls", "no");
            btnForward.gameObject.SetActive(false);
            txtSkip.gameObject.SetActive(false);
        }
        else
        {
            //Hide Back Button
            btnBack.gameObject.SetActive(false);

            //Invoke Next Blink
            Invoke("forwardImageBlink", 1.0f);
        }

        //Set How To Already Loaded
        if (PlayerPrefs.GetString("HowToAlreadyLoaded") == "")
        {
            PlayerPrefs.SetString("HowToAlreadyLoaded", "yes");
        }

    }

    //Forward Blink Button
    int forwardCount;
    void forwardImageBlink()
    {
        if (forwardCount == 0)
        {
            forwardCount = 1;
            btnForward.image.overrideSprite = forwardImage2;
        }
        else
        {
            forwardCount = 0;
            btnForward.image.overrideSprite = forwardImage1;
        }

        Invoke("forwardImageBlink", 1.0f);

    }
	
	// Update is called once per frame
	void Update () {

        //Press Escape Key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            btnBackM();
        }

    }

    //Goto FirstStage
    public void gotoFirstStageM()
    {
        SceneManager.LoadScene("Stage1");
    }

    //Back Screen
    public void btnBackM()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
