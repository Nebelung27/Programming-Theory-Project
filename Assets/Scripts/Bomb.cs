using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform != transform.parent)
        {
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}