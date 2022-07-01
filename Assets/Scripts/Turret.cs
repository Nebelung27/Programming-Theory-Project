using System.Collections;
using UnityEngine;

public abstract class Turret : MonoBehaviour // Abstraction
{
    private const float rotatingAngel = 3.0f;
    private bool hasLaunched;

    private float shootingTime;
    private const float minShootingTime = 0.0f;
    private const float maxShootingTime = 5.0f;
    protected float ShootingTime // Encapsulation
    {
        get { return shootingTime; }
        set { shootingTime = Mathf.Clamp(value, minShootingTime, maxShootingTime); }
    }

    private float reloadingTime;
    private const float minReloadingTime = 0.0f;
    private const float maxReloadingTime = 5.0f;
    protected float ReloadingTime // Encapsulation
    {
        get { return reloadingTime; }
        set { reloadingTime = Mathf.Clamp(value, minReloadingTime, maxReloadingTime); }
    }

    protected abstract IEnumerator Shooting(); //Polymorphism
    protected abstract IEnumerator Reloading(); //Polymorphism
    private void OnMouseOver()
    {
        RoatateTurret();

        void RoatateTurret()
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
            {
                transform.Rotate(Vector3.up * rotatingAngel);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
            {
                transform.Rotate(Vector3.up * -rotatingAngel);
            }
        }
    }
    private void OnMouseDown()
    {
        if (hasLaunched)
            return;

        StartCoroutine(ShootingRoutine());

        IEnumerator ShootingRoutine()
        {
            hasLaunched = true;
            yield return Shooting();
            yield return Reloading();
            hasLaunched = false;
        }
    }
}