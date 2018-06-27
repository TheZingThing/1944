using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour {

    private float health = 2f;

    public Transform player;

    Vector3 previousPlayerPos;

    public float speed = 3f;

    private bool hasLocked = false;

    public EnemySpawner spawner;

    // Use this for initialization
    void Start()
    {

        transform.rotation = Quaternion.LookRotation(new Vector3(0f, 0f, -1f));

        player = GameObject.Find("Player").transform;
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

    }

    // Update is called once per frame
    void Update()
    {

        // Destroy if off screen
        if (transform.position.z <= -10)
        {
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        #region AI
        // If at halfway and player is below halfway, lock on and move towards the players position when crossing halfway
        if (transform.position.z <= 0 && player.position.z < 0)
        {
            if (!hasLocked)
                LookAtPlayer();

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            // Speed up
            if (speed < 15f)
            {
                speed += Time.deltaTime * 6f;
            }

            Destroy(gameObject, 3f);
        }
        // If at halfway and player is above halfway, lock on and move downwards
        else if(transform.position.z <= 0 && player.position.z > 0)
        {
            if (!hasLocked)
            {
                transform.LookAt(transform.position + new Vector3(0f, 0f, -1f));

                hasLocked = true;
            }

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            // Speed up
            if (speed < 10f)
            {
                speed += Time.deltaTime * 4;
            }

            Destroy(gameObject, 3f);

            return;
        }
        // Otherwise, move towards halfway
        else
        {
            // Return if already locked on. This is to prevent errors if the players moves past halfway once locked on
            if (hasLocked)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

                // Speed up
                if (speed < 10f)
                {
                    speed += Time.deltaTime * 4;
                }

                return;
            }

            transform.position += new Vector3(0f, 0, -speed * Time.deltaTime);
        }
        #endregion  

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PBullet")
        {
            health -= 1;
        }
    }

    void LookAtPlayer()
    {
        hasLocked = true;

        // Look at player's previous position
        previousPlayerPos = player.position;

        transform.LookAt(previousPlayerPos);
    }

    private void OnDestroy()
    {
        spawner.enemyCount--;
    }
}
