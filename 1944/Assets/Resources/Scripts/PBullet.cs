using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > 16 || transform.position.x < -16 || transform.position.z < -10 || transform.position.z > 10)
        {
            Destroy(gameObject);
        }

        //transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
