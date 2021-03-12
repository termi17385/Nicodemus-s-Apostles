using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Andrew's old code.
    /*
    public Transform levelPrefab;
    Transform lastLevelPiece = null;
    */

    // Gets all the prefabs
    public GameObject obstaclePrefab;
    public GameObject checkpointPrefab;
    public GameObject eskyPrefab;
    public GameObject backgroundPrefabs;

    // Cycles through 13 before it spawns a check point.
    private int spawnChooser = 13;

    // Object move at this Speed.
    public int objectSpeed = 7;

    // Spawn time.
    private float spawnTime = 0;
    private float spawnTime2 = 0;

    // Min and max spawn time.
    private float minSpawnTime = 2;
    private float maxSpawnTime = 7;

    private Vector3 objectYIncrease;

    private void Start()
    {
        // Sets the spawn time between min or max.
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        spawnTime2 = Random.Range(minSpawnTime, maxSpawnTime);

        // Start Coroutine for object spawning including door and esky.
        StartCoroutine(SpawnNextPiece());

        // Start Coroutine for background object spawning such as stuff on the wall.
        StartCoroutine(SpawnBackground());

        //lastLevelPiece = Instantiate(SpawnNextPiece());
    }

    // Called by objects to get speed.
    public int GetSpeed()
    {
        return objectSpeed;
    }

    private IEnumerator SpawnBackground()
    {

        while (true)
        {
            yield return new WaitForSeconds(spawnTime2);
            // Not to spawn background stuff over the door or esky.
            if (spawnChooser > 2)
            {
                // Get a Vector 3 to add to the current spawn place
                objectYIncrease = new Vector3(0, 2, 0);
                // Makes a background object.
                Instantiate(backgroundPrefabs, transform.position + objectYIncrease, Quaternion.identity, transform);
            }
            // Resets time.
            spawnTime2 = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    private IEnumerator SpawnNextPiece()
    {
        while (true)
        {
            // Waits for a random ammount of time.
            yield return new WaitForSeconds(spawnTime);

            // Makes a object going down from 13.
            if (spawnChooser <= 0)
            {
                // Makes a esky object.
                Instantiate(eskyPrefab, transform.position, Quaternion.identity, transform);
                // Resets spawner count to 13.
                spawnChooser = 13;
                // Reset the spawnTime to another random one.
                spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                print("esky");
            }
            else if (spawnChooser == 1)
            {
                // Get a Vector 3 to add to the current spawn place
                objectYIncrease = new Vector3(0, 2, 0);
                // Makes a checkpoint object.
                Instantiate(checkpointPrefab, transform.position + objectYIncrease, Quaternion.identity, transform);
                // Decreases spawner count by one.
                spawnChooser--;
                // Reset the spawnTime to 1 so that the esky and checkpoint are close.
                spawnTime = 1;
                print("checkpoint");
            }
            else
            {
                // Makes an object to jump over.
                Instantiate(obstaclePrefab, transform.position, Quaternion.identity, transform);
                // Decreases spawner count by one.
                spawnChooser--;
                // Reset the spawnTime to another random one.
                spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                print("obstaclePrefab");
            }
        }

        // Andrew's old code.
        /*
        Renderer lastRenderer = lastLevelPiece.GetComponent<Renderer>();

        Vector3 spawnLocation = new Vector3(lastRenderer.bounds.max.x, lastRenderer.bounds.min.y, lastLevelPiece.position.z);

        Transform nextPiece = Instantiate(levelPrefab);
        Spawner test = nextPiece.GetComponent<Spawner>();
        test.levelPrefab = transform;


        Renderer nextRenderer = nextPiece.GetComponent<Renderer>();
        spawnLocation.x += nextRenderer.bounds.extents.x;
        spawnLocation.y += nextRenderer.bounds.extents.y;
        nextPiece.position = spawnLocation;
        lastLevelPiece = nextPiece;        
        */
    }



    //void Update()
    //{
    //    SpawnNextPiece();
    //}
}
