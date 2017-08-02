using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMushroomDoor : MonoBehaviour {
    public GameObject enterMushroomSpark;
    public GameObject shiningMushroomDoor;

    public void shiningDoor()
    {
        Instantiate(shiningMushroomDoor, transform.position, transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
		if(other.tag.Equals("Player")){
			Debug.Log("CAT Enter Mushroom door!");
			// initiate EnterMushroomSpark
			Instantiate(enterMushroomSpark, other.transform.position, other.transform.rotation); 
		}
        
    }
}
