using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticle;
    [SerializeField]
    private float speed = 10.0f;
    public float ExplosionDelayTime { private get; set; } // Encapsulation

    void Start()
    {
        StartCoroutine(ExplosionDelay());

        IEnumerator ExplosionDelay()
        {
            yield return new WaitForSeconds(ExplosionDelayTime);
            var newExplosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            newExplosion.transform.Rotate(Vector3.right * 90.0f);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}