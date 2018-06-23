using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour {

    public float speed = 4f;
    private float health = 2f;

    private float shootDelay;

    private bool returning = false;

    public GameObject bulletPrefab;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        
        shootDelay = Random.Range(1.5f, 3.5f);

        player = GameObject.Find("Player");
        bulletPrefab = Resources.Load("Prefabs/Bullets/EBullet") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {

        shootDelay -= Time.deltaTime;

        if (health <= 0)
        {
            Destroy(gameObject);

        }

        // Moves downwards towards the centre, before returning back up while occasionally firing
        if (shootDelay <= 0)
        {
            var dir = (player.transform.position - transform.position).normalized;

            Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(dir, Vector3.up));

            shootDelay = Random.Range(1f, 3.5f);
        }

        if (transform.position.z > 0 && !returning)
        {
            transform.position += new Vector3(0f, 0f, -speed * Time.deltaTime);
        }
        else
        {
            if (!returning)
            {
                returning = true;
            }

            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
        }
        

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PBullet")
        {
            Debug.Log("Collision");
            health -= 1;
        }
    }
}

