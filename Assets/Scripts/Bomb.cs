using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform != transform.parent)
        {
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}