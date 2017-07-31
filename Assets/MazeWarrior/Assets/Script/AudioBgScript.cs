using UnityEngine;
using System.Collections;

public class AudioBgScript : MonoBehaviour {

    static string isSoundOn;

    //Audio
    static AudioSource[] audioSources;

    // Use this for initialization
    void Start () {

        //Get Sound On
        isSoundOn = PlayerPrefs.GetString("isSoundOn");

        //Audio
        audioSources = GetComponents<AudioSource>();
        soundOnOffStart();

    }

    void soundOnOffStart()
    {
        if (isSoundOn == "on" || isSoundOn == "")
        {
            //Sound On
            audioSources[0].Play();
        }
        else if (isSoundOn == "off")
        {
            //Sound Off
            audioSources[0].Stop();
        }
    }

    //Stop Bg Audio for Admob
    public static void stopAudioBg()
    {
        if (isSoundOn == "on")
        {
            //Sound Stop
            audioSources[0].Stop();
        }
    }

    //Play Bg Audio for Admob
    public static void playAudioBg()
    {
        if (isSoundOn == "on")
        {
            //Sound Play
            audioSources[0].Play();
        }
    }

    //Play Global
    private static AudioBgScript instance = null;
    public static AudioBgScript Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update () {
	
	}
}
