using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {

    public static int playerTurnAxisTouch = 0;
    public static int playerRunAxsisTouch = 0;
    public static bool playerJumpAxisTouch = false;
    public static bool playerShootAxisTouch = false;

    // Use this for initialization
    void Start () {

        //Set Static Variables
        playerTurnAxisTouch = 0;
        playerRunAxsisTouch = 0;
        playerJumpAxisTouch = false;
        playerShootAxisTouch = false;
	
	}

    public void playerLeftUIPointerDown()
    {
        playerTurnAxisTouch = -1;
    }

    public void playerLeftUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }

    public void playerRightUIPointerDown()
    {
        playerTurnAxisTouch = 1;
    }

    public void playerRightUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }

    public void playerRunUIPointerDown()
    {
        playerRunAxsisTouch = 1;
    }

    public void playerRunUIPointerUp()
    {
        playerRunAxsisTouch = 0;
    }

    public void playerJumpUI()
    {
        playerJumpAxisTouch = true;
        Invoke("playerJumpUIDone", 0.01f);
    }

    void playerJumpUIDone()
    {
        playerJumpAxisTouch = false;
    }

    public void playerShootUI()
    {
        playerShootAxisTouch = true;
        Invoke("playerShootUIDone", 0.01f);
    }

    void playerShootUIDone()
    {
        playerShootAxisTouch = false;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
