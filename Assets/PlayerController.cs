using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        // Check for user input or other conditions to trigger firing
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // Instantiate a bullet at the fire point
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

