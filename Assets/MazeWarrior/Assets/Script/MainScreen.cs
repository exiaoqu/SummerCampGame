using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour {

    public Sprite imgSoundOn;
    public Sprite imgSoundOff;

    Button btnSoundOnOff;

    //Audio
    AudioSource[] audioSources;

    // Use this for initialization
    void Start() {

        //Clear All Values
        //PlayerPrefs.DeleteAll();

        //First Stage Always UnLocked
        PlayerPrefs.SetString("Stage1Unlocked", "Yes");

        //UI Buttons
        btnSoundOnOff = GameObject.Find("Canvas/btnSound").GetComponent<Button>();

        //Audio
        audioSources = GameObject.Find("BgSound").GetComponents<AudioSource>();
        soundOnOffImageOnStart();

        //Set stage navigation coins
        stageNavCoinsSet();

    }

    //Sound Button UI
    public void btnSoundOnOffM()
    {
        string isSoundOn = PlayerPrefs.GetString("isSoundOn");

        if (isSoundOn == "on" || isSoundOn == "")
        {
            //Sound Off
            btnSoundOnOff.image.overrideSprite = imgSoundOff;
            PlayerPrefs.SetString("isSoundOn", "off");
            audioSources[0].Stop();
        }
        else if (isSoundOn == "off")
        {
            //Sound On
            btnSoundOnOff.image.overrideSprite = imgSoundOn;
            PlayerPrefs.SetString("isSoundOn", "on");
            audioSources[0].Play();
        }

    }

    //Control How To Button UI
    public void btnControlsM()
    {
        PlayerPrefs.SetString("FromMainScreenControls", "yes");
        SceneManager.LoadScene("HowTo");
    }

    //Control Story Button UI
    public void btnStoryM()
    {
        PlayerPrefs.SetString("FromMainScreenControls", "yes");
        SceneManager.LoadScene("GameStory");
    }

    void soundOnOffImageOnStart()
    {
        string isSoundOn = PlayerPrefs.GetString("isSoundOn");

        if (isSoundOn == "on" || isSoundOn == "")
        {
            btnSoundOnOff.image.overrideSprite = imgSoundOn;
        }
        else if (isSoundOn == "off")
        {
            btnSoundOnOff.image.overrideSprite = imgSoundOff;
        }
    }

    //Stage Navigation
    public void btnNavM()
    {
        SceneManager.LoadScene("UnlockNav");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!IsPointerOverUIObject())
                {
                    //Select Stage
                    if (hit.transform.name == "Player")
                    {
                        if (!isOneTimeLoadSelectStage)
                        {
                            isOneTimeLoadSelectStage = true;
                            GameObject.Find("Player").GetComponent<Animator>().SetTrigger("shoot");

                            if (isSoundOpenCheck())
                            {
                                GetComponent<AudioSource>().Play();
                            }

                            Invoke("loadSelectStage", 1.0f);
                        }
                    }
                }
            }
        }

        //Exit App
        backExit();

    }

    //Load Select Stage Screen
    bool isOneTimeLoadSelectStage;
    void loadSelectStage()
    {
        SceneManager.LoadScene("SelectStage");
    }

    //When Touching UI
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    //Exit App
    void backExit()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //Stage nav coins set
    void stageNavCoinsSet()
    {
        if (PlayerPrefs.GetString("isNavCoinsAlreadySet") != "Yes")
        {
            PlayerPrefs.SetString("isNavCoinsAlreadySet", "Yes");

            PlayerPrefs.SetInt("Stage1NavCoins", 50);
            PlayerPrefs.SetInt("Stage2NavCoins", 100);
            PlayerPrefs.SetInt("Stage3NavCoins", 300);
            PlayerPrefs.SetInt("Stage4NavCoins", 500);
            PlayerPrefs.SetInt("Stage5NavCoins", 1000);
            PlayerPrefs.SetInt("Stage6NavCoins", 2000);
            PlayerPrefs.SetInt("Stage7NavCoins", 3000);
            PlayerPrefs.SetInt("Stage8NavCoins", 4000);
            PlayerPrefs.SetInt("Stage9NavCoins", 5000);
            PlayerPrefs.SetInt("Stage10NavCoins", 6000);
            PlayerPrefs.SetInt("Stage11NavCoins", 8000);
            PlayerPrefs.SetInt("Stage12NavCoins", 10000);
        }
    }

    //Check is sound open
    public bool isSoundOpenCheck()
    {
        bool soundOnLocal;

        if (PlayerPrefs.GetString("isSoundOn") == "on" || PlayerPrefs.GetString("isSoundOn") == "")
        {
            soundOnLocal = true;
        }
        else
        {
            soundOnLocal = false;
        }

        return soundOnLocal;

    }

    //TESTXX Clear Data
    public void testClearDataXXX()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

}
