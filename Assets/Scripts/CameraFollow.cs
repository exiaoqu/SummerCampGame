using UnityEngine;
using System.Collections;

public enum GameStartPhase { ZOOMIN_MAP, ZOOMIN_PLAYER, TRACK_PLAYER };

public class CameraFollow : MonoBehaviour
{
    public float zoomInMapSpeed = 5.0f;
    public float zoomInPlayerSpeed = 0.5f;
    public float declineHeightInZoomInMap = 10.0f;
    public float cameraLookAtPointSpeed = 0.5f;
    public GameStartPhase gameStartPhase;

    public Vector3 margin;          // Distance the player can move before the camera follows.
    public Vector3 smooth;          // How smoothly the camera catches up with it's target movement
    public Vector3 boundaryMax;        // The maximum boundary coordinates the camera can have
    public Vector3 boundaryMin;        // The minmum boundary coordinates the camera can have.

    private GameObject player;       // Reference to the player's transform
    private GameObject mainCamera;
    private GameObject cameraLookAtPoint;
    private Vector3 targetPositionInZoomInMap;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraLookAtPoint = GameObject.FindGameObjectWithTag("CameraLookAtPoint");

        targetPositionInZoomInMap = new Vector3(
            transform.position.x,
            transform.position.y - declineHeightInZoomInMap,
            transform.position.z);

        Debug.Log("Camera decline to: " + targetPositionInZoomInMap);

    }

    private void Update()
    {
        if(gameStartPhase == GameStartPhase.ZOOMIN_MAP)
        {
            ZoomInMap();
        }
        else if(gameStartPhase == GameStartPhase.ZOOMIN_PLAYER)
        {
            ZoomInPlayer();
        }
    }

    private void FixedUpdate()
    {
        if(gameStartPhase == GameStartPhase.TRACK_PLAYER)
        {
            TrackPlayer();
        }
    }


    private void ZoomInMap()
    {
        // vertically decline the camera
        if (transform.position != targetPositionInZoomInMap)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositionInZoomInMap, zoomInMapSpeed * Time.deltaTime);
            mainCamera.transform.LookAt(cameraLookAtPoint.transform);
        }
        else
        {
            gameStartPhase = GameStartPhase.ZOOMIN_PLAYER;
        }
    }

    private void ZoomInPlayer()
    {
        if(transform.position != player.transform.position)
        {
            cameraLookAtPoint.transform.position = Vector3.MoveTowards(cameraLookAtPoint.transform.position, player.transform.position, cameraLookAtPointSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, cameraLookAtPoint.transform.position, zoomInPlayerSpeed * Time.deltaTime);
            mainCamera.transform.LookAt(cameraLookAtPoint.transform);
        }
        else
        {
            gameStartPhase = GameStartPhase.TRACK_PLAYER;
        }
    }

    private void TrackPlayer()
    {
        float targetX = (Mathf.Abs(transform.position.x - player.transform.position.x) > margin.x)?
            Mathf.Lerp(transform.position.x, player.transform.position.x, smooth.x * Time.deltaTime) : transform.position.x;
        float targetZ = (Mathf.Abs(transform.position.z - player.transform.position.z) > margin.z)?
            Mathf.Lerp(transform.position.z, player.transform.position.z, smooth.z * Time.deltaTime) : transform.position.z;
        float targetY = (Mathf.Abs(transform.position.y - player.transform.position.y) > margin.y)?
            Mathf.Lerp(transform.position.y, player.transform.position.y, smooth.y * Time.deltaTime) : transform.position.y;

        targetX = Mathf.Clamp(targetX, boundaryMin.x, boundaryMax.x);
        targetZ = Mathf.Clamp(targetZ, boundaryMin.z, boundaryMax.z);
        targetY = Mathf.Clamp(targetY, boundaryMin.y, boundaryMax.y);

        transform.position = new Vector3(targetX, targetY, targetZ);
    }
}
