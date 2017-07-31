using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void selectStage(Button btn)
    {
        string selectedStage = btn.name.Replace("btn", "");//e.g Stage1
        string isSelectedStageUnlocked = PlayerPrefs.GetString(selectedStage+ "Unlocked");//e.g Stage1Unlocked
        if (isSelectedStageUnlocked == "Yes")//True to open all stages for test
        {
            PlayerPrefs.SetString("CurrentStage", selectedStage);//e.g Stage1

            //Can Show Story String
            string showStoryString = PlayerPrefs.GetString("CanShowStory");

            //Can Show Story
            if (showStoryString == "")
            {
                Debug.Log("Select Stage : Game Story Show");
                //Show Story
                PlayerPrefs.SetString("CanShowStory", "no");
                SceneManager.LoadScene("GameStory");
            }
            else
            {
                //Not Show Story

                //Check if how to already loaded
                if (PlayerPrefs.GetString("HowToAlreadyLoaded") == "")
                {
                    //Load How to
                    SceneManager.LoadScene("HowTo");
                }
                else
                {
                    //Not Show How to

                    //Load Selected Stage
                    SceneManager.LoadScene(selectedStage);

                }
            }
        }
    }

    // Update is called once per frame
    void Update () {

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
