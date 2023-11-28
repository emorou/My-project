using UnityEngine;
using UnityEngine.Playables;
 
public class TimelineEnemy : MonoBehaviour {
    public PlayableDirector timeline;
    public GameObject enemy;
    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }
 
 
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            Time.timeScale = 1f;
            timeline.Stop();
        }
    }
 
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            enemy.SetActive(true);
            timeline.Play();
        }
    }
}