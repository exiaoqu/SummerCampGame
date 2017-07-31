using UnityEngine;
using System.Collections;

public class Promotion : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //Promotion Button
        checkPromotionButtons();

        //Rater
        showAPIRaterFinalX();
    }

    //Promotion
    public void btnMorePromotion()
    {
        //Android
        //Application.OpenURL("market://search?q=pub:ZeeMelApps");

        //Amazon
        //Application.OpenURL("amzn://apps/android?s=ZeeMelApps");

        //Samsung
        //Application.OpenURL("samsungapps://SellerDetail/7kxd8dfo3g");

        //Microsoft
        //Application.OpenURL("ms-windows-store:Publisher?name=ZeeMelApps");

        //Apple
        Application.OpenURL("https://itunes.apple.com/developer/id1023122479");
    }

    //Facebook
    public void btnFacebookPromotion()
    {
        //string facebookScheme = "fb://page/" + "140106539492281";//Android
        //string facebookScheme = "fb://page/" + "140598549443148";//Amazon
        //string facebookScheme = "https://www.facebook.com/Zeemish";//Microsoft
        string facebookScheme = "https://facebook.com/zeemishapps/";//Apple

        //open the facebook app
        Application.OpenURL(facebookScheme);
    }

    //Rate
    /*public void btnRatePromotion()
    {
        Application.OpenURL(getRateURL());
    }*/

    //Create Rate URL
    string getRateURL()
    {
        //string appId = "com.ZeeMelApps.Maze.dungeon";//Android
        //string appId = "49058ZeeMelApps.MazeWarrior_bc0tz99paqz1e";//Microsoft
        string appId = "1185855724";//Apple

        //string rateURL = "market://details?id=" + appId;//Android
        //string rateURL = "amzn://apps/android?p=" + appId;//Amazon
        //string rateURL = "samsungapps://ProductDetail/" + appId;//Samsung
        //string rateURL = "ms-windows-store:REVIEW?PFN=" + appId;//Microsoft
        string rateURL = "https://itunes.apple.com/app/id" + appId;//Apple

        return rateURL;
    }

    ///////////////////////////////////////////Promotion///////////////////////////////////////////

    GameObject btnFBObject;
    GameObject btnMoreObject;
    int promotionCounter = 12;//12
    void checkPromotionButtons()
    {
        //Get Buttons
        btnFBObject = GameObject.Find("Canvas/btnFB");
        btnMoreObject = GameObject.Find("Canvas/btnMore");

        //Check if can show buttons
        int promotionCounterLocal = PlayerPrefs.GetInt("PromotionBtnCounter");
        if (promotionCounterLocal < promotionCounter)
        {
            promotionCounterLocal++;
            PlayerPrefs.SetInt("PromotionBtnCounter", promotionCounterLocal);
            btnFBObject.SetActive(false);
            btnMoreObject.SetActive(false);
        }

    }

    ///////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////Rate API/////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////
    int initialLaunchCount = 10;//10
    int remindLaterLaunchCount = 15;//15
    void rateAppShow()
    {
        // Show Rater Dialog
        raterObj.SetActive(true);
    }

    public void btnRatingRateIt()
    {
        //Rate It
        PlayerPrefs.SetString("CounterRater", "100000");

        //Open Rate URL
        Application.OpenURL(getRateURL());

        //Hide Rate It
        raterObj.SetActive(false);
    }

    public void btnRatingRemindMeLater()
    {
        //Remind Me Later
        PlayerPrefs.SetString("CounterRater", remindLaterLaunchCount.ToString());

        //Hide Rate It
        raterObj.SetActive(false);
    }

    bool canShowRateIt()
    {

        bool canGo = false;

        string fTIme = "";
        try
        {
            fTIme = PlayerPrefs.GetString("FirstTimeRater");
        }
        catch (System.Exception)
        {
            PlayerPrefs.SetString("FirstTimeRater", "no");
            PlayerPrefs.SetString("CounterRater", initialLaunchCount.ToString());
        }

        if (fTIme == "no")
        {
            string counterS = PlayerPrefs.GetString("CounterRater");
            int counter = int.Parse(counterS);
            counter--;
            if (counter <= 0)
            {
                canGo = true;
            }
            else
            {
                PlayerPrefs.SetString("CounterRater", counter.ToString());
            }

        }
        else
        {
            PlayerPrefs.SetString("FirstTimeRater", "no");
            PlayerPrefs.SetString("CounterRater", initialLaunchCount.ToString());
        }

        return canGo;

    }

    void showAPIRateFinal()
    {
        try
        {

            if (canShowRateIt())
            {
                if (checkNetworkAvailability())
                {
                    rateAppShow();
                }

            }
        }
        catch (System.Exception)
        {
        }
    }

    //Get Rater Box
    GameObject raterObj;
    void showAPIRaterFinalX()
    {
        //API Rater
        raterObj = GameObject.Find("Canvas/Rater");
        raterObj.SetActive(false);
        showAPIRateFinal();

    }

    bool checkNetworkAvailability()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    ///////////////
}
