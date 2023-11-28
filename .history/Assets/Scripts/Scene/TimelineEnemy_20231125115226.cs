using UnityEngine;
using UnityEngine.Playables;
 
public class TimelineEnemy : MonoBehaviour {
    public PlayableDirector timeline;
    public GameObject enemy;
    public GameObject canvas;
    // Use this for initialization
    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }
 
 
    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            Time.timeScale = 1f;
            canvas.SetActive(true);
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