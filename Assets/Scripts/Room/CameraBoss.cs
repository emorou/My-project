using Cinemachine;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera room;
    [SerializeField] CinemachineVirtualCamera bossroom;

    // Start is called before the first frame update
    void Start()
    {
        // Mengaktifkan kamera room saat memulai permainan
        // ActivateRoomCamera();
    }

    // Method untuk mengaktifkan kamera room dan menonaktifkan kamera bossroom
    /*void ActivateRoomCamera()
    {
        room.gameObject.SetActive(true);
        bossroom.gameObject.SetActive(false);
    }*/

    // Method untuk mengaktifkan kamera bossroom dan menonaktifkan kamera room
    public void ActivateBossRoomCamera()
    {
        room.gameObject.SetActive(false);
        bossroom.gameObject.SetActive(true);
    }

    // Update is called once per frame
    /*void Update()
    {
        // Contoh penggunaan untuk mengaktifkan kamera bossroom pada suatu kondisi
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateBossRoomCamera();
        }
    }*/
}
