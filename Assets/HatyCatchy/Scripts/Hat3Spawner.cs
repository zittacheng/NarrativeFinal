using System.Collections;
using UnityEngine;

public class Hat3Spawner : MonoBehaviour
{
    public GameObject hat3Prefab;
    public float timeBetweenSpawns;

    public float xSpawnPosMin;
    public float xSpawnPosMax;
    public float ySpawnPos;
    public GameObject window;
    private float timeUntilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilSpawn = 4.7f;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            SpawnHat3();
            timeUntilSpawn = timeBetweenSpawns;
        }
    }


    private void SpawnHat3()
    {
        Vector3 newPos = new Vector3(Random.Range(window.transform.position.x - xSpawnPosMin, window.transform.position.x - xSpawnPosMax), window.transform.position.y + ySpawnPos, 0);
        //Instantiate creates a new object from a prefab. It needs the prefab, the position, and the rotation as arguements
        //newPos is the position we made, Quaternion.identity just means that we're not rotating the sprite
        Instantiate(hat3Prefab, newPos, Quaternion.identity, window.transform);
    }
}
