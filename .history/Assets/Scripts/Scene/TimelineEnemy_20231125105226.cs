using UnityEngine;
using UnityEngine.Playables;
 
public class TimelineEnemy : MonoBehaviour {
    public PlayableDirector timeline;
    public GameObject
    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }
 
 
    void OnTriggerExit (Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeline.Stop();
        }
    }
 
    void OnTriggerEnter (Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeline.Play();
        }
    }
}