using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

    static AudioSource[] audioSources;
    static bool isSoundOnBool;

	// Use this for initialization
	void Start () {

        audioSources = GetComponents<AudioSource>();

        string isSoundOn = PlayerPrefs.GetString("isSoundOn");
        if (isSoundOn == "on" || isSoundOn == "")
        {
            //Sound On
            isSoundOnBool = true;
        }
        else if (isSoundOn == "off")
        {
            //Sound Off
            isSoundOnBool = false;
        }

    }

    //Run Sound Play
    public static void runSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[0].isPlaying)
            {
                audioSources[0].Play();
            }
        }
    }

    //Run Sound Stop
    public static void runSoundStop()
    {
        if (isSoundOnBool)
        {
            if (audioSources[0].isPlaying)
            {
                audioSources[0].Stop();
            }
        }
    }

    //Jump Sound Play
    public static void jumpSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[1].isPlaying)
            {
                audioSources[1].Play();
            }
        }
    }

    //Land Sound Play
    public static void landSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[2].isPlaying)
            {
                audioSources[2].Play();
            }
        }
    }

    //Coin Sound Play
    public static void coinSoundPlay()
    {
        if (isSoundOnBool)
        {
            /*if (!audioSources[3].isPlaying)
            {
                audioSources[3].Play();
            }*/
            audioSources[3].Play();
        }
    }

    //Shoot Sound Play
    public static void shootSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[4].isPlaying)
            {
                audioSources[4].Play();
            }
            //audioSources[4].PlayOneShot(audioSources[4].clip);
        }
    }

    //Plater Hit
    public static void playerHitSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[5].isPlaying)
            {
                audioSources[5].Play();
            }
        }
    }

    //Enemy Hit
    public static void enemyHitSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[6].isPlaying)
            {
                audioSources[6].Play();
            }
        }
    }

    //Game Win
    public static void gameWinSoundPlay()
    {
        if (isSoundOnBool)
        {
            //Stop Run Sound
            runSoundStop();

            //Play Win Sound
            if (!audioSources[7].isPlaying)
            {
                audioSources[7].Play();
            }
        }
    }

    //Game Lose
    public static void gameLoseSoundPlay()
    {
        if (isSoundOnBool)
        {
            //Stop Run Sound
            runSoundStop();

            //Play Lose Sound
            if (!audioSources[8].isPlaying)
            {
                audioSources[8].Play();
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
