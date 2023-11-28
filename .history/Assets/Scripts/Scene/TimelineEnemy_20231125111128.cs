using UnityEngine;
using UnityEngine.Playables;
 
public class TimelineEnemy : MonoBehaviour {
    public PlayableDirector timeline;
    public GameObject enemy;
    public GameObject canvas;
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
             canvas.SetActive(false);
            timeline.Stop();
        }
    }
 
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            enemy.SetActive(true);
            canvas.SetActive(false);
            timeline.Play();
        }
    }
}