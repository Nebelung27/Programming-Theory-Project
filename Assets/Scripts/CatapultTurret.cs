using System.Collections;
using UnityEngine;

public class CatapultTurret : Turret
{
    private Animator catapultAnim;

    public Transform shootPoint;
    public GameObject bombPrefab;
    private GameObject loadedBomb;

    public float lounchForce = 10.0f;

    private void Start()
    {
        catapultAnim = GetComponentInChildren<Animator>();
        shootingTime = 0.0f;
        reloadTime = 1.0f;

        LoadBomb();
    }
    protected override IEnumerator Shooting()
    {
        catapultAnim.SetTrigger("Fire_trig");

        if (loadedBomb != null)
        {
            var bombRb = loadedBomb.GetComponent<Rigidbody>();
            bombRb.AddForce((Vector3.up + Vector3.forward) * lounchForce, ForceMode.Impulse);
            bombRb.useGravity = true;
        }

        return null;
    }
    protected override IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        LoadBomb();
    }
    private void LoadBomb()
    {
        loadedBomb = Instantiate(bombPrefab, shootPoint.position, Quaternion.identity, transform);
    }
}