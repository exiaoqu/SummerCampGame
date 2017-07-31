using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectNav : MonoBehaviour
{
    public Sprite navUnLockImage;

    Text txtHeading;
    Text txtCoins;
    int totalCoins;

    // Use this for initialization
    void Start()
    {
        //Get coins
        totalCoins = PlayerPrefs.GetInt("TotalCoins");

        //Get Coins text
        txtCoins = GameObject.Find("Canvas/txtCoins").GetComponent<Text>();
        txtCoins.text = "Coins : " + totalCoins;

        //Get heading
        txtHeading = GameObject.Find("Canvas/txtTitle").GetComponent<Text>();
        
    }

    //UI Button Method
    public void selectStageNav(Button btn)
    {
        string selectedStage = btn.name.Replace("btn", "");//e.g Stage1
        string isSelectedStageUnlocked = PlayerPrefs.GetString(selectedStage + "Unlocked");//e.g Stage1Unlocked
        if (isSelectedStageUnlocked == "Yes")//True to open all stages for test
        {
            //Stage is unlocked

            //Check if nav is locked or unlocked
            string navKey = btn.name.Replace("btn", "") + "Nav";//e.g Stage1Nav
            if (PlayerPrefs.GetString(navKey) == "Yes")
            {
                //Navigation is open
                txtHeading.text = "Navigation is already opened";

                //Sound
                if (isSoundOpenCheck())
                    GetComponents<AudioSource>()[1].Play();
            }
            else
            {
                //Navigation not open
                checkCoinsAndUnLock(navKey , btn);
            }

        }
        else
        {
            //Stage is locked
            txtHeading.text = "Stage is locked";

            //Sound
            if (isSoundOpenCheck())
                GetComponents<AudioSource>()[1].Play();
        }
    }

    //checkCoinsAndUnlock
    void checkCoinsAndUnLock(string navK , Button btnGet)
    {
        int coinsRequired = PlayerPrefs.GetInt(navK + "Coins");//e.g Stage1NavCoins

        if (totalCoins >= coinsRequired)
        {
            //Set Heading
            txtHeading.text = "Navigation enabled";

            //Sound
            if (isSoundOpenCheck())
                GetComponents<AudioSource>()[0].Play();

            //Update Image
            btnGet.image.overrideSprite = navUnLockImage;

            //Hide Coin text
            btnGet.GetComponentInChildren<Text>().gameObject.SetActive(false);

            //Set Nav Pref
            PlayerPrefs.SetString(navK, "Yes");

            //Update Total Coins
            totalCoins = totalCoins - coinsRequired;
            PlayerPrefs.SetInt("TotalCoins", totalCoins);

            //Update UI Coins
            txtCoins.text = "Coins : " + PlayerPrefs.GetInt("TotalCoins");
        }
        else
        {
            //Not Enough Coins
            txtHeading.text = "You need " + coinsRequired + " coins";

            //Sound
            if (isSoundOpenCheck())
                GetComponents<AudioSource>()[1].Play();
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

    // Update is called once per frame
    void Update()
    {
        //Press Escape Key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            backToMainScreen();
        }
    }

    //Back Screen
    public void backToMainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
