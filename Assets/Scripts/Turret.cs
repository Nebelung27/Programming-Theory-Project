using System.Collections;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    private const float rotatingAngel = 3.0f;
    private bool hasLaunched;

    protected float shootingTime;
    protected float reloadingTime;

    protected abstract IEnumerator Shooting();
    protected abstract IEnumerator Reloading();
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