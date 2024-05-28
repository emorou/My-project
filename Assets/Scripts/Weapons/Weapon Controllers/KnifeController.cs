using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    public int currentClip, maxClipSize = 10, currentAmmo, maxAmmoSize = 100;

    public static KnifeController instance;

    [SerializeField] private Camera cameraBoss; // Tambahkan referensi ke kamera boss

    void Awake()
    {
        instance = this;
    }

    protected override void Start()
    {
        currentClip = maxClipSize;
        base.Start();
    }

    protected override void KnifeAttack()
    {
        if (currentClip != 0)
        {
            base.KnifeAttack();
            currentClip--;

            // Determine which camera is currently active or fallback to main camera if cameraBoss is not set
            Camera activeCamera = (cameraBoss != null && cameraBoss.isActiveAndEnabled) ? cameraBoss : Camera.main;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -activeCamera.transform.position.z;
            Vector3 worldMousePosition = activeCamera.ScreenToWorldPoint(mousePosition);
            Vector3 direction = worldMousePosition - transform.position;

            // Normalize the direction vector to have a magnitude of 1
            direction.Normalize();

            // Offset the spawn position slightly in the direction of the mouse cursor
            Vector3 spawnPosition = transform.position + direction * 1f; // Adjust the 1f value as needed

            // Instantiate the knife at the spawn position
            GameObject spawnedKnife = Instantiate(weaponData.Prefab, spawnPosition, Quaternion.identity);
            spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(direction);
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void RestoreAmmo(int amount)
    {
        if (currentAmmo < maxAmmoSize)
        {
            currentAmmo += amount;
        }
    }
}
