using System.Collections;
using UnityEngine;

public class CatapultTurret : Turret //Inheritance
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
        ShootingTime = 0.0f;
        ReloadingTime = 1.0f;

        LoadBomb(); //Abstraction
    }
    protected override IEnumerator Shooting() //Polymorphism
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
    protected override IEnumerator Reloading() //Polymorphism
    {
        yield return new WaitForSeconds(ReloadingTime);
        LoadBomb(); //Abstraction
    }
    private void LoadBomb()
    {
        loadedBomb = Instantiate(bombPrefab, shootPoint.position, transform.rotation, transform);
    }
}