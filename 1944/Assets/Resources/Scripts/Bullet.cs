using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        Destroy(gameObject, 3f);
	}
}
