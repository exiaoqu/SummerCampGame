using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectNavImage : MonoBehaviour
{

    public Sprite navUnLockImage;
    public Sprite navLockImage;
    public Sprite stageLockImage;

    Button btnSelectStage;
    Text btnSelectStageText;

    // Use this for initialization
    void Start()
    {

        btnSelectStage = GetComponent<Button>();//e.g btnStage1
        btnSelectStageText = btnSelectStage.GetComponentInChildren<Text>();

        string stageKey = btnSelectStage.name.Replace("btn", "") + "Unlocked";//e.g Stage1Unlocked
        string isStageUnlocked = PlayerPrefs.GetString(stageKey);
        if (isStageUnlocked == "Yes")
        {
            //Stage is unlocked

            //Check if nav is locked or unlocked
            string navKey = btnSelectStage.name.Replace("btn", "") + "Nav";//e.g Stage1Nav
            if (PlayerPrefs.GetString(navKey) == "Yes")
            {
                //Navigation is open
                btnSelectStage.image.overrideSprite = navUnLockImage;
                btnSelectStageText.gameObject.SetActive(false);
            }
            else
            {
                //Navigation not open
                btnSelectStage.image.overrideSprite = navLockImage;
                string stageNavCoinsKey = navKey + "Coins";//e.g Stage1NavCoins
                btnSelectStageText.text = PlayerPrefs.GetInt(stageNavCoinsKey).ToString();
            }

        }
        else
        {
            //Stage is locked
            btnSelectStage.image.overrideSprite = stageLockImage;
            btnSelectStageText.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
