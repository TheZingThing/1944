using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour {

    public float rotateSpeed = 200f;
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

	}
}
