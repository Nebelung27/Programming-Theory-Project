using System.Collections;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    protected float shootingTime;
    protected float reloadTime;
    private bool hasLaunched;

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
