using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStory : MonoBehaviour {

    //Get text
    Text txtHeading;

    //Get Back Button
    Button btnBack;

    //Get Forward Button
    Button btnForward;
    Text txtSkip;

    bool fromMainScreenLocal;

    // Use this for initialization
    void Start () {

        //Get Heading
        txtHeading = GameObject.Find("Canvas/txtHeading").GetComponent<Text>();

        //Get back and forward
        btnBack = GameObject.Find("Canvas/btnBack").GetComponent<Button>();
        btnForward = GameObject.Find("Canvas/btnForward").GetComponent<Button>();
        txtSkip = GameObject.Find("Canvas/txtSkip").GetComponent<Text>();

        //Check Can Hide Back or forward button
        //Coming from main screen controls
        if (PlayerPrefs.GetString("FromMainScreenControls") == "yes")
        {
            fromMainScreenLocal = true;
            PlayerPrefs.SetString("FromMainScreenControls", "no");

            //Set Story AlreadyLoaded
            PlayerPrefs.SetString("CanShowStory", "MainAlreadyLoaded");

            //Hide Buttons
            btnForward.gameObject.SetActive(false);
            txtSkip.gameObject.SetActive(false);
            Debug.Log("Game Story : From Main Screen Controls");
        }
        else
        {
            //Hide Back Button
            btnBack.gameObject.SetActive(false);
            Debug.Log("Game Story : First Time");
        }



        //Start Story
        Invoke("loadStoryGame", 4.0f);

    }

    void loadStoryGame()
    {
        //If coming from main screen not run
        if (fromMainScreenLocal)
        {
            //From Main
            SceneManager.LoadScene("SelectStage");
        }
        else
        {
            //If How to already loaded load stage
            loadHowToOrStage();
        }
    }

    //////////////////////////////***Stage Five End***////////////////////////////////

    public void gameStoryForwardM()
    {
        //If How to already loaded load stage
        loadHowToOrStage();
    }

    void loadHowToOrStage()
    {
        if (PlayerPrefs.GetString("HowToAlreadyLoaded") == "")
        {
            SceneManager.LoadScene("HowTo");
        }
        else
        {
            SceneManager.LoadScene("Stage1");
        }
    }
	
	// Update is called once per frame
	void Update () {

        //Press Escape Key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            btnBackM();
        }

    }

    //Back Screen
    public void btnBackM()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
