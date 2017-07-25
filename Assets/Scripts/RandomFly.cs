using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomFly : MonoBehaviour
{
    public float speed = 0.2f;

    public float minFlyTimeLen = 1.0f;
    public float maxFlyTimeLen = 3.0f;

    public Vector3 maxDistanceToPlayer;
    public Vector3 minDistanceToPlayer;
    public Vector3 boundary;

    private float startingWait = 0.5f;
    private GameObject player;
    private Transform trans;
    private Boolean towardPlayer;
    private Rigidbody rb;
    private Vector3 targetPosition;

    private Animation butterflyAnimation;
    private int butterflyAnimationClipCount;
    private String[] butterflyAnimationClips;
    private String animationClipName;

    private void Awake()
    {
        // random generate object around player
        player = GameObject.FindGameObjectWithTag("Player");

        trans = GetComponent<Transform>();
        butterflyAnimation = trans.Find("Butterfly").GetComponent<Animation>();

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
        trans.position = player.transform.position + randomPositionToPlayer;

        // initial player position
        targetPosition = player.transform.position;

        // random toward player or not
        towardPlayer = UnityEngine.Random.value > 0.5f;
        //Debug.Log("towardPlayer: " + towardPlayer);


    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RandomFlying());
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        trans.localPosition = new Vector3(
            Mathf.Lerp(trans.localPosition.x, targetPosition.x, step),
            Mathf.Lerp(trans.localPosition.y, targetPosition.y, step),
            Mathf.Lerp(trans.localPosition.z, targetPosition.z, step));

        // String animationClipName = butterflyAnimationClips[UnityEngine.Random.Range(0, butterflyAnimationClipCount)];
        // Debug.Log("Play Animation Clip: " + ClipName);
        butterflyAnimation.Play(animationClipName);
    }

    IEnumerator RandomFlying()
    {
        yield return new WaitForSeconds(startingWait);

        while (true)
        {
            Vector3 distanceToPlayer = trans.position - player.transform.position;
            //Debug.Log("distanceToPlayer: " + distanceToPlayer);

            if (Mathf.Abs(distanceToPlayer.x) > maxDistanceToPlayer.x
                || Mathf.Abs(distanceToPlayer.y) > maxDistanceToPlayer.y
                || Mathf.Abs(distanceToPlayer.z) > maxDistanceToPlayer.z)
            {
                towardPlayer = true;
            }

            if (Mathf.Abs(distanceToPlayer.x) < minDistanceToPlayer.x
                && Mathf.Abs(distanceToPlayer.y) < minDistanceToPlayer.y
                && Mathf.Abs(distanceToPlayer.z) < minDistanceToPlayer.z)
            {
                towardPlayer = false;
            }

            if (towardPlayer)
            {
                targetPosition = player.transform.position;

                //Debug.Log("towardPlayer: " + towardPlayer + " targetPoistion: " + targetPosition);
            }
            else
            {
                Vector3 randomVector3 = UnityEngine.Random.insideUnitSphere;

                targetPosition = new Vector3(
                    randomVector3.x * boundary.x,
                    Mathf.Abs(randomVector3.y * boundary.y),
                    randomVector3.z * boundary.z
                    );

                //Debug.Log("towardPlayer: " + towardPlayer + " targetPoistion: " + targetPosition);
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(minFlyTimeLen, maxFlyTimeLen));
        }
    }


    /*
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

        */
}