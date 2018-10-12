using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] obstacles;
    public GameObject[] buffs;
    public GameObject[] tilePrefabs;
    public int amountOfTiles = 10;
    public float xOffset = 3;
    


    private Transform playerTransform;
    private float spawnZ = 9.0f;
    private float tileLength = 9f;
    private int lastPrefabIndex = 0;
    private float safeZone = 15f; //safe zone before deleting tiles

    private float[] xValues = new float[3];

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start ()
    {
        xValues = new float[] {-xOffset, (-xOffset + xOffset) / 2, xOffset }; //Position de l'objet sur X
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amountOfTiles; i++)
        {
            // spawn safe tiles ( no obstacle )
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
        GameObject goObstacle;
        int newIndex = RandomPrefabIndex(obstacles); // get random index
        if(indexPrefab == -1)
        {
            go = Instantiate(tilePrefabs[0]) as GameObject; //Instantiate random tile from list
            //goObstacle = Instantiate(obstacles[newIndex]) as GameObject;
            goObstacle = Instantiate(obstacles[newIndex], new Vector3(GetRandomX(xValues), 0.8f, spawnZ), obstacles[newIndex].transform.rotation);
        }
        else
        {
            go = Instantiate(tilePrefabs[0]);
            goObstacle = null;
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
    private int RandomPrefabIndex(GameObject[] goArray)
    {
        if(goArray.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, goArray.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    private float GetRandomX(float[] xValues)
    {
        int randomXIndex = Random.Range(0, xValues.Length);
        return xValues[randomXIndex];
    }
}
