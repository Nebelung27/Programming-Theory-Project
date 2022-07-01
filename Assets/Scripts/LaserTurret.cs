using System.Collections;
using UnityEngine;

public class LaserTurret : Turret //Inheritance
{
    [SerializeField]
    private GameObject laser;

    private void Start()
    {
        ShootingTime = 2.0f;
        ReloadingTime = 2.0f;
    }
    protected override IEnumerator Shooting() //Polymorphism
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(ShootingTime);
        laser.SetActive(false);
    }
    protected override IEnumerator Reloading() //Polymorphism
    {
        yield return new WaitForSeconds(ReloadingTime);
    }
}