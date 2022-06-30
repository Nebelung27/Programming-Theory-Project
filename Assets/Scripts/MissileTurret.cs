using System.Collections;
using UnityEngine;

public class MissileTurret : Turret
{
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private GameObject missilePrefab;

    void Start()
    {
        shootingTime = 1.5f;
        reloadingTime = 1.0f;
    }
    protected override IEnumerator Shooting()
    {
        var newMissil = Instantiate(missilePrefab, shootPoint.position, transform.rotation, transform);
        newMissil.transform.SetParent(null);
        newMissil.GetComponent<Missile>().explosionDelayTime = shootingTime;
        return null;
    }
    protected override IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadingTime);
    }
}