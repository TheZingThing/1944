using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float moveSpeed = 5f;
    [HideInInspector]
    public float tiltAngle = 15f;
    [HideInInspector]
    public float smooth = 5f;

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
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
