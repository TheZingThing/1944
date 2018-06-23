using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour {

    public float speed = 4f;
    private float health = 12f;

    private float shootDelay;

    private bool movingToPosition = true;
    
    public GameObject bulletPrefab;
    public GameObject player;

    private Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        shootDelay = Random.Range(1f, 1.5f);

        player = GameObject.Find("Player");
        bulletPrefab = Resources.Load("Prefabs/Bullets/EBullet") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }

        // Move towards desired position
        if (transform.position != new Vector3(0f, 0f, 4.75f) && movingToPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 4.75f), speed * Time.deltaTime);
        }
        
        if (transform.position == new Vector3(0f, 0f, 4.75f))
        {
            movingToPosition = false;
            originalPosition = transform.position;
        }

        if (!movingToPosition)
        {
                transform.position = new Vector3(Mathf.Sin(Time.time) * 6f, 0f, 4.75f);

            shootDelay -= Time.deltaTime;

            if (shootDelay <= 0)
            {
                var mainPoint = new Vector3(0f, 0f, -3f);

                Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(mainPoint - new Vector3(1f, 0f, 0f), Vector3.up));
                Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(mainPoint,                           Vector3.up));
                Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(mainPoint + new Vector3(1f, 0f, 0f), Vector3.up));

                shootDelay = Random.Range(1f, 1.5f);
            }
        }





        /*
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
        */

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
