using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviourScript : MonoBehaviour
{
    public GameObject SpawnObjectPrefab;
    private List<GameObject> SpawnPoints = new List<GameObject>();
    
    public float SpawnCadence = 0.0f;
    private float SpawnTimer = 0.0f;

    void GetSpawnPoints()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            SpawnPoints.Add( transform.GetChild(i).gameObject);
        }
    }

    void Start()
    {
        GetSpawnPoints();
    }

    void Update()
    {
        SpawnTimer += Time.deltaTime;
        if (SpawnTimer >= SpawnCadence)
        {
            SpawnObject();
            SpawnTimer = 0.0f;
        }
    }

    void SpawnObject()
    {
        int SpawnPointIndex = Random.Range(0, SpawnPoints.Count);
        GameObject SpawnPoint = SpawnPoints[SpawnPointIndex];
        Instantiate(SpawnObjectPrefab, SpawnPoint.transform.position, Quaternion.identity);
    }
}
