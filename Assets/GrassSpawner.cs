using UnityEngine;

public class GrassSpawner : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject grassPrefab;
    [SerializeField]
    private float spawnTime = 3;
    private float spawnCounter = 3;

    private GameObject[] spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        spawnPositions = GameObject.FindGameObjectsWithTag("SpawnPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCounter > 0) {
            spawnCounter -= Time.deltaTime;
        }
        else {
            Instantiate(grassPrefab, spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position, Quaternion.identity);
            spawnCounter += spawnTime;
        }
    }
}
