using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndStory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        //Press Escape Key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            btnBackM();
        }
    }

    //Back Screen
    public void btnBackM()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
