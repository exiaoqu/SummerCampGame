using UnityEngine;
using System.Collections;

public class CameraTwo : MonoBehaviour
{
    GameObject player;
    Vector3 offset;
    Camera cameraTwo;

    // Use this for initialization
    void Start()
    {
        //cameraTwo = GameObject.FindGameObjectWithTag("CameraTwo").GetComponent<Camera>();
        //player = GameObject.FindWithTag("player");
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        //cameraTwo.transform.position = player.transform.position + offset;
    }

}
