using UnityEngine;
using UnityEngine.Playables;
 
public class TimelineEnemy : MonoBehaviour {
    public PlayableDirector timeline;
    public GameObject enemy;
    public GameObject canvas;
    // Use this for initialization

    ovid Start()
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
        enemy.SetActive(true);
        canvas.SetActive(false);
        timeline.Play();
    }
}