using System.Collections;
using UnityEngine;

public class LaserTurret : Turret
{
    private GameObject laser;

    private void Start()
    {
        laser = GameObject.Find("Laser");
        laser.SetActive(false);
        shootingTime = 2.0f;
        reloadTime = 2.0f;
    }
    protected override IEnumerator Shooting()
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(shootingTime);
        laser.SetActive(false);
    }
    protected override IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
    }
}