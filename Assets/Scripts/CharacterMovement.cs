using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6f;            //The speed that the player will move.
    public float turnSpeed = 60f;
    public float turnSmoothing = 15f;

    private Vector3 movement;
    private Vector3 turning;
    private Animation anims;
    private Rigidbody playerRigidbody;
	private GameObject player;

    void Awake()
    {
        //Get references
		player = GameObject.FindGameObjectWithTag("Player");
        anims = GetComponent<Animation>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        anims["Ithcing"].layer = 1;
        anims["Ithcing"].wrapMode = WrapMode.Once;
        anims["Meow"].layer = 1;
        anims["Meow"].wrapMode = WrapMode.Once;
    }

    private void Update()
    {
        if (Input.GetKey("c"))
        {
            anims.Play("Ithcing");
        }
        if (Input.GetKey("m"))
        {
            anims.Play("Meow");
        }
    }

    void FixedUpdate()
    {
        //Store input axes
        float lh = -Input.GetAxisRaw("Horizontal");
        float lv = -Input.GetAxisRaw("Vertical");
       
        Move(lh, lv);
    }

    void Move(float lh, float lv)
    {
        //Move the player
        if(lh != 0f || lv != 0f)
        {
            anims.Play("Walk");

            movement.Set(lh, 0.0f, lv);
            movement = movement.normalized * speed * Time.deltaTime;

            playerRigidbody.MovePosition(transform.position + movement);

            Rotating(lh, lv);
        }
        else
        {
            anims.Play("Idle");
        }
    }

    void Rotating(float lh, float lv)
    {
        Vector3 targetDirection = new Vector3(lh, 0f, lv);

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);

        GetComponent<Rigidbody>().MoveRotation(newRotation);
    }
}
