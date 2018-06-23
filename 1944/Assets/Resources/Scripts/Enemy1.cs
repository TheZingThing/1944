using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    private float health = 2f;

    public GameObject bulletPrefab;

    public Transform player;

    Vector3 previousPlayerPos;

    public float speed = 3f;

    bool hasShot = false;
    bool isReturning = false;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player").transform;
        bulletPrefab = Resources.Load("Prefabs/Bullets/EBullet") as GameObject;

        LookAtPlayer();

    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        #region AI

        // Move towards the player
        if (Vector3.Distance(transform.position, previousPlayerPos) > 4.5 && !isReturning)
        {
            LookAtPlayer();
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

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            if (speed < 10f)
            {
                speed += Time.deltaTime * 4;
            }

            Destroy(gameObject, 3f);
        }
        #endregion
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PBullet")
        {
            Debug.Log("Collision");
            health -= 1;
        }
    }

    void LookAtPlayer()
    {
        // Look at player's previous position
        previousPlayerPos = player.position;

        transform.LookAt(previousPlayerPos);
    }
}
