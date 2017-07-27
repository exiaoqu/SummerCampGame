using UnityEngine;  
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class menu : MonoBehaviour
{
    public AudioClip beep;
    public GUISkin menuSkin;
    public Rect menuArea;
    public Rect playButton;
    public Rect instructionsButton;
    public Rect quitButton;
    public Rect instructions;
    Rect menuAreaNormalized;
    AudioSource audioSource;
    string menuPage = "main";
    // Use this for initialization  
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        menuAreaNormalized =
            new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
    }
    void OnGUI()
    {
        GUI.skin = menuSkin;
        GUI.BeginGroup(menuAreaNormalized);
        if (menuPage == "main")
        {
            if (GUI.Button(new Rect(playButton), "play"))
            {
                StartCoroutine("ButtonAction", "second");
                //Application.LoadLevel("second");  
            }
            if (GUI.Button(new Rect(instructionsButton), "Instructions"))
            {
                audioSource.PlayOneShot(beep);
                menuPage = "instructions";

            }
            if (GUI.Button(new Rect(quitButton), "Quit"))
            {
                StartCoroutine("ButtonAction", "quit");
            }
        }
        else if (menuPage == "instructions")
        {
            GUI.Label(new Rect(instructions), "You awake on a mysterious island...Find a way to signal for help or face certain doom!");
            if (GUI.Button(new Rect(quitButton), "Back"))
            {
                audioSource.PlayOneShot(beep);
                menuPage = "main";
            }
        }
        GUI.EndGroup();
    }
    IEnumerator ButtonAction(string levelName)
    {
        audioSource.PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);

        if (levelName != "quit")
        {
            SceneManager.LoadScene(levelName,LoadSceneMode.Single);
        }
        else
        {
            Application.Quit();
            Debug.Log("Have Quit");
        }
    }
    // Update is called once per frame  
    void Update()
    {

    }
}