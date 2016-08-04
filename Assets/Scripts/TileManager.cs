using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;
    public GameObject coinPrefab;
    private Transform playerTransform;
    private float spawnZ = -3.0f;//Where in Z to spawn object. X and Y aree constant
    private float tileLength = 10.1f;
    private int amountOfTilesOnScreen = 5;
    private float safeZone = 11.0f;
    private List<GameObject> activeTiles;//To identify which tile to delete 
    private int lastPrefabIndex = 0;
    private List<GameObject> coins;
    

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        coins = new List<GameObject>();
        for(int i=0;i<amountOfTilesOnScreen;i++)
        {
            if(i<3)
                SpawnTile(0); 
            else
                SpawnTile(); 

        }
            
	}
	
	// Update is called once per frame
	private void Update () {
	    if(playerTransform.position.z-safeZone>(spawnZ-amountOfTilesOnScreen*tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    //To spawn a tile
    private void SpawnTile(int prefabIndex=-1)
    {
        GameObject go;
        GameObject coin;
        int rIndex = RandomPrefabIndex();

        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[rIndex]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
        if (rIndex % 2 == 0 && prefabIndex==-1)
        {
            if (go.name.Contains("Left"))
            {
                for (float i = tileLength; i > 0; i = i - 5f)
                {
                    coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = Vector3.forward * (spawnZ - i);
                    coin.transform.position = new Vector3(coin.transform.position.x + 1.5f, coin.transform.position.y + 1.0f, coin.transform.position.z);
                    coins.Add(coin);
                    coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = Vector3.forward * (spawnZ - i - 2.5f);
                    coin.transform.position = new Vector3(coin.transform.position.x + 0.5f, coin.transform.position.y + 1.0f, coin.transform.position.z);
                    coins.Add(coin);
                }
            }
            else if (go.name.Contains("Right"))
            {
                for (float i = tileLength; i > 0; i = i - 5f)
                {
                    coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = Vector3.forward * (spawnZ - i);
                    coin.transform.position = new Vector3(coin.transform.position.x - 1.5f, coin.transform.position.y + 1.0f, coin.transform.position.z);
                    coins.Add(coin);
                    coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = Vector3.forward * (spawnZ - i - 2.5f);
                    coin.transform.position = new Vector3(coin.transform.position.x - 0.5f, coin.transform.position.y + 1.0f, coin.transform.position.z);
                    coins.Add(coin);
                }
            }
            else if (go.name.Contains("normal"))
            {
                for (float i = tileLength; i > 0; i = i - 2.5f)
                {
                    coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = Vector3.forward * (spawnZ - i);
                    coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y + 1.0f, coin.transform.position.z);
                    coins.Add(coin);
                }
            }
            else
            {
                //TODO :JUMP for coins
            }
        }
    }

    //To delete a tile
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }

    private int RandomPrefabIndex()
    {
        

        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex==lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
