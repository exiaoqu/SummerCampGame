using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomFly : MonoBehaviour
{
    public float speed = 0.2f;

    public float directFlyHeight = 0.1f;

    public Vector3 maxDistanceToPlayer;
    public Vector3 minDistanceToPlayer;
    public Vector3 boundary;

    private float startingWait = 0.5f;
    private GameObject player;
    private Boolean towardPlayer;
    private Rigidbody rb;
    private Vector3 targetPosition;
    private Vector3 flyEndPosition;

    private Animation butterflyAnimation;
    private int butterflyAnimationClipCount;
    private String[] butterflyAnimationClips;
    private String animationClipName;

    private void Awake()
    {
        // random generate object around player
        player = GameObject.FindGameObjectWithTag("Player");

        butterflyAnimation = transform.Find("Butterfly").GetComponent<Animation>();

        butterflyAnimationClipCount = butterflyAnimation.GetClipCount();
        //Debug.Log("Animation Clip Count:" + butterflyAnimationClipCount);

        int i = 0;
        butterflyAnimationClips = new String[butterflyAnimationClipCount];
        foreach (AnimationState state in butterflyAnimation)
        {
            butterflyAnimationClips[i++] = state.name;
            //Debug.Log("Animation Clip Name[" + i + "]: " + state.name);
        }

        animationClipName = butterflyAnimationClips[UnityEngine.Random.Range(0, butterflyAnimationClipCount)];
        //Debug.Log("Selected Animation Clip Name: " + animationClipName);

        Vector3 randomVector3 = UnityEngine.Random.insideUnitSphere;

        Vector3 randomPositionToPlayer = new Vector3(
            Mathf.Abs(randomVector3.x * maxDistanceToPlayer.x),
            Mathf.Abs(randomVector3.y * maxDistanceToPlayer.y),
            Mathf.Abs(randomVector3.z * maxDistanceToPlayer.z)
            );

        //Debug.Log("randomPositionToPlayer: " + randomPositionToPlayer);
        transform.position = player.transform.position + randomPositionToPlayer;


        // random toward player or not
        towardPlayer = UnityEngine.Random.value > 0.5f;
        if (towardPlayer == false)
        {
            targetPosition = transform.position;
            targetPosition.y = player.transform.position.y + (player.transform.localScale.y / 2.0f) + minDistanceToPlayer.y + directFlyHeight;

            Vector3 randomInsideUnitSphere = getRandomInsideUnitSphere();
            flyEndPosition = new Vector3(
                    randomInsideUnitSphere.x > 0 ? (1 + randomInsideUnitSphere.x) * maxDistanceToPlayer.x : (-1 + randomInsideUnitSphere.x) * maxDistanceToPlayer.x,
                    (Mathf.Abs(randomInsideUnitSphere.y) + 1) * maxDistanceToPlayer.y,
                    randomInsideUnitSphere.z > 0 ? (1 + randomInsideUnitSphere.z) * maxDistanceToPlayer.z : (-1 + randomInsideUnitSphere.z) * maxDistanceToPlayer.z);
        }
    }

    private static Vector3 getRandomInsideUnitSphere()
    {
        return UnityEngine.Random.insideUnitSphere;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(player == null)
        {
            return;
        }

        Vector3 distanceToPlayer = transform.position - player.transform.position;

        if (towardPlayer == false
                && (Mathf.Abs(distanceToPlayer.x) > maxDistanceToPlayer.x
                || Mathf.Abs(distanceToPlayer.y) > maxDistanceToPlayer.y
                || Mathf.Abs(distanceToPlayer.z) > maxDistanceToPlayer.z))
        {
            towardPlayer = true;
            // Debug.Log("towardPlayer turns to: " + towardPlayer);
        }

        float step = speed * Time.deltaTime;

        if (towardPlayer)
        {
            targetPosition = player.transform.position;
            // Debug.Log("toward player: " + targetPosition);

            transform.localPosition = new Vector3(
                Mathf.Lerp(transform.localPosition.x, targetPosition.x, step),
                Mathf.Lerp(transform.localPosition.y, targetPosition.y, step),
                Mathf.Lerp(transform.localPosition.z, targetPosition.z, step));


            Vector3 minDistance = minDistanceToPlayer + new Vector3(
                player.GetComponent<Collider>().bounds.size.x / 2.0f + GetComponent<Collider>().bounds.size.x / 2.0f,
                player.GetComponent<Collider>().bounds.size.y / 2.0f + GetComponent<Collider>().bounds.size.y / 2.0f,
                player.GetComponent<Collider>().bounds.size.z / 2.0f + GetComponent<Collider>().bounds.size.z / 2.0f);

            if (Mathf.Abs(distanceToPlayer.x) < minDistance.x
               && Mathf.Abs(distanceToPlayer.y) < minDistance.y
               && Mathf.Abs(distanceToPlayer.z) < minDistance.z)
            {
                towardPlayer = false;
                // Debug.Log("Min Distance: " + minDistance + "  towardPlayer turns to: " + towardPlayer);

                targetPosition = transform.position;
                targetPosition.y = player.transform.position.y + (player.transform.localScale.y / 2.0f) + minDistanceToPlayer.y + directFlyHeight;

                Vector3 randomInsideUnitSphere = getRandomInsideUnitSphere();
                flyEndPosition = new Vector3(
                    randomInsideUnitSphere.x > 0 ? (1 + randomInsideUnitSphere.x) * maxDistanceToPlayer.x : (-1 + randomInsideUnitSphere.x) * maxDistanceToPlayer.x,
                    (Mathf.Abs(randomInsideUnitSphere.y) + 1) * maxDistanceToPlayer.y,
                    randomInsideUnitSphere.z > 0 ? (1 + randomInsideUnitSphere.z) * maxDistanceToPlayer.z : (-1 + randomInsideUnitSphere.z) * maxDistanceToPlayer.z);
            }
        }
        else if (targetPosition == flyEndPosition)
        {
            // Debug.Log("toward flying end: " + targetPosition);
            transform.localPosition = new Vector3(
                Mathf.Lerp(transform.localPosition.x, targetPosition.x, step),
                Mathf.Lerp(transform.localPosition.y, targetPosition.y, step),
                Mathf.Lerp(transform.localPosition.z, targetPosition.z, step));
        }
        else
        {
            if (transform.position.y >= targetPosition.y)
            {
                // Debug.Log("reach the height point: " + targetPosition);
                targetPosition = flyEndPosition;
            }
            else
            {
                // Debug.Log("toward height point: " + targetPosition);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
        }

        // Debug.Log("Play Animation Clip: " + ClipName);
        butterflyAnimation.Play(animationClipName);
    }
}