using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageSpawner : MonoBehaviour {

    public GameObject treePrefab;

    public float spawnDelay = 2f;
    private float timeUntilSpawn = 0f;

    public int spawnAmount = 3;

	// Use this for initialization
	void Start () {

        treePrefab = Resources.Load("Prefabs/Models/Big Tree") as GameObject;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (timeUntilSpawn <= 0f)
        {

            for (int i = 0; i < spawnAmount; i++)
            {

                Instantiate(treePrefab, new Vector3(Random.Range(-35f, 35f), -23.6f, 23f), Quaternion.identity);

            }


            timeUntilSpawn += spawnDelay;
        }
        else
        {
            timeUntilSpawn -= Time.deltaTime;
        }

	}
}
