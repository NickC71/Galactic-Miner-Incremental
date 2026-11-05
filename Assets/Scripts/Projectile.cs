using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    public float projectileSpeed;
    public float lifetime = 0.01f;
    public int damage = 1;
    private Rigidbody2D rigidbody;
   

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.linearVelocity = transform.right * projectileSpeed;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Instantiate(ore, transform.position, Quaternion.identity);
        if (collision.CompareTag("ore"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayImpact();
            }

            Ore ore = collision.GetComponent<Ore>();

            if (ore != null)
            {
                ore.TakeDamage(damage);
                if (impactEffect != null)
                {
                    Instantiate(impactEffect, transform.position, Quaternion.identity);
                }
            }

            Destroy(gameObject);
        }
        
    }
   
}