using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour
{

    GameObject cameraOne;
    GameObject cameraTwo;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;

    // Use this for initialization
    void Start()
    {
        //Get Cameras
        //cameraOne = GameObject.FindGameObjectWithTag("CameraOne");
        //cameraTwo = GameObject.FindGameObjectWithTag("CameraTwo");
        cameraOne = GameObject.Find("CamerasAndPlayer/Player/CameraOne");
        cameraTwo = GameObject.Find("CamerasAndPlayer/Player/CameraTwo");

        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();


        //Debug.Log("xxx" + cameraOne.tag);
        //Debug.Log("xxx" + cameraTwo.tag);

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        cameraChangeKeyBoard();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    void cameraChangeKeyBoard()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            if (!GameLogic.isGameOver)
            {
                cameraChangeCounter();
            }
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);
        }

    }

}
