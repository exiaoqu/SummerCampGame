using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectStageImage : MonoBehaviour {

    public Sprite lockImage;
    public Sprite unLockImageZeroStar;
    public Sprite unLockImageOneStar;
    public Sprite unLockImageTwoStar;
    public Sprite unLockImageThreeStar;

    Button btnSelectStage;

    // Use this for initialization
    void Start () {

        btnSelectStage = GetComponent<Button>();//e.g btnStage1

        string stageKey = btnSelectStage.name.Replace("btn", "") + "Unlocked";//e.g Stage1Unlocked
        string isStageUnlocked = PlayerPrefs.GetString(stageKey);
        if (isStageUnlocked == "Yes")
        {
            //Set Stars
            string currentStageStars = btnSelectStage.name.Replace("btn", "") + "Stars";//e.g Stage1Stars
            currentStageStars = PlayerPrefs.GetString(currentStageStars);
            if (currentStageStars == "one")
            {
                btnSelectStage.image.overrideSprite = unLockImageOneStar;
            }
            else if (currentStageStars == "two")
            {
                btnSelectStage.image.overrideSprite = unLockImageTwoStar;
            }
            else if (currentStageStars == "three")
            {
                btnSelectStage.image.overrideSprite = unLockImageThreeStar;
            }
            else
            {
                btnSelectStage.image.overrideSprite = unLockImageZeroStar;
            }
            
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
