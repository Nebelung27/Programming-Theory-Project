using System.Collections;
using UnityEngine;

public class CatapultTurret : Turret
{
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private GameObject bombPrefab;
    private GameObject loadedBomb;
    private float lounchForce = 12.0f;
    
    private Animator catapultAnim;

    private void Start()
    {
        catapultAnim = GetComponentInChildren<Animator>();
        shootingTime = 0.0f;
        reloadingTime = 1.0f;

        LoadBomb();
    }
    protected override IEnumerator Shooting()
    {
        catapultAnim.SetTrigger("Fire_trig");
        LaunchBomb();
        return null;

        void LaunchBomb()
        {
            loadedBomb.transform.SetParent(null);
            var bombRb = loadedBomb.GetComponent<Rigidbody>();
            bombRb.AddForce((transform.up + transform.forward).normalized * lounchForce, ForceMode.Impulse);
            bombRb.useGravity = true;
        }
    }
    protected override IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadingTime);
        LoadBomb();
    }
    private void LoadBomb()
    {
        loadedBomb = Instantiate(bombPrefab, shootPoint.position, transform.rotation, transform);
    }
}