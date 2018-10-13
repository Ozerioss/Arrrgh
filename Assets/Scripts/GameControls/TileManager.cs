using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] obstacles;
    public GameObject[] buffs;
    public GameObject[] tilePrefabs;
    public int amountOfTiles = 10;
    public float xOffset = 3;
    public GameObject endLevel;


    private Transform playerTransform;
    private float spawnZ = 9.0f;
    private float tileLength = 9f;
    private int lastPrefabIndex = 0;
    private int lastRandomX = 0;
    private float safeZone = 15f; //safe zone before deleting tiles

    private float[] xValues = new float[3];

    private List<GameObject> activeTiles;
    // Probability for one obstacle
    private int oneObstacleMinProbability = SpawnProbability.oneObstacleMinProbability;
    private int oneObstacleMaxProbability = SpawnProbability.oneObstacleMaxProbability;
    // Probability for two obstacles
    private int twoObstacleMinProbability = SpawnProbability.twoObstacleMinProbability;
    private int twoObstacleMaxProbability = SpawnProbability.twoObstacleMaxProbability;
    // Probability for buff
    private int buffMaxProbability = SpawnProbability.buffMaxProbability;
    private int buffMinProbability = SpawnProbability.buffMinProbability;



    // Use this for initialization
    void Start ()
    {
        xValues = new float[] {-xOffset, (-xOffset + xOffset) / 2, xOffset }; //Position de l'objet sur X
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amountOfTiles; i++)
        {
            // spawn safe tiles ( no obstacle )
            if (i <= 2)
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
        GameObject goBuff;
        int newIndex = RandomPrefabIndex(obstacles); // get random index
        int secondIndex = RandomPrefabIndex(buffs);

        List<GameObject> obstaclesActifs = new List<GameObject>();

        int probability = Random.Range(0, 100);

        if(indexPrefab == -1)
        {
            go = Instantiate(tilePrefabs[0]) as GameObject; //Instantiate random tile from list ( for now only empty tile )
            
            int obstacleNbr = GetNumberOfObstacles();

            // Spawn obstacles
            for(int i = 0; i < obstacleNbr; i++)
            {
                goObstacle = Instantiate(obstacles[newIndex], new Vector3(GetRandomX(xValues), 0.8f, spawnZ), obstacles[newIndex].transform.rotation); //Gets a random obstacle and spawns it at random position
                obstaclesActifs.Add(goObstacle);
            }

            if (probability >= buffMinProbability && probability <= buffMaxProbability)
            {
                if(obstacleNbr > 1)
                {
                    Instantiate(buffs[secondIndex], new Vector3(xValues[penultimateRandomX], 0.8f, spawnZ), buffs[secondIndex].transform.rotation);
                }
                else
                {
                    goBuff = Instantiate(buffs[secondIndex], new Vector3(GetRandomX(xValues), 0.8f, spawnZ), buffs[secondIndex].transform.rotation);
                }
            }
            
        }
        else
        {
            go = Instantiate(tilePrefabs[0]);
            goObstacle = null;
            goBuff = null;
        }

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;

        spawnZ += tileLength;
        activeTiles.Add(go);
    }


    // To do object pooling

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

    private int penultimateRandomX = 0;

    private float GetRandomX(float[] xValues)
    {
        int randomX = lastRandomX;
        penultimateRandomX = lastRandomX;
        while(randomX == lastRandomX)
        {
            randomX = Random.Range(0, xValues.Length);
        }
        lastRandomX = randomX;
        return xValues[randomX];
    }

    private int GetNumberOfObstacles()
    {
        //Determines how many obstacles and buffs per tile
        int objectsToSpawn = 0;
        int probability = Random.Range(0, 100);


        for (int i = 0; i < 2; i++)
        {
            if (probability >= oneObstacleMinProbability && probability <= oneObstacleMaxProbability)
            {
                Debug.Log("One obstacle");
                objectsToSpawn++;
                break;
            }

            if (probability >= twoObstacleMinProbability && probability <= twoObstacleMaxProbability)
            {
                Debug.Log("TWO OBSTACLES");
                objectsToSpawn += 2;
                break;
            }

        }

        return objectsToSpawn;
        
    }
}
