using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            if (gameObject.transform.tag == "coin")
            {
                //set coin tag taken
                gameObject.tag = "cointaken";

                //Play Coin Sound
                AudioScript.coinSoundPlay();

                //Coin counter less
                GameLogic.coinsLeft--;

                //Set Total Score
                GameLogic.totalScore += 1;

                //Save Score
                int totalCoins = PlayerPrefs.GetInt("TotalCoins");
                totalCoins += 1;
                PlayerPrefs.SetInt("TotalCoins", totalCoins);

                //Play Particle
                gameObject.transform.Find("CoinParticle").GetComponent<ParticleSystem>().Play();

                //Destroy Coins
                GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject, 1.0f);
            }
        }
    }

}
