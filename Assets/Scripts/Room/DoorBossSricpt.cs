using UnityEngine;

public class DoorBossScript : MonoBehaviour
{
    [SerializeField] Transform posToGo;
    [SerializeField] Transform middlePoint;
    [SerializeField] GameObject keyTxt;
    [SerializeField] GameObject cameraBounds;
    [SerializeField] GameObject cameraMain;
    [SerializeField] GameObject cameraBoss;
    [SerializeField] GameObject virtualCamera1;
    [SerializeField] GameObject virtualCamera2;
    [SerializeField] GameObject cameraBounds1;
    [SerializeField] GameObject cameraBounds2;
    [SerializeField] private EnemySpawner enemySpawner;
    bool playerDetected;
    GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
        cameraMain.SetActive(true); // Ensure main camera is initially enabled
        //cameraBoss.SetActive(false); // Ensure boss camera is initially disabled
        virtualCamera1.SetActive(true); // Ensure virtualCamera1 is initially enabled
        virtualCamera2.SetActive(false); // Ensure virtualCamera2 is initially disabled
        cameraBounds1.SetActive(true); // Ensure cameraBounds1 is initially enabled
        cameraBounds2.SetActive(false); // Ensure cameraBounds2 is initially disabled
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E) && enemySpawner.ableToTeleport)
            {
                enemySpawner.ableToTeleport = false;
                playerGO.transform.position = posToGo.position;
                playerDetected = false;
                MoveCameraBounds(middlePoint.position); // Move cameraBounds to middlePoint
                SwitchCameras(); // Switch cameras after teleportation
            }
        }
    }

    private void MoveCameraBounds(Vector3 targetPosition)
    {
        if (cameraBounds != null)
        {
            cameraBounds.transform.position = targetPosition;
        }
    }

    private void SwitchCameras()
    {
        cameraMain.SetActive(false); // Disable main camera
        cameraBoss.SetActive(true); // Enable boss camera
        virtualCamera1.SetActive(false); // Disable virtualCamera1
        virtualCamera2.SetActive(true); // Enable virtualCamera2
        cameraBounds1.SetActive(false); // Disable cameraBounds1
        cameraBounds2.SetActive(true); // Enable cameraBounds2
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && enemySpawner.ableToTeleport && !DialogueManager.instance.dialogueIsPlaying)
        {
            playerDetected = true;
            playerGO = col.gameObject;
            keyTxt.SetActive(true);
            enemySpawner.SpawnEnemy();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        playerDetected = false;
        if (keyTxt != null)
        {
            keyTxt.SetActive(false);
        }
    }
}
