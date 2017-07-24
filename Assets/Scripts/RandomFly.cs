using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomFly : MonoBehaviour {
    public float startWait = 0.5f;

    public float minFlyTimeLen = 2.0f;
    public float maxFlyTimeLen = 10.0f;

    public float speed;

    public Vector3 boundary;
    public Vector3 Range;

    private Rigidbody rb;
    private Vector3 movement;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();

        StartCoroutine(RandomFlying());
	}

    // Update is called once per frame
    void FixedUpdate () {

       Vector2 vector2X = computeRange(player.transform.position.x, Range.x, boundary.x);
       Vector2 vector2Y = computeRange(player.transform.position.y, Range.y, boundary.y);
       Vector2 vector2Z = computeRange(player.transform.position.z, Range.z, boundary.z);

        Vector3 position = new Vector3(
           Mathf.Clamp(transform.position.x, vector2X.x, vector2X.y),
           Mathf.Clamp(transform.position.y, vector2Y.x, vector2Y.y),
           Mathf.Clamp(transform.position.z, vector2Z.x, vector2Z.y)
       );

        rb.AddForceAtPosition(movement * speed, position);
        rb.position = position;

    }

    IEnumerator RandomFlying()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            float flyXDirection = UnityEngine.Random.Range(-boundary.x, boundary.x);
            float flyZDirection = UnityEngine.Random.Range(0.06f, boundary.y);
            float flyYDirection = UnityEngine.Random.Range(-boundary.z, boundary.z);

            movement = new Vector3(flyXDirection, flyYDirection, flyZDirection);
            movement = transform.position - movement;

            float randomFlyTimeLen = UnityEngine.Random.Range(minFlyTimeLen, maxFlyTimeLen);

            yield return new WaitForSeconds(randomFlyTimeLen);
        }
    }

    private Vector2 computeRange(float player, float range, float boundary)
    {
        float flyMax = player + range;
        float flyMin = player - range;
        if (flyMax > boundary) flyMax = boundary;
        if (flyMin < 0) flyMin = 0;

        return new Vector2(flyMin, flyMax);
    }
}
