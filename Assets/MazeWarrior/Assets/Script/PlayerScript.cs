using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Player Speed
    float playerSpeed = 0.5f;//0.3
    float rotationSpeed = 4.0f;

    //Player Health
    static public int playerHealth;//Static Variable set in start

    //Jump
    float playerJumpSpeed = 3.0f;//6.0
    bool canJump = false;

    //Rigid Body
    private Rigidbody rb;

    //Axis
    float moveHorizontal;
    float moveVertical;

    //Rotaion Value
    private float rotY = 0.0f;

    //Movement Value
    Vector3 playerPosition;

    //Can use touch
    bool canUseTouch;

    //Player Animator
    Animator animPlayer;
    bool isPlayerMoving;

    // Use this for initialization
    void Start()
    {
        //Set Player Health Static Variable
        playerHealth = 6;//6;

        //Can Use Touch
        canUseTouch = CanUseTouch.canUseTouchM();

        //Get Player Ridgit Body
        rb = GetComponent<Rigidbody>();

        //Get Player Animator
        animPlayer = GetComponent<Animator>();

        //Rotation Setting
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
    }

    void FixedUpdate()
    {
        //Check if game is not over
        if (!GameLogic.isGameOver)
        {
            //Player Movement
            if (moveVertical > 0)
            {
                rb.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
            }

            //Player Rotation
            rotY += moveHorizontal * rotationSpeed;
            rb.rotation = Quaternion.Euler(0.0f, rotY, 0.0f);

            //Player Jump
            if (canJump)
            {
                canJump = false;
                //rb.MovePosition(transform.position + transform.up * 1.0f);//To control Double jump and stair forward and jump stuck
                                                                          //rb.velocity = transform.up * playerJumpSpeed;//Jump
                                                                          //rb.velocity = transform.forward * playerJumpSpeed;//Forward
                //rb.velocity = new Vector3(0, transform.up.y * playerJumpSpeed, transform.forward.z);
            }
        }
    }

    void Update()
    {
        //Check if game is not over
        if (!GameLogic.isGameOver)
        {
            // Get Axses
            if (canUseTouch)
            {
                moveHorizontal = TouchScript.playerTurnAxisTouch;
                moveVertical = TouchScript.playerRunAxsisTouch;

            }
            else
            {
                playerKeyBoardAxsis();
                moveHorizontal = playerTurnAxisKeyBoard;
                moveVertical = playerRunAxsisKeyBoard;

            }

            //Player move Animation
            if (moveVertical != 0) //(moveVertical > 0)***
            {
                /////////////////////****Run Anim//////////////////////////
                if (!isPlayerMoving)
                {
                    if (!animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        isPlayerMoving = true;
                        animPlayer.SetTrigger("run");
                    }
                }
                /////////////////////****End Run Anim//////////////////////////

                //Play Run Sound
                if (isPlayerOnGround)
                {
                    AudioScript.runSoundPlay();
                }

            }
            else
            {
                ////////////////////Run Anim Stop//////////////////////////
                if (isPlayerMoving)
                {
                    if (animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        isPlayerMoving = false;
                        animPlayer.SetTrigger("stop");
                    }
                }
                /////////////////////****End Run Anim//////////////////////////

                //Play Stop Run Sound
                AudioScript.runSoundStop();

            }

            //Player Turn Animation
            if (moveHorizontal != 0)
            {
                
            }
            else
            {
                
            }

            //Player Jump
            if (Input.GetKeyDown(KeyCode.Space) || TouchScript.playerJumpAxisTouch)
            {
                /*if (isPlayerOnGround)
                {
                    isPlayerOnGround = false;
                    canJump = true;

                    //Jump Animation
                    animPlayer.SetTrigger("jump");

                    //Stop Run Sound
                    AudioScript.runSoundStop();
                    //Play jump Sound
                    AudioScript.jumpSoundPlay();
                }*/
            }
        }
        else
        {
            //Note: This will call lots of times

            //Stop Player Animation
            animPlayer.SetTrigger("stop");
        }
    }

    bool isPlayerOnGround;
    void OnCollisionStay()
    {
        //Sound Land Logic
        /*if (!isPlayerOnGround)
            landSoundLogicBool = true;*/
        //End

        isPlayerOnGround = true;
    }

    //bool landSoundLogicBool;
    void OnCollisionEnter(Collision col)
    {
        //Land Sound Logic
        /*if (landSoundLogicBool)
        {
            if (col.gameObject.tag != "coin" && col.gameObject.tag != "enemy")
            {
                //Stop Run Sound
                AudioScript.runSoundStop();
                //Play jump Sound
                AudioScript.landSoundPlay();
                Debug.Log(col.gameObject.name);
            }
            
            landSoundLogicBool = false;
        }*/
        //End

        //Player Touch Game Over Plane
        if (col.gameObject.name == "GameOverPlane")
        {
            //Set player health zero
            playerHealth = 0;
        }

    }

    void OnCollisionExit()
    {

    }

    //Player Keyboard Script
    int playerTurnAxisKeyBoard = 0;
    int playerRunAxsisKeyBoard = 0;
    void playerKeyBoardAxsis()
    {
        //Left Arrow Down
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerTurnAxisKeyBoard = -1;
        }

        //Left Arrow Up
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerTurnAxisKeyBoard = 0;
        }

        //Right Arrow Down
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerTurnAxisKeyBoard = 1;
        }

        //Right Arrow Up
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerTurnAxisKeyBoard = 0;
        }

        //Up Arrow Down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRunAxsisKeyBoard = 1;
        }

        //Up Arrow Up
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerRunAxsisKeyBoard = 0;
        }
    }

    //On Trigger enter
    void OnTriggerEnter(Collider col)
    {
        if (col.tag =="treasure")
        {
            GameLogic.isTreausreCollected = true;
        }
    }

}
