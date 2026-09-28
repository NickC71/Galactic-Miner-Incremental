using UnityEngine;

public class Ore : MonoBehaviour
{
    public int health = 5;
    public float respawnTime = 5f;

    private int maxHealth;

    void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Ore health: " + health);

        if (health <= 0)
        { 
            Inventory inventory = FindAnyObjectByType<Inventory>();

            if (inventory != null)
            {
                inventory.AddOreBars(1);
            }

            gameObject.SetActive(false);
            Invoke("Respawn", respawnTime);
            
        }
    }

    void Respawn()
    {
        health = maxHealth;
        gameObject.SetActive(true);
    }
    
}
