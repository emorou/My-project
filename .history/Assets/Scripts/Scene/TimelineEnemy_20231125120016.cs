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
 
 
    public void EnemyStop()
    {
        canvas.SetActive(true);
        timeline.Stop();
    }
 
    public void EnemyStart()
    {
        Time.timeScale = 0f;
        enemy.SetActive(true);
        canvas.SetActive(false);
        timeline.Play();
    }
}