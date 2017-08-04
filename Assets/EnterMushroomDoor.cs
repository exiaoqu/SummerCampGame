using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMushroomDoor : MonoBehaviour {
    public float playerLifeTime = 1.0f;
    public GameObject enterMushroomSpark;
    public GameObject shiningMushroomDoor;


    private GameObject shiningMushroomDoorClone;
  
    public void shiningDoor()
    {
        shiningMushroomDoorClone = Instantiate(shiningMushroomDoor, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
		if(other.tag.Equals("Player")){

			Debug.Log("CAT Enter Mushroom door!");

            Destroy(shiningMushroomDoorClone);

            // initiate EnterMushroomSpark
            Instantiate(enterMushroomSpark, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject, playerLifeTime);
            
        }
        
    }
}
