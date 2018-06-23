using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float fireRate = 5f;
    public float moveSpeed = 6f;

    private float tiltAngle = 15f;
    private float smooth = 5f;
    private float nextTimeToFire;

    public GameObject bulletPrefab;

	// Update is called once per frame
	void Update () {


        // Movement
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;

        // Rotation when moving
        #region Rotation

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;

        Quaternion target = Quaternion.Euler(0, 0, -tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        #endregion

        //Shooting
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position + new Vector3(-0.4f, 0, 0), Quaternion.identity);
        Instantiate(bulletPrefab, transform.position + new Vector3(0.4f, 0, 0), Quaternion.identity);
    }
}
