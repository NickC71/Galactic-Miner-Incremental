using UnityEngine;

public class OreSpawner : MonoBehaviour
{
    public GameObject orePrefab;
    public int oreAmount = 12;

    public Transform player;
    public float playerSafeDistance = 2f;

    public float minX = -30f;
    public float maxX = 30f;
    public float minY = -30f;
    public float maxY = 30f;

    void Start()
    {
        for (int i = 0; i < oreAmount; i++)
        {
            SpawnOre();
        }
    }

    public void SpawnOre()
    {
        Vector3 spawnPosition = GetRandomPosition();

        Instantiate(orePrefab, spawnPosition, Quaternion.identity);
    }

    public void MoveOre(Ore ore)
    {
        ore.transform.position = GetRandomPosition();
    }

    Vector3 GetRandomPosition()
    {
        Vector3 spawnPosition;

        do
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            spawnPosition = new Vector3(randomX, randomY, 0);

        } while (Vector3.Distance(spawnPosition, player.position) < playerSafeDistance);

        return spawnPosition;
    }
}
