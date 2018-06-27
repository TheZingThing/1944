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
    private int prevWaveIndex;

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
                waveIndex = Random.Range(0, 11);
            }
            // Uncommon waves (Moderate Difficulty) 30% chance
            else if (waveIndex < 81)
            {
                waveIndex = Random.Range(11, 15);
            }
            // Rare waves (Moderate-Hard Difficulty) 15% chance
            else if (waveIndex < 96)
            {
                waveIndex = Random.Range(15, 18);
            }
            // Boss waves (Hard Difficulty) 5% chance
            else
            {
                waveIndex = Random.Range(18, 20);
            }

            Debug.Log(waveIndex.ToString());

            if (prevWaveIndex == waveIndex)
            {
                return;
            }

            prevWaveIndex = waveIndex;

            #endregion

            for (int i = 0; i < waves[waveIndex].enemies.Count; i++)
            {
                Instantiate(waves[waveIndex].enemies[i], waves[waveIndex].spawnPos[i], Quaternion.identity);
                enemyCount++;
            }
            
        }

	}
}
