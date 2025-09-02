using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    
    [SerializeField] private Transform[] spawnPoints;

    private void Awake()
    {
        Instance = this;
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}