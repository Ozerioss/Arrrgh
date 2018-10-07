using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;
    public int amountOfTiles = 7;


    private Transform playerTransform;
    private float spawnZ = 10.0f;
    private float tileLength = 10f;
    private int lastPrefabIndex = 0;
    private float safeZone = 15f; //safe zone before deleting tiles

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start ()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amountOfTiles; i++)
        {
            if (i < 2)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Logic to spawn tiles as player goes
		if(playerTransform.position.z - safeZone > (spawnZ - amountOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    void SpawnTile(int indexPrefab = -1)
    {
        GameObject go;
        int newIndex = RandomPrefabIndex(); // get random index
        if(indexPrefab == -1)
        {
            go = Instantiate(tilePrefabs[newIndex]) as GameObject; //Instantiate random tile from list
        }
        else
        {
            go = Instantiate(tilePrefabs[indexPrefab]);
        }

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }


    void DeleteTile()
    {
        //Logic to delete old tiles
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }


    // Custom random number generator
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
