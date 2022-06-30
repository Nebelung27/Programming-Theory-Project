using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticle;

    private float speed = 10.0f;
    public float explosionDelayTime;

    void Start()
    {
        StartCoroutine(ExplosionDelay());

        IEnumerator ExplosionDelay()
        {
            yield return new WaitForSeconds(explosionDelayTime);
            ParticleSystem explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            explosion.transform.Rotate(Vector3.right * 90.0f);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}