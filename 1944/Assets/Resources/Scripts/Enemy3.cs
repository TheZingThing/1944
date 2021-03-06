﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour {

    public float speed = 4f;
    private float shootDelay;
    private float health = 6f;

    private Vector3 moveDirection;

    public EnemySpawner spawner;

    public GameObject player;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {

        shootDelay = Random.Range(0.75f, 1.25f);

        player = GameObject.Find("Player");
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        bulletPrefab = Resources.Load("Prefabs/Bullets/EBullet") as GameObject;

        if (transform.position.x < 0)
        {
            moveDirection = Vector3.right;
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        else
        {
            moveDirection = -Vector3.right;
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
	}
	
	// Update is called once per frame
	void Update () {

        // Destroy if off screen
        if (transform.position.x > 16 || transform.position.x < -16)
        {
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            Destroy(gameObject);

        }

        // Moves horizontally, firing every so often
        shootDelay -= Time.deltaTime;

        transform.position += moveDirection * speed * Time.deltaTime;

        if (shootDelay <= 0)
        {
            var dir = (player.transform.position - transform.position).normalized;

            Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(dir, Vector3.up));

            shootDelay = Random.Range(0.75f, 1.25f);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PBullet")
        {
            health -= 1;
        }
    }

    private void OnDestroy()
    {
        spawner.enemyCount--;
    }
}
