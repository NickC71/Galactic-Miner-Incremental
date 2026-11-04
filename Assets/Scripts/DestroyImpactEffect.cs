using UnityEngine;

public class DestroyImpactEffect : MonoBehaviour
{
    public float lifetime = 0.4f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}