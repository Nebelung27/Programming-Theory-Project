using System.Collections;
using UnityEngine;

public class LaserTurret : Turret
{
    [SerializeField]
    private GameObject laser;

    private void Start()
    {
        shootingTime = 2.0f;
        reloadingTime = 2.0f;
    }
    protected override IEnumerator Shooting()
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(shootingTime);
        laser.SetActive(false);
    }
    protected override IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadingTime);
    }
}