using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Transform posToGo;
    [SerializeField] Transform middlePoint;
    [SerializeField] GameObject keyTxt;
    [SerializeField] GameObject cameraBounds;
    [SerializeField] private EnemySpawner enemySpawner;
    bool playerDetected;
    GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E) && enemySpawner.ableToTeleport && !DialogueManager.instance.dialogueIsPlaying)
            {
                enemySpawner.ableToTeleport = false;
                playerGO.transform.position = posToGo.position;
                playerDetected = false;
                MovecameraBounds(middlePoint.position); // Move cameraBounds to middlePoint
            }
        }
    }
    
    private void MovecameraBounds(Vector3 targetPosition)
    {
        if (cameraBounds != null)
        {
            cameraBounds.transform.position = targetPosition;
        }
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
