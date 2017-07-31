using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryByTime : MonoBehaviour {
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnDestroy()
    {
        // switch scene
        //SceneManager.LoadScene("FantasticForest", LoadSceneMode.Single);
		SceneManager.LoadScene("SecondScene", LoadSceneMode.Single);
    }
}
