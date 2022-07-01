using System.Collections;
using UnityEngine;

public class MissileTurret : Turret //Inheritance
{
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private GameObject missilePrefab;

    void Start()
    {
        ShootingTime = 1.5f;
        ReloadingTime = 1.0f;
    }
    protected override IEnumerator Shooting() //Polymorphism
    {
        var newMissil = Instantiate(missilePrefab, shootPoint.position, transform.rotation, transform);
        newMissil.transform.SetParent(null);
        newMissil.GetComponent<Missile>().ExplosionDelayTime = ShootingTime;
        return null;
    }
    protected override IEnumerator Reloading() //Polymorphism
    {
        yield return new WaitForSeconds(ReloadingTime);
    }
}