//HATY CATCHY by m@ boch - NYU GAMECENTER - Oct 2016
//modifications by Bennett Foddy - Jan 2019

using UnityEngine;
using System.Collections;

public class Hat1Spawner : MonoBehaviour {
    //public variables are accessible by other scripts, and are often set in the inspector
    //they're great for tunable variables, like these, since we can edit them in play mode.
    public GameObject hat1Prefab;
    public float timeBetweenSpawns; //interval of time to wait between spawn in seconds
   
    public float xSpawnPosMin; //left most spawn point
    public float xSpawnPosMax; //right most spawn point
    public float ySpawnPos; //height of spawn
    public GameObject window;

    //private variables can't be accessed by other scripts
    private float timeUntilSpawn;

    public void Start()
    {
        timeUntilSpawn = 1.0f;
    }

    public void Update()
    {
        //Time.deltaTime is how much time has occured since the last update. 
        //If we decrease the timer by Time.deltaTime every time Update() runs, the timer will decrease by 1.0 every second.
        timeUntilSpawn -= Time.deltaTime;
        //Once timeUntilSpawn is less than 0, we spawn a new hat
        if (timeUntilSpawn <= 0)
        {
            SpawnHat1();
            //then we reset timeUntilSpawn to the timeBetweenSpawns & start all over again
            timeUntilSpawn = timeBetweenSpawns;
        }
    }

    private void SpawnHat1()
    {
        //Generate a new spawn position. 
        //For the first value of this Vector3 (x) we use Random.Range to get a position between our min & max X values
        //The second (y) is just the height we spawn at
        //The third (z) is the depth, which is set to 0 as we're in 2D
        Vector3 newPos = new Vector3(Random.Range(window.transform.position.x - xSpawnPosMin, window.transform.position.x - xSpawnPosMax), window.transform.position.y + ySpawnPos, 0);
        //Instantiate creates a new object from a prefab. It needs the prefab, the position, and the rotation as arguements
        //newPos is the position we made, Quaternion.identity just means that we're not rotating the sprite
        Instantiate(hat1Prefab, newPos, Quaternion.identity,window.transform);
    }

 

}
