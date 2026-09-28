using UnityEngine;

public class Projectile : MonoBehaviour
{
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
            Ore ore = collision.GetComponent<Ore>();

            if (ore != null)
            {
                ore.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        
    }
   
}