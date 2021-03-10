using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform levelPrefab;
    // Start is called before the first frame update

    Transform lastLevelPiece = null;
    private void Start()
    {
        lastLevelPiece = Instantiate(levelPrefab);
    }

    void SpawnNextPiece()
    {
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


        
    }



    // Update is called once per frame
    void Update()
    {
        SpawnNextPiece();
    }
}
