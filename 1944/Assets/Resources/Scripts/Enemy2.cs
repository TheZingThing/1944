using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    public float speed = 3f;
    private float health = 8f;

    private float shootDelay;

    public EnemySpawner spawner;

    public GameObject bulletPrefab;
    public GameObject player;

	// Use this for initialization
	void Start () {

        shootDelay = Random.Range(1f, 3f);

        player = GameObject.Find("Player");
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        bulletPrefab = Resources.Load("Prefabs/Bullets/EBullet") as GameObject;

    }
	
	// Update is called once per frame
	void Update () {

        // Destroy if off screen
        if (transform.position.z >= 10)
        {
            Destroy(gameObject);
        }

        shootDelay -= Time.deltaTime;

        if (health <= 0)
        {
            Destroy(gameObject);

        }

        // Moves upwards, firing every so often
        if (shootDelay <= 0)
        {
            var dir = (player.transform.position - transform.position).normalized;

            Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(dir, Vector3.up));

            shootDelay = Random.Range(1f, 3f);
        }

        transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);

	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PBullet")
        {
            Debug.Log("Collision");
            health -= 1;
        }
    }

    private void OnDestroy()
    {
        spawner.enemyCount--;
    }
}
