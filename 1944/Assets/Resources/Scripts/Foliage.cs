using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foliage : MonoBehaviour {

    public float speed = 3f;
	
	// Update is called once per frame
	void Update () {

        transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);

        if (transform.position.z <= -23)
        {
            Destroy(gameObject);
        }

	}
}
