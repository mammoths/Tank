using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Tank : MonoBehaviour
{

    public float tankMovementSpeed;
    public float tankRotationSpeed;
    public float turretPitchBound;
    public float turretYawBound;
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    public float launchPower;

    public Transform turret;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(float intensity)
    {
        rb.velocity = transform.forward * ClampedIntensity(intensity) * tankMovementSpeed;
    }

    public void Turn(float intensity)
    {
        rb.angularVelocity = transform.up * ClampedIntensity(intensity) * tankRotationSpeed;
    }

    public void TurnTurret(float intensityX, float intensityY)
    {
        turret.localRotation = Quaternion.Euler(
            ClampedIntensity(intensityX) * turretPitchBound,
            ClampedIntensity(intensityY) * turretYawBound,
            0
        );
    }

    private float ClampedIntensity(float intensity)
    {
        return Mathf.Clamp(intensity, -1f, 1f);
    }

    public void LaunchBullet()
    {
        GameObject go = (GameObject)Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.Launch(bulletSpawner.forward * launchPower);
    }
}