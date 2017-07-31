using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    GameObject player;
    Animator playerAnim;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerAnim = player.GetComponent<Animator>();
	}

    void Fire()
    {
        //Shoot Sound
        if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Fire") || !playerAnim.GetCurrentAnimatorStateInfo(0).IsName("RunFire"))
        {
            //Player Shot animation
            playerAnim.SetTrigger("shoot");

            //Play Audio
            AudioScript.shootSoundPlay();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || TouchScript.playerShootAxisTouch)
        {
            //Check if game is not over
            if (!GameLogic.isGameOver)
            {
                Fire();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            //Check if player fire animation going on
            if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Fire") || playerAnim.GetCurrentAnimatorStateInfo(0).IsName("RunFire"))
            {
                //Get enemy object and destory
                GameObject enemy = other.transform.gameObject;
                enemy.tag = "deadenemy";
                enemy.GetComponent<Animator>().SetTrigger("dead");

                //Remove Box Collider did this so player can pass through the enemy after dead
                Destroy(enemy.GetComponent<BoxCollider>(), 0.5f);

                //Destroy Enemy
                Destroy(enemy, 1.0f);

                //Player is not underattack anymore
                GameLogic.isPlayerUnderAttack = false;

                //Play Shoot Particle on sword
                gameObject.transform.Find("Particle").GetComponent<ParticleSystem>().Play();

                //Player Dead Sound
                AudioScript.enemyHitSoundPlay();

                //Enemies left Count
                GameLogic.enemiesLeft--;
            }
        }
    }
}
