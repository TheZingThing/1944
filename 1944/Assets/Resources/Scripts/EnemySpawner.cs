using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [System.Serializable]
    public class Wave
    {
        public List<GameObject> enemies = new List<GameObject>();
        public List<Vector3> spawnPos = new List<Vector3>();
    }

    public Wave[] waves;

    [HideInInspector]
    public int enemyCount = 0;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
        // Spawn if there are no enemies left
        if (enemyCount <= 0) 
        {
            var waveIndex = Random.Range(1, 100);

            #region Possible waves 

            // Common waves (Easy-Moderate Difficulty) 50% chance
            if (waveIndex < 51)
            {
                waveIndex = Random.Range(0, 5);
            }
            // Uncommon waves (Moderate Difficulty) 25% chance
            else if (waveIndex < 76)
            {
                waveIndex = Random.Range(5, 8);
            }
            // Rare waves (Moderate-Hard Difficulty) 15% chance
            else if (waveIndex < 91)
            {
                waveIndex = Random.Range(8, 11);
            }
            // Boss waves (Hard Difficulty) 10% chance
            else
            {
                waveIndex = Random.Range(11, 12);
            }

            Debug.Log(waveIndex.ToString());

            #endregion

            for (int i = 0; i < waves[waveIndex].enemies.Count; i++)
            {
                Instantiate(waves[waveIndex].enemies[i], waves[waveIndex].spawnPos[i], Quaternion.identity);
                enemyCount++;
            }
            
        }

	}
}
