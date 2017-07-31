using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    GameObject playerObject;
    Rigidbody enemyRB;
    Animator enemyAnim;

    float enemySpeed = 30.0f;//20

    float enemyWatchThreshold = 70.0f;//50
    float enemyShootThreshold = 5.0f;//5
    float enemyCloseThreshold = 2.0f;//2

    bool localIsPlayerUnderAttack;

    // Use this for initialization
    void Start()
    {

        //Get Player
        playerObject = GameObject.FindGameObjectWithTag("player");

        //Get Enemy
        enemyRB = GetComponent<Rigidbody>();

        //Get Animator
        enemyAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Check if game is not over
        if (!GameLogic.isGameOver)
        {
            if (gameObject.tag != "deadenemy")
            {


                //Calculate player's position
                Vector3 direction = playerObject.transform.position - transform.position;
                float magnitude = direction.magnitude;
                direction.Normalize();

                //Calculate enemy speed
                Vector3 velocity = direction * enemySpeed;

                if (magnitude > enemyShootThreshold && magnitude < enemyWatchThreshold)
                {
                    //Move the enemy
                    enemyRB.velocity = new Vector3(velocity.x, enemyRB.velocity.y, velocity.z);

                    //Animator
                    if (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    {
                        enemyAnim.SetTrigger("stop");
                    }
                    enemyAnim.SetTrigger("run");

                    //Face the enemy to the player
                    transform.LookAt(new Vector3(playerObject.transform.position.x, transform.position.y, playerObject.transform.position.z));

                    //***Player Not Under Attack
                    if (GameLogic.isPlayerUnderAttack == true)
                    {
                        if (localIsPlayerUnderAttack == true)
                        {
                            localIsPlayerUnderAttack = false;
                            GameLogic.isPlayerUnderAttack = false;
                            //Debug.Log("Player Under Attack : False");
                        }
                    }
                    //**********************

                }
                else if (magnitude < enemyCloseThreshold)
                {
                    enemyRB.velocity = new Vector3(-velocity.x, enemyRB.velocity.y, -velocity.z);
                }

                if (magnitude < enemyShootThreshold)
                {
                    //Animator
                    if (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        enemyAnim.SetTrigger("stop");
                    }

                    enemyAnim.SetTrigger("attack");

                    //Face the enemy to the player
                    transform.LookAt(new Vector3(playerObject.transform.position.x, transform.position.y, playerObject.transform.position.z));

                    //***Player Under Attack
                    localIsPlayerUnderAttack = true;
                    if (GameLogic.isPlayerUnderAttack == false)
                    {
                        GameLogic.isPlayerUnderAttack = true;
                    }
                    //**********************
                }
                else
                {
                    //xxx check this if problem because comment this recently
                    //enemyAnim.SetTrigger("stop");
                }
            }
            else
            {
                //Enemy is dead calls several times
                //Players under attack false in bullet script global
                localIsPlayerUnderAttack = false;//Local
            }
        }
        else
        {
            //Note: This will call lots of times

            //Stop Enemy Animation
            enemyAnim.SetTrigger("stop");
        }

    }

}
/*
 * RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1000.0F))
        {
            if (hit.transform.tag == "wall")
            {
                isPlayerBehindWall = true;
                Debug.Log("BEHIND WALL : " + Time.time);
            }
            else
            {
                isPlayerBehindWall = false;
                Debug.Log("FRONT WALL : " + Time.time);
            }
        }
 */
