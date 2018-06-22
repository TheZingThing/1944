using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    public float health = 2;

    public GameObject bulletPrefab;

    public Transform player;

    Vector3 previousPlayerPos;

    public float speed = 3;

    bool hasShot = false;
    bool isReturning = false;

	// Use this for initialization
	void Start () {

        LookAtPlayer();

    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        #region AI

        LookAtPlayer();

        // Move towards the player
        if (Vector3.Distance(transform.position, previousPlayerPos) > 4.5 && !isReturning)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
        // Return from attack run
        else
        {
            isReturning = true;

            if (!hasShot)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                hasShot = true;
            }

            //LookAwayFromPlayer();

            // Move away from player
            if (Vector3.Distance(transform.position, previousPlayerPos) < 8)
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            }
            // Moved far enough, starting another attack
            else
            {
                isReturning = false;
                hasShot = false;
                LookAtPlayer();
            }
        }
        #endregion
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision");

        if (col.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }

    #region Look at player stuff
    void LookAtPlayer()
    {
        // Look at player's previous position
        previousPlayerPos = player.position;

        transform.LookAt(previousPlayerPos);
    }

    void LookAwayFromPlayer()
    {
        // Look away from player
        transform.LookAt(-previousPlayerPos);
    }
    #endregion
}
